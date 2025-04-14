using Microsoft.Win32;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinHubX.Forms.Base;
using WinHubX.Forms.ReinstallaAPP;

namespace WinHubX
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly List<Button> bottoni = new();
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)HT_CAPTION;
            else
                base.WndProc(ref m);
        }
        private NotifyIcon notifyIcon; // Dichiara la variabile a livello di classe
        private ContextMenuStrip trayIconContextMenu;
        public Form1()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            bottoni.AddRange(new[] { btnHome, btnWin, btnOffice, btnSettaggi, btnDebloat, btnCreaISO, btnTools, btnmonitoraggio });
            LoadForm(new FormHome(), btnHome, "Home");
            CheckForUpdatesOnStartup();
            InitializeTrayIcon();
        }
        private void ShowFromTray()
        {
            // Logica per mostrare la finestra principale
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            notifyIcon.Visible = false; // Nascondi l'icona del tray quando la finestra è visibile
        }

        private void InitializeTrayIcon()
        {
            Icon appIcon = Properties.Resources.icoLogoWhite;

            // Inizializza l'icona del system tray
            notifyIcon = new NotifyIcon
            {
                Icon = appIcon,  // Imposta l'icona personalizzata
                Visible = false   // Rendi l'icona invisibile finché non viene minimizzata
            };

            // Aggiungi un menu contestuale per l'icona
            trayIconContextMenu = new ContextMenuStrip();
            trayIconContextMenu.Items.Add("Apri", null, (s, e) => ShowFromTray());
            trayIconContextMenu.Items.Add("Esci", null, (s, e) => Application.Exit());

            // Assegna il ContextMenuStrip all'icona
            notifyIcon.ContextMenuStrip = trayIconContextMenu;

            // Gestisci il doppio clic sull'icona
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
            string currentVersion = "2.4.2.2";
            try
            {
                var configResponse = await client.GetStringAsync(configUrl);
                dynamic configData = JsonConvert.DeserializeObject(configResponse);
                string updateInfoUrl = configData.Form1.updateInfoUrl;

                var response = await client.GetStringAsync(updateInfoUrl);
                dynamic updateInfo = JsonConvert.DeserializeObject(response);
                string latestVersion = (string)updateInfo.version;
                string updateUrl = (string)updateInfo.updateUrl;

                // Ora 'releaseNotes' è già un array, non è necessario fare il ToObject
                var releaseNotes = updateInfo.releaseNotes;
                string releaseNotesText = string.Join("\n", releaseNotes);

                if (latestVersion != currentVersion)
                {
                    // Mostra prima le release notes e poi la domanda per l'aggiornamento
                    DialogResult dialogResult = MessageBox.Show($"Nuova versione ({latestVersion}) disponibile.\n\nChangelog:\n{releaseNotesText}\n\nVuoi aggiornare?",
                                                                "Aggiornamento Disponibile",
                                                                MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        await DownloadAndUpdate(updateUrl, latestVersion);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il controllo degli aggiornamenti: {ex.Message}", "Errore");
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
                    MessageBox.Show($"Errore durante l'aggiornamento: {ex.Message}", "Errore");
                }
                finally
                {
                    progressForm.CompleteOperation();
                }
            }
        }

        private async Task DownloadFileWithProgress(string url, string filePath, ProgressForm progressForm)
        {
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
                bytesRead += read;
                progressForm.Invoke(new Action(() => progressForm.SetStatus("Download in corso...", (int)((bytesRead * 100) / totalBytes))));
            }
        }

        private void btnHome_Click(object sender, EventArgs e) => LoadForm(new FormHome(), btnHome, "Home");
        private void btnWin_Click(object sender, EventArgs e) => LoadForm(new FormWin(this), btnWin, "Windows");
        private void btnOffice_Click(object sender, EventArgs e) => LoadForm(new FormOffice(this), btnOffice, "Office");
        private void btnSettaggi_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Vuoi creare un punto di ripristino prima di accedere alle impostazioni?",
                                         "Punto di Ripristino",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string script = @"
# Abilita System Restore sull'unità di sistema
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

# Controlla se oggi esistono già punti di ripristino
try {
    $existingRestorePoints = Get-ComputerRestorePoint | Where-Object { $_.CreationTime.Date -eq (Get-Date).Date }
} catch {
    Write-Host ""Errore nel recupero dei punti di ripristino: $_""
    return
}

# Crea un punto di ripristino se non ce ne sono già oggi
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
                        Verb = "runas" // Esegui come amministratore
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
                    MessageBox.Show("Errore durante la creazione del punto di ripristino:\n" + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadForm(new FormSettaggi(this), btnSettaggi, "Settaggi");
        }

        private void btnDebloat_Click(object sender, EventArgs e) => LoadForm(new FormDebloat(this), btnDebloat, "Debloat");
        private void btnCreaISO_Click(object sender, EventArgs e) => LoadForm(new FormCreaISO(this), btnCreaISO, "Crea ISO");
        private void btnTools_Click(object sender, EventArgs e) => LoadForm(new FormTools(), btnTools, "Tools");
        private void btnmonitoraggio_Click(object sender, EventArgs e) => LoadForm(new FormMonitoraggio(this), btnmonitoraggio, "Monitoraggio");
        private void btnReinstallaApp_Click(object sender, EventArgs e) => LoadForm(new FormReinstallaAPP(), btnReinstallaApp, "Installa App");
        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMnmz_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MinimizeToTray)
            {
                // Minimizza nella system tray
                this.Hide(); // La finestra non è visibile, ma l'icona della system tray sarà visibile
                notifyIcon.Visible = true; // Assicurati che l'icona del tray sia visibile
            }
            else
            {
                // Minimizza sulla taskbar
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
    }
}
