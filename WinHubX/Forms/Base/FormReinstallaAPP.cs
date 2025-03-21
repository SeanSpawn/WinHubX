using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.ReinstallaAPP
{
    public partial class FormReinstallaAPP : Form
    {
        public FormReinstallaAPP()
        {
            InitializeComponent();
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(224, 224, 224); // Colore più chiaro
        }
        static void RegisterAppxPackage(string packageName)
        {
            // Comando PowerShell per ottenere il percorso del manifest del pacchetto AppX
            string getManifestPathCommand = $"Get-AppxPackage -AllUsers '{packageName}' | Select -ExpandProperty InstallLocation";

            string manifestPath = ExecutePowerShellCommand(getManifestPathCommand);

            if (!string.IsNullOrEmpty(manifestPath))
            {
                // Comando PowerShell per registrare il pacchetto AppX utilizzando il percorso del manifest
                string registerCommand = $"Add-AppxPackage -DisableDevelopmentMode -Register '{manifestPath}\\AppXManifest.xml'";

                ExecutePowerShellCommand(registerCommand);
            }
        }

        static void Eseguiinstallstore()
        {
            // Esegui il comando WSReset
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c WSReset -i",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();
            }

            // Attendi 20 secondi
            Thread.Sleep(20000); // 20000 ms = 20 secondi

            // Esegui di nuovo il comando WSReset
            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();
            }

            MessageBox.Show("Lo store è in fase di download... sarà installato a breve.");

            // Attendi 4 secondi
            Thread.Sleep(4000); // 4000 ms = 4 secondi
        }

        static string ExecutePowerShellCommand(string command)
        {
            string output = "";

            using (Process powerShellProcess = new Process())
            {
                powerShellProcess.StartInfo.FileName = "powershell.exe";
                powerShellProcess.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy unrestricted -Command \"{command}\"";
                powerShellProcess.StartInfo.UseShellExecute = false;
                powerShellProcess.StartInfo.CreateNoWindow = true;
                powerShellProcess.StartInfo.RedirectStandardOutput = true;
                powerShellProcess.StartInfo.RedirectStandardError = true;

                powerShellProcess.Start();

                output = powerShellProcess.StandardOutput.ReadToEnd();
                string error = powerShellProcess.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show($"Errore di PowerShell:\n{error}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                powerShellProcess.WaitForExit();
            }

            return output.Trim();
        }

        private void btnAvviaSelezionatiApp_Click(object sender, EventArgs e)
        {
            if (App1.CheckedItems.Contains("Microsoft Store"))
            {
                RegisterAppxPackage("Microsoft.DesktopAppInstaller");
                Eseguiinstallstore();
            }

            if (App1.CheckedItems.Contains("Microsoft Edge"))
            {
                RunPowerShellCommand1("winget install Microsoft.Edge");

                MessageBox.Show("Premi un tasto per uscire...");
                Console.ReadKey();
            }
            if (App1.CheckedItems.Contains("Windows Defender"))
            {
                // Display a warning message
                DialogResult result = MessageBox.Show("Questa operazione richiede un riavvio del PC. Continuare?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                // Check the user's response
                if (result == DialogResult.OK)
                {
                    string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                    string resourcePath = $"{assemblyName}.Resources.PowerRun.exe";

                    // Get the temp path and create the full path for PowerRun.exe
                    string tempPath = Path.GetTempPath();
                    string powerRunPath = Path.Combine(tempPath, "PowerRun.exe");

                    // Check if PowerRun.exe already exists in the temp directory
                    if (!File.Exists(powerRunPath))
                    {
                        // Extract PowerRun.exe to the temp directory
                        using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
                        {
                            using (FileStream fileStream = new FileStream(powerRunPath, FileMode.Create, FileAccess.Write))
                            {
                                resourceStream.CopyTo(fileStream);
                            }
                        }
                    }

                    // Create a list of commands to execute
                    string[] commands = new string[]
                    {
            @"cmd.exe /c reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender"" /v ""DisableAntiSpyware"" /t REG_DWORD /d 0 /f",
            @"cmd.exe /c reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableBehaviorMonitoring"" /t REG_DWORD /d 0 /f",
            @"cmd.exe /c reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableIOAVProtection"" /t REG_DWORD /d 0 /f",
            @"cmd.exe /c reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableOnAccessProtection"" /t REG_DWORD /d 0 /f",
            @"cmd.exe /c reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableRealtimeMonitoring"" /t REG_DWORD /d 0 /f",
            @"cmd.exe /c reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SecurityHealthService"" /v ""Start"" /t REG_DWORD /d 2 /f",
            @"cmd.exe /c reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend"" /v ""Start"" /t REG_DWORD /d 2 /f"
                    };

                    // Execute each command using PowerRun
                    foreach (var command in commands)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = powerRunPath,
                            Arguments = command,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true
                        };

                        using (Process process = new Process())
                        {
                            process.StartInfo = startInfo;
                            process.Start();
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();

                            // Handle output or error if needed
                            if (process.ExitCode != 0)
                            {

                            }
                        }
                    }
                }
            }

            static void RunPowerShellCommand1(string command)
            {
                try
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };
                    using (var process = Process.Start(startInfo))
                    {
                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show($"Errore: {error}");
                        }
                        if (!string.IsNullOrEmpty(output))
                        {
                            MessageBox.Show($"Output: {output}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Si è verificata un'eccezione: {ex.Message}");
                }
            }

            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Funzione per analizzare i risultati di winget search
        private void ParseSearchResults(string output)
        {
            // Pulizia precedente
            dataGridViewResults.Rows.Clear();
            dataGridViewResults.Columns.Clear();

            // Aggiunta colonne al DataGridView
            if (dataGridViewResults.Columns.Count == 0)
            {
                dataGridViewResults.Columns.Add("Name", "Name");
                dataGridViewResults.Columns.Add("Id", "Id");
                dataGridViewResults.Columns.Add("Version", "Version");
                dataGridViewResults.Columns.Add("Source", "Source");
                dataGridViewResults.Columns.Add("Origine", "Origine");
            }

            // Leggi riga per riga l'output
            string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                // Regex per catturare i valori
                var match = Regex.Match(line, @"^(.+?)\s{2,}(.+?)\s{2,}(.+?)\s{2,}(.+?)\s{2,}(.*)$");

                if (match.Success)
                {
                    string name = match.Groups[1].Value.Trim();
                    string id = match.Groups[2].Value.Trim();
                    string version = match.Groups[3].Value.Trim();
                    string source = match.Groups[4].Value.Trim();
                    string origine = match.Groups[5].Value.Trim();

                    // Aggiunta della riga
                    dataGridViewResults.Rows.Add(name, id, version, source, origine);
                }
            }

            // Mostra un messaggio se non ci sono risultati
            if (dataGridViewResults.Rows.Count == 0)
            {
                MessageBox.Show("Nessun risultato trovato.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InstallPackage(string packageId)
        {
            try
            {
                txtOutput.Text = $"Installazione di: {packageId}...\r\n";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = $"install {packageId} --silent --accept-package-agreements",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string output = reader.ReadToEnd();
                        txtOutput.AppendText(output);
                    }
                }

                MessageBox.Show("Installazione completata.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'installazione: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string packageId = dataGridViewResults.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                InstallPackage(packageId);
            }
        }

        private void btnInstalla_Click(object sender, EventArgs e)
        {
            // Verifica che sia selezionata una riga nel DataGridView
            if (dataGridViewResults.SelectedRows.Count > 0)
            {
                // Estrae l'ID del pacchetto dalla riga selezionata
                string packageId = dataGridViewResults.SelectedRows[0].Cells["Id"].Value.ToString();
                if (!string.IsNullOrEmpty(packageId))
                {
                    InstallPackage(packageId);
                }
            }
            else
            {
                MessageBox.Show("Seleziona un pacchetto da installare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpgradePackage(string packageId)
        {
            try
            {
                txtOutput.Text = $"Aggiornamento di: {packageId}...\r\n";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = $"upgrade {packageId} --silent --accept-package-agreements",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string output = reader.ReadToEnd();
                        txtOutput.AppendText(output);
                    }
                }

                MessageBox.Show("Aggiornamento completato.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'aggiornamento: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Aggiorna_Click(object sender, EventArgs e)
        {
            // Verifica che sia selezionata una riga nel DataGridView
            if (dataGridViewResults.SelectedRows.Count > 0)
            {
                // Estrae l'ID del pacchetto dalla riga selezionata
                string packageId = dataGridViewResults.SelectedRows[0].Cells["Id"].Value.ToString();
                if (!string.IsNullOrEmpty(packageId))
                {
                    UpgradePackage(packageId);
                }
            }
            else
            {
                MessageBox.Show("Seleziona un pacchetto da aggiornare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnSearch_Click_1(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Inserisci un termine di ricerca.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Esegui la ricerca in modo asincrono
                string result = await Task.Run(() => RunWingetSearch(query));

                // Elabora i risultati della ricerca
                ParseSearchResults(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string RunWingetSearch(string query)
        {
            try
            {
                // Esegue 'winget search' in un processo separato
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = $"search \"{query}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        return reader.ReadToEnd();  // Restituisce i risultati della ricerca
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore durante l'esecuzione della ricerca: {ex.Message}");
            }
        }

        private void FormReinstallaAPP_Load(object sender, EventArgs e)
        {
            // Verifica se Winget è installato nel percorso previsto
            string wingetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Microsoft\WindowsApps\winget.exe");

            if (File.Exists(wingetPath))
            {
                // Winget è trovato nel percorso installato
                label1.Text = "Winget è già installato.";
                panel1.BackColor = Color.Green;
            }
            else
            {
                // Winget non trovato, avvia l'installazione
                label1.Text = "Winget non trovato. Verrà installato ora.";
                panel1.BackColor = Color.Red;
                Task.Delay(3000);
                InstallWinGet();
            }

            // Aggiungi Winget al PATH se non presente
            string windowsAppsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Microsoft\WindowsApps");
            string envPath = Environment.GetEnvironmentVariable("PATH");

            if (!envPath.Contains(windowsAppsPath, StringComparison.OrdinalIgnoreCase))
            {
                Environment.SetEnvironmentVariable("PATH", envPath + ";" + windowsAppsPath, EnvironmentVariableTarget.User);
                label1.Text = "Percorso di Winget aggiunto al PATH.";
            }
        }

        private void InstallWinGet()
        {
            string[] urls =
            {
        "https://aka.ms/getwinget",
        "https://aka.ms/Microsoft.VCLibs.x64.14.00.Desktop.appx",
        "https://github.com/microsoft/microsoft-ui-xaml/releases/download/v2.8.6/Microsoft.UI.Xaml.2.8.x64.appx"
    };

            string[] localFiles =
            {
        "Microsoft.DesktopAppInstaller_8wekyb3d8bbwe.msixbundle",
        "Microsoft.VCLibs.x64.14.00.Desktop.appx",
        "Microsoft.UI.Xaml.2.8.x64.appx"
    };

            using (WebClient webClient = new WebClient())
            {
                for (int i = 0; i < urls.Length; i++)
                {
                    try
                    {
                        label1.Text = $"Scaricando {localFiles[i]}...";
                        webClient.DownloadFile(urls[i], localFiles[i]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Errore durante il download di {localFiles[i]}: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            foreach (string file in localFiles)
            {
                try
                {
                    AddAppxPackage(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore durante l'installazione di {file}: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddAppxPackage(string packagePath)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-Command Start-Process powershell -ArgumentList 'Add-AppxPackage -Path \"{packagePath}\"' -Verb RunAs",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (!string.IsNullOrEmpty(output))
            {
                label1.Text = output;
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Errore durante l'installazione: {error}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
