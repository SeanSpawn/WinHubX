﻿using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO.Compression;
using System.Management;
using System.Reflection;
using WinHubX.Dialog;
using WinHubX.Forms.Settaggi;

namespace WinHubX.Forms.Base
{
    public partial class FormSettaggi : Form
    {
        private Form1 form1;
        private string wsa11x64;
        private string wsa11arm64;
        private string wsa10x64;
        public FormSettaggi(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            LoadJsonLinks();
        }

        private void btnPrivacy_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows Privacy";
            form1.PnlFormLoader.Controls.Clear();
            FormPrivacy formPrivacy = new FormPrivacy(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formPrivacy.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formPrivacy);
            formPrivacy.Show();
        }

        private void btnUtility_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Utility";
            form1.PnlFormLoader.Controls.Clear();
            FormUtility formUtility = new FormUtility(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formUtility.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formUtility);
            formUtility.Show();
        }

        private void btnDefender_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows Defender";
            form1.PnlFormLoader.Controls.Clear();
            FormDefender formDefender = new FormDefender(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formDefender.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formDefender);
            formDefender.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows Update";
            form1.PnlFormLoader.Controls.Clear();
            FormUpdate formUpdate = new FormUpdate(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formUpdate.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formUpdate);
            formUpdate.Show();
        }

        private void btnRipristinaSO_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = LanguageManager.GetTranslation("FormSettaggi", "restoreos");
            form1.PnlFormLoader.Controls.Clear();
            FormRipristinoSO formRipristinoSO = new FormRipristinoSO(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formRipristinoSO.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formRipristinoSO);
            formRipristinoSO.Show();
        }

        private async void LoadJsonLinks()
        {
            string url = "https://aimodsitalia.store/ConfigWinHubX/configWinHubX.json";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    JObject data = JObject.Parse(json);

                    wsa11x64 = data["WSA"]["win11x64"]?.ToString();
                    wsa11arm64 = data["WSA"]["win11arm64"]?.ToString();
                    wsa10x64 = data["WSA"]["win10x64"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAttivaWSA_Click(object sender, EventArgs e)
        {
            string systemType = GetSystemType();
            string downloadUrl = "";
            string zipFileName = "";
            if (systemType.Contains("Windows 11"))
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    downloadUrl = wsa11x64;
                    zipFileName = "WSAwin11x64.zip";
                }
                else
                {
                    downloadUrl = wsa11arm64;
                    zipFileName = "WSAwin11arm64.zip";
                }
            }
            else if (systemType.Contains("Windows 10"))
            {
                downloadUrl = wsa10x64;
                zipFileName = "WSAwin10x64.zip";
            }

            if (!string.IsNullOrEmpty(downloadUrl))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(downloadUrl) { UseShellExecute = true });
                    MessageBox.Show(LanguageManager.GetTranslation("FormSettaggi", "savezip"));
                    string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    string zipFilePath = Path.Combine(downloadsPath, zipFileName);
                    string extractPath = Path.Combine(Path.GetTempPath(), "WSA");

                    if (File.Exists(zipFilePath))
                    {
                        ZipFile.ExtractToDirectory(zipFilePath, extractPath, true);
                        string batFilePath = Path.Combine(extractPath, "Run.bat");
                        if (File.Exists(batFilePath))
                        {
                            var process = Process.Start(new ProcessStartInfo(batFilePath) { UseShellExecute = true });
                            process?.WaitForExit();
                        }
                        else
                        {
                            MessageBox.Show(LanguageManager.GetTranslation("FormSettaggi", "runbatnotfound"), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(LanguageManager.GetTranslation("FormSettaggi", "filenotfound"), "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(LanguageManager.GetTranslation("FormSettaggi", "downloadlinknotfound"), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Mostra la finestra di dialogo PacMan
            PacManDialog pacManDialog = new PacManDialog
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            pacManDialog.ShowDialog();
        }

        private string GetSystemType()
        {
            string osName = "";
            string osArchitecture = Environment.Is64BitOperatingSystem ? "x64" : "ARM64";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                osName = os["Caption"].ToString();
                break;
            }

            return $"{osName} {osArchitecture}";
        }

        private void btnAttivaWSL_Click(object sender, EventArgs e)
        {
            try
            {
                string assemblyName1 = Assembly.GetExecutingAssembly().GetName().Name;
                string resourcePath1 = $"{assemblyName1}.Resources.WinHubXWSL.ps1";
                byte[] exeBytes1 = LoadEmbeddedResource1(resourcePath1);
                string ps1FilePath1 = Path.Combine(Path.GetTempPath(), "WinHubXWSL.ps1");
                File.WriteAllBytes(ps1FilePath1, exeBytes1);

                StartPowerShell1(ps1FilePath1);
            }
            finally { }
        }

        private byte[] LoadEmbeddedResource1(string resourcePath)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException($"Error: {resourcePath}");
                }
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        private void StartPowerShell1(string scriptFilePath)
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

        private void btnPersonalizzazione_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = LanguageManager.GetTranslation("FormSettaggi", "customization");
            form1.PnlFormLoader.Controls.Clear();
            FormPersonalizzazione formPersonalizzazione = new FormPersonalizzazione(this, form1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formPersonalizzazione.FormBorderStyle = FormBorderStyle.None;
            form1.PnlFormLoader.Controls.Add(formPersonalizzazione);
            formPersonalizzazione.Show();
        }
    }
}
