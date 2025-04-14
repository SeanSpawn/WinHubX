using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO.Compression;
using System.Management;
using WinHubX.Forms.Base;


namespace WinHubX.Forms.Settaggi
{
    public partial class FormPersonalizzazione : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        private string tempFolder = Path.Combine(Path.GetTempPath(), "WinHubX");
        private bool isSSD = false;
        private int totalSteps = 0;
        public FormPersonalizzazione(FormSettaggi formSettaggi, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formSettaggi = formSettaggi;
            LoadPcSpec();
        }
        private async void LoadPcSpec()
        {
            await Task.Run(() =>
            {
                string driveType = "Unknown";
                string systemDriveLetter = GetSystemDrive();
                bool isDriveDetected = false;

                try
                {
                    using (var searcher = new ManagementObjectSearcher("SELECT MediaType, DeviceID, Model FROM Win32_DiskDrive"))
                    {
                        foreach (ManagementObject drive in searcher.Get())
                        {
                            string deviceID = drive["DeviceID"]?.ToString();
                            if (deviceID == null) continue;

                            string model = drive["Model"]?.ToString() ?? string.Empty;
                            if (model.Contains("NVMe", StringComparison.OrdinalIgnoreCase))
                            {
                                driveType = "SSD (NVMe)";
                                isSSD = true;
                                isDriveDetected = true;
                                break;
                            }

                            using (var partitionSearcher = new ManagementObjectSearcher(
                                $"ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{deviceID}'}} WHERE AssocClass=Win32_DiskDriveToDiskPartition"))
                            {
                                foreach (ManagementObject partition in partitionSearcher.Get())
                                {
                                    var driveLetter = GetDriveLetter(partition);
                                    if (driveLetter == systemDriveLetter)
                                    {
                                        var mediaType = drive["MediaType"]?.ToString();
                                        if (mediaType == "Fixed hard disk media")
                                        {
                                            driveType = "HDD";
                                            isSSD = false;
                                        }
                                        else if (mediaType == "Solid state drive")
                                        {
                                            driveType = "SSD";
                                            isSSD = true;
                                        }

                                        isDriveDetected = true;
                                        break;
                                    }
                                }
                            }

                            if (isDriveDetected) break;
                        }
                    }
                }
                catch
                {
                    // Ignoriamo l'eccezione, lasceremo che il tipo di disco rimanga "Unknown"
                }

                if (!isDriveDetected)
                {
                    // Mostra il mini-form per selezionare il tipo di disco
                    Invoke(new Action(() =>
                    {
                        using (var selectorForm = new DiskTypeSelectorForm())
                        {
                            if (selectorForm.ShowDialog() == DialogResult.OK)
                            {
                                driveType = selectorForm.SelectedDriveType;
                                isSSD = driveType.Contains("SSD", StringComparison.OrdinalIgnoreCase);
                            }
                        }
                    }));
                }

                ulong ramBytes = new ComputerInfo().TotalPhysicalMemory;
                string ramSizeGB = $"{ramBytes / (1024 * 1024 * 1024)} GB RAM";

                // Aggiorna le Label sul thread principale
                Invoke(new Action(() =>
                {
                    label3.Text = driveType;
                    label5.Text = ramSizeGB;
                }));
            });
        }

        // Funzione per ottenere la lettera del disco di sistema
        private string GetDriveLetter(ManagementObject partition)
        {
            try
            {
                var driveLetters = partition.GetPropertyValue("DeviceID")?.ToString();
                if (driveLetters != null)
                {
                    var path = driveLetters.Split('\\');
                    if (path.Length > 0)
                        return path[path.Length - 1].Substring(0, 1);
                }
            }
            catch
            {
                // In caso di errore restituisci una stringa vuota
            }
            return string.Empty;
        }

