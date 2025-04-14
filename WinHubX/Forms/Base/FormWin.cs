using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net;
using WinHubX.Forms.Windows;

namespace WinHubX
{
    public partial class FormWin : Form
    {
        private Form1 form1;

        public FormWin(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void btnWin7_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows 7";
            form1.PnlFormLoader.Controls.Clear();
            FormWin7 formWin7 = new FormWin7(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formWin7.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formWin7);
            formWin7.Show();
        }

        private void btnWin8dot1_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows 8.1";
            form1.PnlFormLoader.Controls.Clear();
            FormWin8Dot1 formWin8Dot1 = new FormWin8Dot1(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formWin8Dot1.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formWin8Dot1);
            formWin8Dot1.Show();
        }

        private void btnWin10_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows 10";
            form1.PnlFormLoader.Controls.Clear();
            FormWin10 formWin10 = new FormWin10(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formWin10.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formWin10);
            formWin10.Show();
        }

        private void btnWin11_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows 11";
            form1.PnlFormLoader.Controls.Clear();
            FormWin11 formWin11 = new FormWin11(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formWin11.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formWin11);
            formWin11.Show();
        }

        private async void btnAttivaWin_Click(object sender, EventArgs e)
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
                        primaryURL = jsonObject["FormWin"]["attivatorewin"].ToString();
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
                byte[] scriptBytes = Properties.Resources.TSforge_Activation;

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


        public static async Task ExecuteScriptFromUrl(string url)
        {
            try
            {
                // Scarica il contenuto del file CMD
                using (HttpClient client = new HttpClient())
                {
                    var scriptContent = await client.GetStringAsync(url);
                    string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "HWID_Activation.cmd");

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

        private async void btnCambioEdizione_Click(object sender, EventArgs e)
        {
            string tempScript = Path.Combine(Path.GetTempPath(), "tempScript.bat");
            string logFile = Path.Combine(Path.GetTempPath(), "ScriptExecution.log");
            string configUrl = "https://aimodsitalia.store/ConfigWinHubX/configWinHubX.json";
            string primaryURL = string.Empty;

            // Eliminare il file temporaneo se esiste
            if (File.Exists(tempScript))
            {
                File.Delete(tempScript);
            }

            try
            {

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (HttpClient client = new HttpClient())
                {
                    var jsonResponse = await client.GetStringAsync(configUrl);
                    var jsonObject = JObject.Parse(jsonResponse);
                    primaryURL = jsonObject["FormWin"]["cambiowin"].ToString();
                }
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(primaryURL, tempScript);
                }

                // Eseguire il file scaricato con cmd
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c \"{tempScript}\"",
                    UseShellExecute = true,
                    CreateNoWindow = false
                };

                using (Process process = Process.Start(startInfo))
                {

                }

                File.AppendAllText(logFile, $"Esecuzione completata per lo script: {tempScript}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                File.AppendAllText(logFile, ex.Message);
            }
        }

        private void btnWinLive_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://devuploads.com/ucpfdcbe6bl3",
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
}
