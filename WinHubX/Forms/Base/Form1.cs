using Microsoft.Win32;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinHubX.Forms.Base;
using WinHubX.Forms.ReinstallaAPP;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinHubX
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly List<Button> bottoni = new();
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;
        private bool isLoading = true;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)HT_CAPTION;
            else
                base.WndProc(ref m);
        }
        private NotifyIcon notifyIcon;
        private ContextMenuStrip trayIconContextMenu;
        public Form1()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            bottoni.AddRange(new[] { btnHome, btnWin, btnOffice, btnSettaggi, btnDebloat, btnCreaISO, btnTools, btnmonitoraggio });
            LoadForm(new FormHome(), btnHome, "Home");
            CheckForUpdatesOnStartup();
            InitializeTrayIcon();
            LanguageManager.LoadTranslations();
        }
        private void ShowFromTray()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            notifyIcon.Visible = false;
        }

        private void InitializeTrayIcon()
        {
            Icon appIcon = Properties.Resources.icoLogoWhite;
            notifyIcon = new NotifyIcon
            {
                Icon = appIcon,
                Visible = false
            };
            trayIconContextMenu = new ContextMenuStrip();
            trayIconContextMenu.Items.Add("Apri", null, (s, e) => ShowFromTray());
            trayIconContextMenu.Items.Add("Esci", null, (s, e) => Application.Exit());
            notifyIcon.ContextMenuStrip = trayIconContextMenu;
            notifyIcon.DoubleClick += (s, e) => ShowFromTray();
        }

        private void swap_pnlNav(Button activeButton)
        {
            foreach (var button in bottoni)
                button.BackColor = (button == activeButton) ? Color.FromArgb(46, 51, 73) : Color.FromArgb(64, 60, 59);

            pnlNav.SetBounds(activeButton.Left, activeButton.Top, pnlNav.Width, activeButton.Height);
        }

        private void LoadForm(Form form, Button button, string title)
        {
            swap_pnlNav(button);
            lblPanelTitle.Text = title;
            PnlFormLoader.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.TopMost = true;
            form.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(form);
            form.Show();
        }

        private async void CheckForUpdatesOnStartup() => await CheckForUpdatesAsync();

        private async Task CheckForUpdatesAsync()
        {
            string configUrl = "https://aimodsitalia.store/ConfigWinHubX/configWinHubX.json";
            string currentVersion = "2.4.2.3";
            try
            {
                var configResponse = await client.GetStringAsync(configUrl);
                dynamic configData = JsonConvert.DeserializeObject(configResponse);
                string updateInfoUrl = configData.Form1.updateInfoUrl;

                var response = await client.GetStringAsync(updateInfoUrl);
                dynamic updateInfo = JsonConvert.DeserializeObject(response);
                string latestVersion = (string)updateInfo.version;
                string updateUrl = (string)updateInfo.updateUrl;
                var releaseNotes = updateInfo.releaseNotes;
                string releaseNotesText = string.Join("\n", releaseNotes);

                if (latestVersion != currentVersion)
                {
                    string titolo = LanguageManager.GetTranslation("Form1", "newversion");
                    string messaggio = string.Format(
                        LanguageManager.GetTranslation("Form1", "newversion_message"),
                        latestVersion, releaseNotesText
                    );

                    DialogResult dialogResult = MessageBox.Show(
                        messaggio,
                        titolo,
                        MessageBoxButtons.YesNo
                    );

                    if (dialogResult == DialogResult.Yes)
                    {
                        await DownloadAndUpdate(updateUrl, latestVersion);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task DownloadAndUpdate(string updateUrl, string version)
        {
            string updateFilePath = Path.Combine(Path.GetTempPath(), $"WinHubX{version}.exe");
            using (var progressForm = new ProgressForm())
            {
                progressForm.Show();
                progressForm.SetMarquee();
                try
                {
                    await DownloadFileWithProgress(updateUrl, updateFilePath, progressForm);
                    string currentExecutablePath = Application.ExecutablePath;
                    File.Move(currentExecutablePath, Path.ChangeExtension(currentExecutablePath, ".old"), true);
                    File.Move(updateFilePath, currentExecutablePath);
                    Process.Start(currentExecutablePath);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressForm.CompleteOperation();
                }
            }
        }

        private async Task DownloadFileWithProgress(string url, string filePath, ProgressForm progressForm)
        {
            // Controlla se bisogna eliminare il file di traduzione
            if (Properties.Settings.Default.elimafiletraduzione)
            {
                string localPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WinHubX", "Lingue", "translations.json");
                if (File.Exists(localPath))
                {
                    try
                    {
                        File.Delete(localPath);
                        Properties.Settings.Default.elimafiletraduzione = false;
                        Properties.Settings.Default.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error:\n{ex.Message}", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var totalBytes = response.Content.Headers.ContentLength.GetValueOrDefault();
            using var contentStream = await response.Content.ReadAsStreamAsync();
            using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);
            var buffer = new byte[8192];
            long bytesRead = 0;
            int read;
            while ((read = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, read);
                progressForm.Invoke(new Action(() =>
                    progressForm.SetStatus("Download...", (int)((bytesRead * 100) / totalBytes))));
            }
        }

        private void btnHome_Click(object sender, EventArgs e) => LoadForm(new FormHome(), btnHome, "Home");
        private void btnWin_Click(object sender, EventArgs e) => LoadForm(new FormWin(this), btnWin, "Windows");
        private void btnOffice_Click(object sender, EventArgs e) => LoadForm(new FormOffice(this), btnOffice, "Office");
        private void btnSettaggi_Click(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinHubX"))
            {
                if (key != null)
                {
                    object value = key.GetValue("SettaggiRiavviati");
                    if (value != null && value.ToString() == "1")
                    {
                        puntodiripristino();
                        return;
                    }
                }
            }
            string titolo = LanguageManager.GetTranslation("Form1", "reboot_title");
            string messaggio = LanguageManager.GetTranslation("Form1", "reboot_message");

            var result = MessageBox.Show(
                messaggio,
                titolo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c sc config UCPD start=disabled && schtasks /change /Enable /TN \"\\Microsoft\\Windows\\AppxDeploymentClient\\UCPD velocity\" && shutdown /r /t 0",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                });

                using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\WinHubX"))
                {
                    regKey.SetValue("SettaggiRiavviati", 1);
                }
                Application.Exit();
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinHubX"))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("SettaggiRiavviati");
                        if (value != null && value.ToString() == "0")
                        {
                            MessageBox.Show("Per entrare in questo men� necessito dell'accesso al registro");
                        }
                    }
                }
            }
        }


        private void puntodiripristino()
        {
            string titolo = LanguageManager.GetTranslation("Form1", "restorepoint_title");
            string messaggio = LanguageManager.GetTranslation("Form1", "restorepoint_message");

            var result = MessageBox.Show(
                messaggio,
                titolo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string script = @"
# Abilita System Restore sull'unit� di sistema
try {
    Enable-ComputerRestore -Drive ""$env:SystemDrive""
} catch {
    Write-Host ""Errore nell'abilitazione del Ripristino configurazione di sistema: $_""
}

# Imposta la frequenza di creazione dei punti di ripristino
$exists = Get-ItemProperty -path ""HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore"" -Name ""SystemRestorePointCreationFrequency"" -ErrorAction SilentlyContinue
if($null -eq $exists) {
    Set-ItemProperty -Path ""HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore"" -Name ""SystemRestorePointCreationFrequency"" -Value 0 -Type DWord -Force
}

# Importa il modulo necessario
try {
    Import-Module Microsoft.PowerShell.Management -ErrorAction Stop
} catch {
    Write-Host ""Errore nel caricamento del modulo: $_""
    return
}

# Controlla se oggi esistono gi� punti di ripristino
try {
    $existingRestorePoints = Get-ComputerRestorePoint | Where-Object { $_.CreationTime.Date -eq (Get-Date).Date }
} catch {
    Write-Host ""Errore nel recupero dei punti di ripristino: $_""
    return
}

# Crea un punto di ripristino se non ce ne sono gi� oggi
if ($existingRestorePoints.Count -eq 0) {
    Checkpoint-Computer -Description ""Punto di ripristino creato da WinHubX"" -RestorePointType MODIFY_SETTINGS
    Write-Host ""Punto di ripristino creato correttamente""
}
";

                    string tempScriptPath = Path.Combine(Path.GetTempPath(), "CreateRestorePoint.ps1");
                    File.WriteAllText(tempScriptPath, script);

                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-ExecutionPolicy Bypass -NoProfile -File \"{tempScriptPath}\"",
                        UseShellExecute = true,
                        Verb = "runas"
                    };

                    Process.Start(psi)?.WaitForExit();
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string regBackupPath = Path.Combine(desktopPath, $"BackupRegistroWinHubX_{DateTime.Now:yyyyMMdd_HHmmss}.reg");

                    ProcessStartInfo regExport = new ProcessStartInfo()
                    {
                        FileName = "reg.exe",
                        Arguments = $"export HKLM \"{regBackupPath}\" /y",
                        UseShellExecute = true,
                        Verb = "runas"
                    };

                    Process.Start(regExport)?.WaitForExit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadForm(new FormSettaggi(this), btnSettaggi, LanguageManager.GetTranslation("Form1", "titoloSett"));
        }

        private void btnDebloat_Click(object sender, EventArgs e) => LoadForm(new FormDebloat(this), btnDebloat, "Debloat");
        private void btnCreaISO_Click(object sender, EventArgs e) =>
            LoadForm(new FormCreaISO(this), btnCreaISO, LanguageManager.GetTranslation("Form1", "titoloCreaISO"));
        private void btnTools_Click(object sender, EventArgs e) => LoadForm(new FormTools(), btnTools, "Tools");
        private void btnmonitoraggio_Click(object sender, EventArgs e) =>
            LoadForm(new FormMonitoraggio(this), btnmonitoraggio, LanguageManager.GetTranslation("Form1", "titoloMon"));
        private void btnReinstallaApp_Click(object sender, EventArgs e) =>
            LoadForm(new FormReinstallaAPP(), btnReinstallaApp, LanguageManager.GetTranslation("Form1", "titoloApp"));

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMnmz_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MinimizeToTray)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (Properties.Settings.Default.MinimizeToTray)
                {
                    this.Hide();
                    if (notifyIcon != null) notifyIcon.Visible = true;
                }
                else
                {
                    if (notifyIcon != null) notifyIcon.Visible = false;
                }
            }
            else
            {
                if (notifyIcon != null) notifyIcon.Visible = false;
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            string languageCode = "it";
            string selectedLanguage = comboBox1.SelectedItem.ToString();
            if (selectedLanguage == "English")
            {
                languageCode = "en";
            }
            Properties.Settings.Default.Language = languageCode;
            Properties.Settings.Default.Save();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
            Controls.Clear();
            InitializeComponent();
            LoadForm(new FormHome(), btnHome, "Home");
            string savedLanguage = Properties.Settings.Default.Language ?? "it";
            LanguageManager.SetLanguage(savedLanguage);
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            if (savedLanguage == "it")
            {
                comboBox1.SelectedItem = "Italiano";
                pictureBox3.Image = Properties.Resources.italias;
            }
            else if (savedLanguage == "en")
            {
                comboBox1.SelectedItem = "English";
                pictureBox3.Image = Properties.Resources.englisj;
            }

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            if (isLoading == false)
            {
                CheckForUpdatesOnStartup();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en")
            {
                comboBox1.SelectedItem = "English";
            }
            else
            {
                comboBox1.SelectedItem = "Italiano";
            }
            CheckForUpdatesOnStartup();
            isLoading = false;
            string savedLanguage = Properties.Settings.Default.Language ?? "it";
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            if (savedLanguage == "it")
            {
                comboBox1.SelectedItem = "Italiano";
                pictureBox3.Image = Properties.Resources.italias;
            }
            else if (savedLanguage == "en")
            {
                comboBox1.SelectedItem = "English";
                pictureBox3.Image = Properties.Resources.englisj;
            }
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string currentLanguage = Properties.Settings.Default.Language ?? "it";
            string newLanguage = currentLanguage == "it" ? "en" : "it";
            Properties.Settings.Default.Language = newLanguage;
            Properties.Settings.Default.Save();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(newLanguage);
            Controls.Clear();
            InitializeComponent();
            LoadForm(new FormHome(), btnHome, "Home");
            LanguageManager.SetLanguage(newLanguage);
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            if (newLanguage == "it")
            {
                comboBox1.SelectedItem = "Italiano";
                pictureBox3.Image = Properties.Resources.italias;
            }
            else if (newLanguage == "en")
            {
                comboBox1.SelectedItem = "English";
                pictureBox3.Image = Properties.Resources.englisj;
            }

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            if (!isLoading)
            {
                CheckForUpdatesOnStartup();
            }
        }
    }
}
