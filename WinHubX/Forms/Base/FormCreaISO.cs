using System.Diagnostics;
using System.IO.Compression;
using System.Text.Json;

namespace WinHubX.Forms.Base
{
    public partial class FormCreaISO : Form
    {
        private Form1 form1;
        private string selectedFile; // Class-level variable to store selected ISO file path

        public FormCreaISO(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            groupBox7.Hide();
            groupBox6.Hide();
            pictureBox7.Hide();
            pictureBox4.Hide();
            this.FormClosing += FormCreaISO_FormClosing;
            this.ActiveControl = btn_browser;
        }

        string IsoMountLetter;
        string installwimpath;
        int windowsEdition;

        public void ExecuteCommand(string command, bool ShowMessage)
        {
            if (!ShowMessage)
            {
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = command,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                }
            }
            else if (ShowMessage)
            {
            }
        }
        private async Task<string> GetZipUrlFromJsonAsync(string jsonUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Fetch the JSON data
                    string jsonResponse = await client.GetStringAsync(jsonUrl);

                    // Parse the JSON and get the value for "creaiso" under "CreaISOWIN"
                    using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                    {
                        JsonElement root = doc.RootElement;
                        string zipUrl = root.GetProperty("CreaISOWIN").GetProperty("creaiso").GetString();
                        return zipUrl;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (optional)
                    MessageBox.Show("Errore nel recupero dell'URL: " + ex.Message);
                    return string.Empty;
                }
            }
        }
        private async void btn_CreaISO_Click(object sender, EventArgs e)
        {
            // Smonta l'immagine disco
            ExecuteCommand("Dismount-DiskImage -ImagePath " + "\"" + selectedFile + "\"", false);

            // Ottieni la selezione dal ComboBox
            string ComboSelected = "";
            string comboxstr = comboBox1.Text;
            int index = comboxstr.IndexOf(' ');
            if (index > 0)
            {
                ComboSelected = comboxstr.Substring(0, index);
            }

            // Ottieni le preferenze selezionate
            string windowsVersion = Win10Rad.Checked ? "10" : Win11Rad.Checked ? "11" : "";
            string edgeRemovalPreference = RemEdgeRad.Checked ? "RemoveEdge" : NotRemEdgeRad.Checked ? "SiEdge" : "";
            string defenderPreference = DisWindDefRad.Checked ? "DisableWindowsDefender" : NotDisWinDefRad.Checked ? "SiDefender" : "";
            string Processi = RemProcRad.Checked ? "RimuoviProcessi" : NotRemProcRad.Checked ? "NonRimuovereProcessi" : "";
            string Unattend = Win11BypassRad.Checked ? "Bypass" : Win11StockRad.Checked ? "Stock" : "";
            string Architettura = SixforArchRad.Checked ? "x64" : ThirTwoRad.Checked ? "x32" : "";
            string DebloatApp = DebAppRad.Checked ? "Debloat" : StockAppRad.Checked ? "NonDebloat" : "";

            string zipUrl = await GetZipUrlFromJsonAsync("https://aimodsitalia.store/ConfigWinHubX/configWinHubX.json");
            string zipFilePath = Path.Combine(Path.GetTempPath(), "RisorseCreaISO.zip");

            try
            {
                // Scarica il file zip solo se non esiste già
                if (!File.Exists(zipFilePath))
                {
                    await ScaricaFileAsync(zipUrl, zipFilePath);
                }

                string tempPath = Path.Combine(Path.GetTempPath(), "RisorseCreaISO");

                // Verifica se la cartella di destinazione esiste, se no la crea
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string destinazioneFile = Path.Combine(tempPath, entry.FullName);

                        // Se l'entry è una directory, salta
                        if (string.IsNullOrEmpty(entry.Name))
                        {
                            continue; // Salta se è una cartella
                        }

                        // Estrai il file direttamente nella cartella RisorseCreaISO
                        string directoryPath = Path.GetDirectoryName(destinazioneFile);
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath); // Crea la directory se non esiste
                        }

                        entry.ExtractToFile(destinazioneFile, overwrite: true); // Estrai il file
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il download o l'estrazione: {ex.Message}");
                return;
            }
            string tempExtractionPath = Path.Combine(Path.GetTempPath(), "RisorseCreaISO"); // Usa il nuovo nome
            string batchFileName = Win10Rad.Checked ? "isotool10.bat" : "isotool11.bat";
            string batchFilePath = Path.Combine(tempExtractionPath, batchFileName);

            if (!File.Exists(batchFilePath))
            {
                MessageBox.Show($"File batch non trovato: {batchFilePath}");
                return;
            }

            // Prepara gli argomenti da passare al batch
            string argsList = $"\"{selectedFile}\" {windowsVersion} {edgeRemovalPreference} {defenderPreference} " +
                              $"{ComboSelected} {Processi} {Unattend} {Architettura} {DebloatApp}";

            // Configura ed esegui il file batch
            var startInfo = new ProcessStartInfo()
            {
                FileName = batchFilePath,
                Arguments = argsList,
                UseShellExecute = true,
                CreateNoWindow = false,
                WorkingDirectory = tempExtractionPath
            };

            try
            {
                using (var process = Process.Start(startInfo))
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'esecuzione del batch: {ex.Message}");
            }
        }

        private async Task ScaricaFileAsync(string url, string destinazione)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    using (FileStream fs = new FileStream(destinazione, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fs);
                    }
                }
            }
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "ISO Files (*.iso)|*.iso|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = openFileDialog.FileName;
                textBox1.Text = selectedFile;
                ExecuteCommand("Mount-DiskImage -ImagePath " + "\"" + selectedFile + "\"", false);

                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = "(Get-DiskImage -ImagePath \"" + selectedFile + "\" | Get-Volume).DriveLetter",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                    IsoMountLetter = output.Trim();
                }

                if (File.Exists(IsoMountLetter + ":\\sources\\install.wim"))
                {
                    installwimpath = IsoMountLetter + ":\\sources\\install.wim";
                }
                else if (File.Exists(IsoMountLetter + ":\\sources\\install.esd"))
                {
                    installwimpath = IsoMountLetter + ":\\sources\\install.esd";
                }
                else
                {
                    MessageBox.Show("Non trovo Install.wim / install.esd");
                    return;
                }
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;

                    var startInfoThi = new ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = "dism /english /Get-WimInfo /WimFile:\"" + installwimpath + "\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = Process.Start(startInfoThi))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();

                        string input = output;

                        int indiceIndex = 0;
                        while ((indiceIndex = input.IndexOf("Index", indiceIndex)) != -1)
                        {
                            int indiceFineValore = input.IndexOfAny(new char[] { '\r', '\n' }, indiceIndex + 6);
                            if (indiceFineValore != -1)
                            {
                                string valoreind = input.Substring(indiceIndex + 6, indiceFineValore - indiceIndex - 6);
                            }

                            indiceIndex = indiceFineValore + 1;
                        }

                        int indiceNome = 1;
                        int primoind = 1;
                        while ((indiceNome = input.IndexOf("Name", indiceNome)) != -1)
                        {
                            int indiceFineValore = input.IndexOfAny(new char[] { '\r', '\n' }, indiceNome + 6);
                            if (indiceFineValore != -1)
                            {
                                string valoreNome = input.Substring(indiceNome + 6, indiceFineValore - indiceNome - 6);

                                comboBox1.Invoke(new Action(() => comboBox1.Items.Add(primoind.ToString() + " - " + valoreNome.Replace(":", ""))));
                                primoind += 1;
                            }

                            indiceNome = indiceFineValore + 1;
                        }
                    }
                }).Start();
            }
        }

        private void Win10Rad_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox6.Show();
            groupBox7.Hide();
            pictureBox7.Hide();
            pictureBox4.Show();
        }

        private void Win11Rad_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox6.Hide();
            groupBox7.Show();
            pictureBox7.Show();
            pictureBox4.Hide();
        }

        private void FormCreaISO_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Controlla se IsoMountLetter è stato assegnato
            if (!string.IsNullOrEmpty(IsoMountLetter))
            {
                ExecuteCommand("Dismount-DiskImage -ImagePath " + "\"" + selectedFile + "\"", false);
            }
        }
    }
}