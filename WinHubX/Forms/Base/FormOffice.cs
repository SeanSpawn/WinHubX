using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using WinHubX.Dialog;
using WinHubX.Forms.Personalizzazione_office;

namespace WinHubX
{
    public partial class FormOffice : Form
    {
        private Form1 form1;
        private NotifyIcon notifyIcon;
        private string link32_2019, link64_2019, fileName_2019, sha256_2019;
        private string link32_2021, link64_2021, fileName_2021, sha256_2021;
        private string link32_2024, link64_2024, fileName_2024, sha256_2024;
        private string link32_365, link64_365, fileName_365, sha256_365;

        public FormOffice(Form1 form1)
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
            this.form1 = form1;
        }

        #region Link
        private async Task LoadOfficeLinks()
        {
            string jsonUrl = "https://aimodsitalia.store/ConfigWinHubX/configWinHubX.json";

            try
            {
                var jsonData = await GetJsonDataAsync(jsonUrl);

                // Office 2019
                link32_2019 = jsonData["Office2019"]["Officex32"]?.ToString();
                link64_2019 = jsonData["Office2019"]["Officex64"]?.ToString();
                fileName_2019 = jsonData["Office2019"]["Offline2019"]?.ToString();
                sha256_2019 = jsonData["Office2019"]["sha2562019"]?.ToString();

                // Office 2021
                link32_2021 = jsonData["Office2021"]["Officex32"]?.ToString();
                link64_2021 = jsonData["Office2021"]["Officex64"]?.ToString();
                fileName_2021 = jsonData["Office2021"]["Offline2021"]?.ToString();
                sha256_2021 = jsonData["Office2021"]["sha2562021"]?.ToString();

                // Office 2024
                link32_2024 = jsonData["Office2024"]["Officex32"]?.ToString();
                link64_2024 = jsonData["Office2024"]["Officex64"]?.ToString();
                fileName_2024 = jsonData["Office2024"]["Offline2024"]?.ToString();
                sha256_2024 = jsonData["Office2024"]["sha2562024"]?.ToString();

                // Office 365
                link32_365 = jsonData["Office365"]["Officex32"]?.ToString();
                link64_365 = jsonData["Office365"]["Officex64"]?.ToString();
                fileName_365 = jsonData["Office365"]["Offline365"]?.ToString();
                sha256_365 = jsonData["Office365"]["sha256365"]?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nel caricamento del JSON: {ex.Message}");
            }
        }

