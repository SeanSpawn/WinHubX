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
            string currentVersion = "2.4.2.0";
            try
            {
                var configResponse = await client.GetStringAsync(configUrl);
                dynamic configData = JsonConvert.DeserializeObject(configResponse);
                string updateInfoUrl = configData.Form1.updateInfoUrl;

                var response = await client.GetStringAsync(updateInfoUrl);
                dynamic updateInfo = JsonConvert.DeserializeObject(response);
                string latestVersion = updateInfo.version;

                if (latestVersion != currentVersion && MessageBox.Show($"Nuova versione ({latestVersion}) disponibile. Vuoi aggiornare?", "Aggiornamento Disponibile", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await DownloadAndUpdate(updateInfo.updateUrl, latestVersion);
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
            // Verifica se la chiave esiste e se il valore è impostato a 1
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinHubX"))
            {
                if (key != null)
                {
                    object value = key.GetValue("SettaggiRiavviati");
                    if (value != null && value.ToString() == "1")
                    {
                        // Salta il MessageBox e carica il form Settaggi
                        LoadSettingsForm();
                        return;
                    }
                }
            }

            // Mostra un MessageBox per confermare il riavvio
            var result = MessageBox.Show("È necessario consentire l'accesso a WinHubX nel Registro per apportare le modifiche presenti in questo menù. " +
                                          "Per fare ciò, è necessario il riavvio del PC. Vuoi riavviarlo?",
                                          "Riavvio necessario",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Applica le modifiche al servizio UCPD
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c sc config UCPD start=disabled && schtasks /change /Enable /TN \"\\Microsoft\\Windows\\AppxDeploymentClient\\UCPD velocity\" && shutdown /r /t 0",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                });

                // Imposta la chiave nel registro per indicare che il riavvio è stato effettuato
                using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\WinHubX"))
                {
                    regKey.SetValue("SettaggiRiavviati", 1);
                }

                // Termina l'applicazione (opzionale, se necessario)
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
                            MessageBox.Show("Per entrare in questo menù necessito dell'accesso al registro");
                        }
                    }
                }
                ;
            }
        }

        // Metodo per caricare il form Settaggi
        private void LoadSettingsForm()
        {
            swap_pnlNav(btnSettaggi);

            lblPanelTitle.Text = "Settaggi";
            PnlFormLoader.Controls.Clear();
            FormSettaggi formSettaggi = new(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formSettaggi.FormBorderStyle = FormBorderStyle.None;
            PnlFormLoader.Controls.Add(formSettaggi);
            formSettaggi.Show();
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
                    // Nasconde la finestra e la mostra solo nell'icona della system tray
                    this.Hide();
                    notifyIcon.Visible = true;
                }
                else
                {
                    // Finestra visibile sulla taskbar
                    notifyIcon.Visible = false;
                }
            }
            else
            {
                notifyIcon.Visible = false;
            }
        }

    }
}