        // Funzione per ottenere la lettera del disco di sistema da una chiave di registro
        private string GetSystemDrive()
        {
            string systemDrive = "C"; // Default
            try
            {
                // Tentiamo prima di leggere dalla chiave di registro per sistemi a 64 bit
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (key != null)
                    {
                        object systemRoot = key.GetValue("SystemRoot");
                        if (systemRoot != null)
                        {
                            string path = systemRoot.ToString();
                            systemDrive = path.Substring(0, 1); // Estrae la lettera del disco, ad esempio C:
                        }
                    }
                }

                // Se non siamo riusciti a trovare la chiave, proviamo con la versione a 32 bit su sistemi a 64 bit
                if (systemDrive == "C") // Se non è stato trovato un risultato, cerchiamo nel percorso WOW6432Node
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion"))
                    {
                        if (key != null)
                        {
                            object systemRoot = key.GetValue("SystemRoot");
                            if (systemRoot != null)
                            {
                                string path = systemRoot.ToString();
                                systemDrive = path.Substring(0, 1); // Estrae la lettera del disco
                            }
                        }
                    }
                }
            }
            catch
            {
                // In caso di errore, lascia C come predefinito
            }
            return systemDrive;
        }

        private async void btnAvviaSelezionati_Click(object sender, EventArgs e)
        {
            totalSteps = 0;

            // Lista dei tuoi pannelli
            List<Panel> pannelli = new List<Panel>
    {
        panel1, panel3, panel4, panel5, panel6,
        panel8, panel9, panel10, panel11, panel12, panel13
    };

            // Conta quanti RadioButton sono selezionati
            foreach (var pannello in pannelli)
            {
                foreach (Control control in pannello.Controls)
                {
                    if (control is RadioButton radioButton && radioButton.Checked)
                    {
                        totalSteps++;
                    }
                }
            }

            if (totalSteps == 0)
            {
                totalSteps = 1;  // Imposta almeno 1 passo
            }

            progressBar1.Maximum = totalSteps;
            progressBar1.Value = 0;

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void DisabilitaEndTask()
        {
            try
            {
                using (RegistryKey currentUserKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32))
                {
                    using (RegistryKey taskbarSettings = currentUserKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\TaskbarDeveloperSettings"))
                    {
                        taskbarSettings?.SetValue("TaskbarEndTask", 0, RegistryValueKind.DWord);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un errore durante la disabilitazione del pulsante 'Termina attività': " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AbiliaEndTask()
        {
            try
            {
                using (RegistryKey currentUserKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32))
                {
                    using (RegistryKey taskbarSettings = currentUserKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\TaskbarDeveloperSettings"))
                    {
                        taskbarSettings?.SetValue("TaskbarEndTask", 1, RegistryValueKind.DWord);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un errore durante l'abilitazione del pulsante 'Termina attività': " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AvviaProcessoRimuoviCopilot()
        {
            try
            {
                // Scrive nel registro a 32 bit, anche su sistemi a 64 bit
                using (RegistryKey localMachineKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                using (RegistryKey windowsCopilotLM = localMachineKey.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsCopilot"))
                {
                    windowsCopilotLM?.SetValue("TurnOffWindowsCopilot", 1, RegistryValueKind.DWord);
                }

                using (RegistryKey currentUserKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32))
                {
                    using (RegistryKey windowsCopilotCU = currentUserKey.CreateSubKey(@"Software\Policies\Microsoft\Windows\WindowsCopilot"))
                    {
                        windowsCopilotCU?.SetValue("TurnOffWindowsCopilot", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey explorerAdvanced = currentUserKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
                    {
                        explorerAdvanced?.SetValue("ShowCopilotButton", 0, RegistryValueKind.DWord);
                    }
                }

                // Comando DISM per rimuovere Copilot
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c dism /online /remove-package /package-name:Microsoft.Windows.Copilot",
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AvviaProcessoAggiungiCopilot()
        {
            try
            {
                // Ripristina chiavi nel registro a 32 bit
                using (RegistryKey localMachineKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                using (RegistryKey windowsCopilotLM = localMachineKey.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsCopilot"))
                {
                    windowsCopilotLM?.SetValue("TurnOffWindowsCopilot", 0, RegistryValueKind.DWord);
                }

                using (RegistryKey currentUserKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32))
                {
                    using (RegistryKey windowsCopilotCU = currentUserKey.CreateSubKey(@"Software\Policies\Microsoft\Windows\WindowsCopilot"))
                    {
                        windowsCopilotCU?.SetValue("TurnOffWindowsCopilot", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey explorerAdvanced = currentUserKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"))
                    {
                        explorerAdvanced?.SetValue("ShowCopilotButton", 1, RegistryValueKind.DWord);
                    }
                }

                // Comando DISM per aggiungere nuovamente il pacchetto (se disponibile)
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c dism /online /add-package /package-name:Microsoft.Windows.Copilot",
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AvviaProcessoAbilitaecall()
        {
            try
            {
                // Configura il processo
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Usa cmd.exe per aprire una finestra del terminale
                    Arguments = "/c dism /online /enable-feature /featurename:Recall", // Esegui il comando
                    Verb = "runas", // Esegui come amministratore
                    UseShellExecute = true, // Consente l'esecuzione in una nuova finestra
                    CreateNoWindow = false, // Mostra la finestra del terminale
                    WindowStyle = ProcessWindowStyle.Normal // Mostra la finestra in modo normale
                };

                // Avvia il processo
                Process.Start(processInfo); // Non è necessario l'uso di using qui, poiché vogliamo che la finestra rimanga aperta
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AvviaProcessoRimuovirecall()
        {
            try
            {
                // Configura il processo
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Usa cmd.exe per aprire una finestra del terminale
                    Arguments = "/c dism /online /disable-feature /featurename:Recall", // Esegui il comando
                    Verb = "runas", // Esegui come amministratore
                    UseShellExecute = true, // Consente l'esecuzione in una nuova finestra
                    CreateNoWindow = false, // Mostra la finestra del terminale
                    WindowStyle = ProcessWindowStyle.Normal // Mostra la finestra in modo normale
                };

                // Avvia il processo
                Process.Start(processInfo); // Non è necessario l'uso di using qui, poiché vogliamo che la finestra rimanga aperta
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si è verificato un errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AvviaProcessoOttimizzaRicerca()
        {
            try
            {
                // Imposta il valore della chiave di registro FolderType in entrambe le viste di registro 64 e 32 bit
                SetStringRegistryValue(@"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\Bags\AllFolders\Shell", "FolderType", "NotSpecified", RegistryView.Registry64);
                SetStringRegistryValue(@"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\Bags\AllFolders\Shell", "FolderType", "NotSpecified", RegistryView.Registry32);
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni
                MessageBox.Show($"Errore: {ex.Message}", "FolderType");
            }
        }

        private void AvviaProcessoDisabilitaSuggeriti()
        {
            try
            {
                // Percorso della chiave di registro
                string registryPath = @"SOFTWARE\Policies\Microsoft\Windows\Explorer";
                // Nome del valore da eliminare
                string valueName = "DisableSearchBoxSuggestions";

                // Elimina il valore specificato in entrambe le viste di registro
                DeleteRegistryValue(registryPath, valueName, RegistryView.Registry64);
                DeleteRegistryValue(registryPath, valueName, RegistryView.Registry32);
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni
                MessageBox.Show($"Errore: {ex.Message}", "DisableSearchBoxSuggestions");
            }
        }

        private void AvviaProcessoAbilitaSuggeriti()
        {
            try
            {
                // Percorso della chiave di registro
                string registryPath = @"SOFTWARE\Policies\Microsoft\Windows\Explorer";
                // Nome del valore da impostare
                string valueName = "DisableSearchBoxSuggestions";
                // Nuovo valore da impostare
                string newValue = "1";

                // Imposta il valore nella chiave di registro in entrambe le viste di registro
                SetStringRegistryValue(registryPath, valueName, newValue, RegistryView.Registry64);
                SetStringRegistryValue(registryPath, valueName, newValue, RegistryView.Registry32);
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni
                MessageBox.Show($"Errore: {ex.Message}", "DisableSearchBoxSuggestions");
            }
        }
        private void AvviaProcessoDisabilitaRicercaInternet()
        {
            try
            {
                // Percorso della chiave di registro
                string registryPath = @"SOFTWARE\Policies\Microsoft\Windows\Explorer";
                // Nome del valore da impostare
                string valueName = "DisableSearchBoxSuggestions";
                // Nuovo valore da impostare
                string newValue = "1";

                // Imposta il valore nella chiave di registro in entrambe le viste di registro
                SetStringRegistryValue(registryPath, valueName, newValue, RegistryView.Registry64);
                SetStringRegistryValue(registryPath, valueName, newValue, RegistryView.Registry32);
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni
                MessageBox.Show($"Errore: {ex.Message}", "DisableSearchBoxSuggestions");
            }
        }

        private async Task AvviaProcessoConRegFile(string regFileName)
        {
            string jsonUrl = "https://aimodsitalia.store/ConfigWinHubX/configWinHubX.json";
            string zipFileUrl = await OttieniUrlRegFile(jsonUrl);

            if (!string.IsNullOrEmpty(zipFileUrl))
            {
                string zipFilePath = Path.Combine(tempFolder, "resources.zip");

                // Scarica il file ZIP
                await ScaricaFile(zipFileUrl, zipFilePath);
                await Task.Delay(1000); // Attesa di 1 secondo per garantire che il file sia stato scaricato

                // Estrai il file .reg corrispondente
                string regFilePath = EstraiFileReg(zipFilePath, regFileName);
                if (regFilePath != null)
                {
                    // Esegui il file .reg
                    EseguiFileReg(regFilePath);
                    await Task.Delay(3000); // Attesa di 1 secondo per garantire che il file .reg sia stato eseguito
                }
                else
                {
                    throw new FileNotFoundException($"File .reg '{regFileName}' non trovato nel file ZIP.");
                }

                // Elimina il file ZIP
                if (File.Exists(zipFilePath))
                {
                    File.Delete(zipFilePath);
                    await Task.Delay(3000); // Attesa di 1 secondo dopo l'eliminazione del file ZIP
                }

                // Elimina la cartella temporanea, se è vuota
                if (Directory.Exists(tempFolder))
                {
                    try
                    {
                        Directory.Delete(tempFolder, true); // Elimina la cartella e tutto il suo contenuto
                        await Task.Delay(3000); // Attesa di 1 secondo dopo l'eliminazione della cartella
                    }
                    catch (IOException)
                    {
                        throw new IOException("Errore nell'eliminazione della cartella temporanea.");
                    }
                }
            }
            else
            {
                throw new Exception("URL del file ZIP non trovato.");
            }
        }

        private async Task<string> OttieniUrlRegFile(string jsonUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(jsonUrl);
                var json = JObject.Parse(response);

                // Restituisce l'URL del file ZIP dalla parte "PersonaTastoDestro"
                return json["PersonaTastoDestro"]["PersoTastoDestro"].ToString();
            }
        }

        private async Task ScaricaFile(string url, string filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                Directory.CreateDirectory(tempFolder); // Crea la cartella temporanea se non esiste
                using (var response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode(); // Verifica che la richiesta sia andata a buon fine
                    using (var fs = new FileStream(filePath, FileMode.CreateNew))
                    {
                        await response.Content.CopyToAsync(fs); // Scrive il contenuto del file ZIP
                    }
                }
            }
        }

        private string EstraiFileReg(string zipFilePath, string regFileName)
        {
            string extractedRegFilePath = Path.Combine(tempFolder, regFileName);

            // Estrae solo il file .reg specificato dal file ZIP
            using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.Equals(regFileName, StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(extractedRegFilePath, true); // Estrae il file .reg
                        return extractedRegFilePath; // Restituisce il percorso del file estratto
                    }
                }
            }

            return null; // Ritorna null se il file non è stato trovato
        }

        private void EseguiFileReg(string filePath)
        {
            // Percorsi per le versioni di regedit
            string regedit64Path = @"C:\Windows\System32\regedit.exe"; // Regedit per 64 bit
            string regedit32Path = @"C:\Windows\SysWOW64\regedit.exe"; // Regedit per 32 bit

            try
            {
                // Esegui il file .reg con regedit64
                System.Diagnostics.Process.Start(regedit64Path, $"/s \"{filePath}\"");

            }
            catch (Exception)
            {

            }

            try
            {
                // Esegui il file .reg con regedit32
                System.Diagnostics.Process.Start(regedit32Path, $"/s \"{filePath}\"");

            }
            catch (Exception)
            {

            }
        }


        private void AvviaProcessoDestroDefault()
        {
            string registryPath = @"SOFTWARE\CLASSES\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}";

            // Eliminare dal registro a 32 bit
            try
            {
                using (RegistryKey key32 = Registry.CurrentUser.OpenSubKey(registryPath, true))
                {
                    if (key32 != null)
                    {
                        Registry.CurrentUser.DeleteSubKeyTree(registryPath, false);

                    }
                    else
                    {

                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (Exception)
            {

            }

            // Eliminare dal registro a 64 bit
            try
            {
                using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey subKey64 = key64.OpenSubKey(registryPath, true))
                    {
                        if (subKey64 != null)
                        {
                            key64.DeleteSubKeyTree(registryPath, false);

                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (Exception)
            {

            }
        }

        private void AvviaProcessoDestroLegacy()
        {
            string registryPath = @"SOFTWARE\CLASSES\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";

            // Aggiungere al registro a 32 bit
            try
            {
                using (RegistryKey key32 = Registry.CurrentUser.CreateSubKey(registryPath))
                {
                    if (key32 != null)
                    {
                        // Imposta il valore predefinito
                        key32.SetValue("", "", RegistryValueKind.String); // Valore predefinito vuoto

                    }
                    else
                    {

                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (Exception)
            {

            }

            // Aggiungere al registro a 64 bit
            try
            {
                using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).CreateSubKey(registryPath))
                {
                    if (key64 != null)
                    {
                        // Imposta il valore predefinito
                        key64.SetValue("", "", RegistryValueKind.String); // Valore predefinito vuoto

                    }
                    else
                    {

                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (Exception)
            {

            }
        }

        private void AvviaProcessoMostraSecondi()
        {
            UpdateRegistryValue(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowSecondsInSystemClock",
                1,
                RegistryValueKind.DWord
            );
        }

        private void AvviaProcessoMostraDataSecondi()
        {
            UpdateRegistryValue(
                @"Control Panel\International",
                "sShortDate",
                "ddd dd/MM/yyyy",
                RegistryValueKind.String
            );

            UpdateRegistryValue(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowSecondsInSystemClock",
                1,
                RegistryValueKind.DWord
            );
        }

        private void AvviaProcessoOrologioStandard()
        {
            UpdateRegistryValue(
                @"Control Panel\International",
                "sShortDate",
                "dd/MM/yyyy",
                RegistryValueKind.String
            );

            UpdateRegistryValue(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowSecondsInSystemClock",
                0,
                RegistryValueKind.DWord
            );
        }

        private void AvviaProcessoNascondiOraData()
        {
            UpdateRegistryValue(
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowSystrayDateTimeValueName",
                0,
                RegistryValueKind.DWord
            );
        }

        private void AvviaProcessoMostraOraData()
        {
            UpdateRegistryValue(
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                "ShowSystrayDateTimeValueName",
                1,
                RegistryValueKind.DWord
            );
        }

        private static void UpdateRegistryValue(string registryPath, string valueName, object newValue, RegistryValueKind valueKind)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath, writable: true))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, newValue, valueKind);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private static void RestartExplorer()
        {
            foreach (var process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }
            System.Diagnostics.Process.Start("explorer.exe");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Settaggi";
            form1.PnlFormLoader.Controls.Clear();
            formSettaggi = new FormSettaggi(form1)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            form1.PnlFormLoader.Controls.Add(formSettaggi);
            formSettaggi.Show();
        }

        private void btn_resetselezione_Click(object sender, EventArgs e)
        {
            // Deselect all RadioButtons
            radio_mostrasecondi.Checked = false;
            radio_mostradatasecondi.Checked = false;
            radio_orologiostandard.Checked = false;
            radio_nascondioradata.Checked = false;
            radio_mostraoradata.Checked = false;
            radio_destrolegacy.Checked = false;
            radio_destrodefault.Checked = false;
            radio_apricmd.Checked = false;
            radio_eliminaapricmd.Checked = false;
            radio_apripowershell.Checked = false;
            radio_eliminapowershell.Checked = false;
            radio_disabilitaricercainternet.Checked = false;
            radio_abilitasuggeriti.Checked = false;
            radio_disabilitasuggeriti.Checked = false;
            radio_ottimizzaricerca.Checked = false;
            radio_abilitarecall.Checked = false;
            radio_disabilitarecall.Checked = false;
            radio_ottimizzawindows.Checked = false;
            radio_attivafx.Checked = false;
            radio_disattivafx.Checked = false;
            radio_ripristinaottimizzazionewin.Checked = false;
            radio_disacopilot.Checked = false;
            radio_abilicopilot.Checked = false;
            radio_abilitaendtask.Checked = false;
            radio_disabilitaendtask.Checked = false;

            try
            {
                // Try to delete the registry value
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\WinHubX\Personalizzazione", true);
            }
            catch (Exception)
            {

            }
        }

        private bool GetCheckboxState(string itemName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinHubX\\Personalizzazione"))
            {
                if (key != null)
                {
                    object value = key.GetValue(itemName);
                    if (value != null)
                    {
                        return (int)value == 1;
                    }
                }
            }
            return false;
        }

        private void FormPersonalizzazione_Load(object sender, EventArgs e)
        {
            radio_mostrasecondi.Checked = GetCheckboxState("MostraSecondi");
            radio_mostradatasecondi.Checked = GetCheckboxState("MostraDataSecondi");
            radio_orologiostandard.Checked = GetCheckboxState("OrologioStandard");
            radio_nascondioradata.Checked = GetCheckboxState("NascondiOraData");
            radio_mostraoradata.Checked = GetCheckboxState("MostraOraData");
            radio_destrolegacy.Checked = GetCheckboxState("DestroLegacy");
            radio_destrodefault.Checked = GetCheckboxState("DestroDefault");
            radio_apricmd.Checked = GetCheckboxState("ApriCMD");
            radio_eliminaapricmd.Checked = GetCheckboxState("EliminaApriCMD");
            radio_apripowershell.Checked = GetCheckboxState("ApriPowerShell");
            radio_eliminapowershell.Checked = GetCheckboxState("EliminaPowerShell");
            radio_ottimizzawindows.Checked = GetCheckboxState("OttimizzaWindows");
            radio_ripristinaottimizzazionewin.Checked = GetCheckboxState("RipristinaOttimizzazioneWin");
            radio_attivafx.Checked = GetCheckboxState("AttivaFX");
            radio_disattivafx.Checked = GetCheckboxState("DisattivaFx");
            radio_disabilitaricercainternet.Checked = GetCheckboxState("DisabilitaRicercaInternet");
            radio_abilitasuggeriti.Checked = GetCheckboxState("AbilitaSuggeriti");
            radio_disabilitasuggeriti.Checked = GetCheckboxState("DisabilitaSuggeriti");
            radio_ottimizzaricerca.Checked = GetCheckboxState("OttimizzaRicerca");
            radio_abilitarecall.Checked = GetCheckboxState("AbilitaRecall");
            radio_disabilitarecall.Checked = GetCheckboxState("DisabilitaRecall");
            radio_abilicopilot.Checked = GetCheckboxState("AbilitaCopilot");
            radio_disacopilot.Checked = GetCheckboxState("DisablitaCopilot");
            radio_abilitaendtask.Checked = GetCheckboxState("AbiliEndTask");
            radio_disabilitaendtask.Checked = GetCheckboxState("DisabilEndTask");
        }


        public void SetStringRegistryValue(string path, string valueName, string value, RegistryView view)
        {
            using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, view))
            {
                using (RegistryKey key = baseKey.OpenSubKey(path, writable: true))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, value, RegistryValueKind.String);
                    }
                    else
                    {

                    }
                }
            }
        }

        public void DeleteRegistryValue(string path, string valueName, RegistryView view)
        {
            using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view))
            {
                using (RegistryKey key = baseKey.OpenSubKey(path, writable: true))
                {
                    if (key != null)
                    {
                        try
                        {
                            // Elimina il valore specificato
                            key.DeleteValue(valueName, throwOnMissingValue: false);
                        }
                        catch (ArgumentException)
                        {
                            // Il valore non esiste; non fare nulla
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        public void DeleteRegistryKey(string registryPath, string valueName, RegistryView view)
        {
            // Apri la chiave di registro con la vista specificata
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view).OpenSubKey(registryPath, writable: true))
            {
                if (key != null)
                {
                    // Elimina il valore specificato
                    key.DeleteValue(valueName, throwOnMissingValue: false);
                }
                else
                {

                }
            }
        }

        public void RemoveRegistryKey(string registryPath, string subKeyName, RegistryView view)
        {
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, view).OpenSubKey(registryPath, writable: true))
            {
                if (key != null)
                {
                    // Elimina la chiave 'command' se esiste
                    if (key.OpenSubKey(subKeyName) != null)
                    {
                        key.DeleteSubKey(subKeyName, throwOnMissingSubKey: false);
                    }

                    // Elimina la chiave principale se non contiene altre sottocchiavi
                    if (key.SubKeyCount == 0)
                    {
                        RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, view).DeleteSubKey(registryPath, throwOnMissingSubKey: false);
                    }
                }
                else
                {

                }
            }
        }

        public void SetRegistryValues(string registryPath, string[] valueNames, string[] values, string commandValue, RegistryView view)
        {
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, view).OpenSubKey(registryPath, writable: true))
            {
                if (key != null)
                {
                    // Imposta i valori standard
                    for (int i = 0; i < valueNames.Length; i++)
                    {
                        key.SetValue(valueNames[i], values[i], RegistryValueKind.String);
                    }

                    // Imposta il valore della chiave command
                    using (RegistryKey commandKey = key.CreateSubKey("command"))
                    {
                        if (commandKey != null)
                        {
                            commandKey.SetValue("", commandValue, RegistryValueKind.String);
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool opzioneSelezionata = false;
            int currentStep = 0;
            if (radio_mostrasecondi.Checked)
            {
                AvviaProcessoMostraSecondi();
                SetCheckboxState("MostraSecondi", radio_mostrasecondi.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_mostradatasecondi.Checked)
            {
                AvviaProcessoMostraDataSecondi();
                SetCheckboxState("MostraDataSecondi", radio_mostradatasecondi.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_orologiostandard.Checked)
            {
                AvviaProcessoOrologioStandard();
                SetCheckboxState("OrologioStandard", radio_orologiostandard.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_nascondioradata.Checked)
            {
                AvviaProcessoNascondiOraData();
                SetCheckboxState("NascondiOraData", radio_nascondioradata.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_mostraoradata.Checked)
            {
                AvviaProcessoMostraOraData();
                SetCheckboxState("MostraOraData", radio_mostraoradata.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_destrolegacy.Checked)
            {
                AvviaProcessoDestroLegacy();
                SetCheckboxState("DestroLegacy", radio_destrolegacy.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_destrodefault.Checked)
            {
                AvviaProcessoDestroDefault();
                SetCheckboxState("DestroDefault", radio_destrodefault.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_apricmd.Checked)
            {
                AvviaProcessoConRegFile("cmdsi.reg");
                SetCheckboxState("ApriCMD", radio_apricmd.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_eliminaapricmd.Checked)
            {
                AvviaProcessoConRegFile("cmdno.reg");
                SetCheckboxState("EliminaApriCMD", radio_eliminaapricmd.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_apripowershell.Checked)
            {
                AvviaProcessoConRegFile("powershellsi.reg");
                SetCheckboxState("ApriPowershell", radio_apripowershell.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_eliminapowershell.Checked)
            {
                AvviaProcessoConRegFile("powershellno.reg");
                SetCheckboxState("EliminaPowershell", radio_eliminapowershell.Checked);
  
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_ottimizzawindows.Checked)
            {
                if (isSSD)
                {
                    // Se è un SSD o SSD NVMe, esegui ottimizzazione per SSD
                    AvviaProcessoConRegFile("ottimizzazioni_ssd.reg");
                }
                else
                {
                    // Se è un HDD, esegui ottimizzazione per HDD
                    AvviaProcessoConRegFile("ottimizzazioni_hdd.reg");
                }
                SetCheckboxState("OttimazzazioneWindows", radio_ottimizzawindows.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_disattivafx.Checked)
            {
                AvviaProcessoConRegFile("disabilita_tutti_visual_fx.reg");
                SetCheckboxState("DisattivaFx", radio_disattivafx.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_attivafx.Checked)
            {
                AvviaProcessoConRegFile("abilita_visual_fx.reg");
                SetCheckboxState("AttivaFx", radio_attivafx.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_ripristinaottimizzazionewin.Checked)
            {
                AvviaProcessoConRegFile("ripristina_impostazioni_windows.reg");
                SetCheckboxState("RipristinaOttimizzazioneWin", radio_ripristinaottimizzazionewin.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_disabilitaricercainternet.Checked)
            {
                AvviaProcessoDisabilitaRicercaInternet();
                SetCheckboxState("DisabilitaRicercaInternet", radio_disabilitaricercainternet.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_abilitasuggeriti.Checked)
            {
                AvviaProcessoAbilitaSuggeriti();
                SetCheckboxState("AbilitaSuggeriti", radio_abilitasuggeriti.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_disabilitasuggeriti.Checked)
            {
                AvviaProcessoDisabilitaSuggeriti();
                SetCheckboxState("DisabilitaSuggeriti", radio_disabilitasuggeriti.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_ottimizzaricerca.Checked)
            {
                AvviaProcessoOttimizzaRicerca();
                SetCheckboxState("OttimizzaRicerca", radio_ottimizzaricerca.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_abilitarecall.Checked)
            {
                AvviaProcessoAbilitaecall();
                SetCheckboxState("AbilitaRecall", radio_abilitarecall.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_disabilitarecall.Checked)
            {
                AvviaProcessoRimuovirecall();
                SetCheckboxState("DisabilitaRecall", radio_disabilitarecall.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_abilicopilot.Checked)
            {
                AvviaProcessoAggiungiCopilot();
                SetCheckboxState("AbilitaCopilot", radio_abilicopilot.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_disacopilot.Checked)
            {
                AvviaProcessoRimuoviCopilot();
                SetCheckboxState("DisablitaCopilot", radio_disacopilot.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_abilitaendtask.Checked)
            {
                AbiliaEndTask();
                SetCheckboxState("AbiliEndTask", radio_disacopilot.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            if (radio_disabilitaendtask.Checked)
            {
                DisabilitaEndTask();
                SetCheckboxState("DisabilEndTask", radio_disacopilot.Checked);
                opzioneSelezionata = true;
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = Math.Min(e.ProgressPercentage, progressBar1.Maximum);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            RestartExplorer();
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetCheckboxState(string itemName, bool isChecked)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\WinHubX\\Personalizzazione"))
            {
                key.SetValue(itemName, isChecked ? 1 : 0, RegistryValueKind.DWord);
            }
        }
    }
}