        private async Task<JObject> GetJsonDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                return JObject.Parse(response);
            }
        }

        #endregion



        #region Office2019

        private void btn2019Online_MouseUp(object sender, MouseEventArgs e)
        {
            OfficeDialog officeDialog = new OfficeDialog()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            officeDialog.openDialog(lblOffice2019, link32_2019, link64_2019);
            officeDialog.ShowDialog();
        }

        private void btn2019Offline_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Clipboard.SetText(sha256_2019);
                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = fileName_2019,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
                }
            }
        }

        #endregion

        #region Office2021

        private void btn2021Online_MouseUp(object sender, MouseEventArgs e)
        {
            OfficeDialog officeDialog = new OfficeDialog()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            officeDialog.openDialog(lblOffice2021, link32_2021, link64_2021);
            officeDialog.ShowDialog();
        }

        private void btn2021Offline_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Clipboard.SetText(sha256_2021);
                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = fileName_2021,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
                }
            }
        }
        #endregion

        #region Office365

        private void btn365Online_MouseUp(object sender, MouseEventArgs e)
        {
            OfficeDialog officeDialog = new OfficeDialog()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            officeDialog.openDialog(lblOffice365, link32_365, link64_365);
            officeDialog.ShowDialog();
        }

        private void btn365Offline_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Clipboard.SetText(sha256_365);
                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = fileName_365,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
                }
            }
        }

        #endregion

        #region Office2024


        private void btn2024Online_MouseUp(object sender, MouseEventArgs e)
        {
            OfficeDialog officeDialog = new OfficeDialog()
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            officeDialog.openDialog(lblOffice2024, link32_2024, link64_2024);
            officeDialog.ShowDialog();
        }

        private void btn2024Offline_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Clipboard.SetText(sha256_2024);
                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = fileName_2024,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
                }
            }
        }

        #endregion

        #region AttivaOffice
        private async void btnAttivaOffice_Click(object sender, EventArgs e)
        {
            string configUrl = "https://aimodsitalia.store/ConfigWinHubX/configWinHubX.json";
            string primaryURL = string.Empty;

            // Imposta la sicurezza TLS per la connessione
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                // Controlla la connessione a Internet
                if (IsInternetAvailable())
                {
                    // Ottieni il contenuto JSON da URL
                    using (HttpClient client = new HttpClient())
                    {
                        var jsonResponse = await client.GetStringAsync(configUrl);
                        var jsonObject = JObject.Parse(jsonResponse);
                        primaryURL = jsonObject["AttivatoreOffice"]["primaryURL"].ToString();
                    }

                    // Avvia il comando HWID_Activation.cmd dal link ottenuto
                    await ExecuteScriptFromUrl(primaryURL);
                }
                else
                {
                    // Se non c'è connessione, usa la risorsa locale
                    MessageBox.Show("Connessione Internet non disponibile. Utilizzo del file di attivazione locale.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ExtractAndExecuteLocalScript();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'attivazione: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task ExecuteScriptFromUrl(string url)
        {
            try
            {
                // Scarica il contenuto del file CMD
                using (HttpClient client = new HttpClient())
                {
                    var scriptContent = await client.GetStringAsync(url);
                    string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Ohook_Activation_AIO.cmd");

                    // Salva il file temporaneamente
                    System.IO.File.WriteAllText(tempFilePath, scriptContent);

                    // Esegui il file CMD
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = tempFilePath,
                        UseShellExecute = true,
                        Verb = "runas" // Esegui come amministratore se necessario
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'esecuzione del comando: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsInternetAvailable()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync("https://www.google.com").Result;
                    return result.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        private void ExtractAndExecuteLocalScript()
        {
            try
            {
                // Ottieni il percorso Documenti dell'utente
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string scriptPath = Path.Combine(documentsPath, "TSforge_Activation.cmd");

                // Estrai il file dalla risorsa e salvalo in Documenti
                byte[] scriptBytes = Properties.Resources.TSforge_Activation_Office;

                // Scrivi i byte su un file nella cartella Documenti
                File.WriteAllBytes(scriptPath, scriptBytes);

                // Esegui il file CMD estratto
                Process.Start(new ProcessStartInfo
                {
                    FileName = scriptPath,
                    UseShellExecute = true,
                    Verb = "runas" // Esegui come amministratore se necessario
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'estrazione o l'esecuzione del file locale: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btn2021Online_Click(object sender, EventArgs e)
        {

        }

        private void btnScrubber_Click(object sender, EventArgs e)
        {
            try
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                string resourcePath = $"{assemblyName}.Resources.WinHubXOfficeScrubber.ps1";
                byte[] exeBytes = LoadEmbeddedResource(resourcePath);
                string ps1FilePath = Path.Combine(Path.GetTempPath(), "WinHubXOfficeScrubber.ps1");

                // Scrivi il file PowerShell nella cartella temporanea
                File.WriteAllBytes(ps1FilePath, exeBytes);

                // Controlla se il file è stato scritto correttamente
                if (File.Exists(ps1FilePath))
                {
                    StartPowerShell(ps1FilePath);
                }
                else
                {
                    MessageBox.Show($"Il file {ps1FilePath} non è stato estratto correttamente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Gestione delle eccezioni
                MessageBox.Show($"Si è verificato un errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] LoadEmbeddedResource(string resourcePath)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException($"Could not find embedded resource: {resourcePath}");
                }
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        private void StartPowerShell(string scriptFilePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptFilePath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
            }
        }

        private void btnPersonalizzaOffice_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Personalizzazione Office";
            form1.PnlFormLoader.Controls.Clear();
            PersonalizzazioneOffice formPersonalizzazioneOffice = new PersonalizzazioneOffice(form1, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formPersonalizzazioneOffice.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formPersonalizzazioneOffice);
            formPersonalizzazioneOffice.Show();
        }

        private async void FormOffice_Load(object sender, EventArgs e)
        {
            await LoadOfficeLinks();
        }
    }
}
