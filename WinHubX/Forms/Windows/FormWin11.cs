using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WinHubX.Dialog;

namespace WinHubX.Forms.Windows
{
    public partial class FormWin11 : Form
    {
        private Form1 form1;
        private FormWin formWin;
        private NotifyIcon notifyIcon;
        private string linkWin11Arm64;
        private string linkWin11AIO64;
        private string linkWin11Lite64;
        private string linkWin11Stock6424h2;
        private string linkWin11Lite6424h2Pro;
        private string linkWin11Lite6424h2LTSC;

        public FormWin11(FormWin formWin, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formWin = formWin;
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
            LoadJsonLinks();
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

                    linkWin11Arm64 = data["FormWin11"]["11Arm64"]?.ToString();
                    linkWin11AIO64 = data["FormWin11"]["11Stockx64"]?.ToString();
                    linkWin11Lite64 = data["FormWin11"]["11Litex64"]?.ToString();
                    linkWin11Stock6424h2 = data["FormWin11"]["11Stockx6424h2"]?.ToString();
                    linkWin11Lite6424h2Pro = data["FormWin11"]["11Litex6424h2PRO"]?.ToString();
                    linkWin11Lite6424h2LTSC = data["FormWin11"]["11Litex6424h2LTSC"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nel caricamento dei link: {ex.Message}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Windows";
            form1.PnlFormLoader.Controls.Clear();
            formWin = new FormWin(form1)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            form1.PnlFormLoader.Controls.Add(formWin);
            formWin.Show();
        }

        private void btnInfoWin11Lite_Click(object sender, EventArgs e)
        {
            infoWin11Lite(sender, e);
        }

        public static void infoWin11Lite(object sender, EventArgs e)
        {
            #region descrizione LITE

            string description = "Windows 11 LITE\n\n" +
                     "Questa versione di Windows 11 è stata ottimizzata rimuovendo una serie di driver, applicazioni, servizi e componenti, per migliorare le prestazioni del sistema e ridurre l'ingombro di spazio su disco.\n" +
                     "Questa personalizzazione porta ad un sistema operativo più snello e performante, ideale per chi cerca una versione più fluida e leggera rispetto alla versione standard.\n\n" +
                     "Di seguito l'elenco dei servizi e componenti rimossi:\n\n" +
                     "- Anteprima codice a barre Windows\n" +
                     "- App Xbox\n" +
                     "- Assistente vocale\n" +
                     "- Assistenza rapida\n" +
                     "- Chiama\n" +
                     "- Clipchamp\n" +
                     "- Configurazione di Windows Hello\n" +
                     "- Controllo ottico\n" +
                     "- Cortana\n" +
                     "- Dev Home\n" +
                     "- Esperienza shell di Windows\n" +
                     "- Estensioni video HEVC del produttore del dispositivo\n" +
                     "- Feedback Hub\n" +
                     "- Funzionalità per la famiglia di account Microsoft\n" +
                     "- Get Help\n" +
                     "- HEIF Image Extensions\n" +
                     "- Mail and Calendar\n" +
                     "- Microsoft Edge DevTools Client\n" +
                     "- Microsoft Engagement Framework\n" +
                     "- Microsoft Family\n" +
                     "- Microsoft News\n" +
                     "- Microsoft People\n" +
                     "- Microsoft Photos\n" +
                     "- Microsoft Solitaire Collection\n" +
                     "- Microsoft Sticky Notes\n" +
                     "- Microsoft Teams\n" +
                     "- Microsoft To Do\n" +
                     "- Movies & TV\n" +
                     "- MSN Weather\n" +
                     "- Office\n" +
                     "- Outlook for Windows\n" +
                     "- Pacchetto Esperienza Web Windows\n" +
                     "- Power Automate\n" +
                     "- Raw Image Extension\n" +
                     "- Rimozione sicura del dispositivo\n" +
                     "- Schermata di blocco predefinita di Windows\n" +
                     "- Suggerimenti (Informazioni di base)\n" +
                     "- Test ed esami\n" +
                     "- Web Media Extensions\n" +
                     "- Windows Maps\n" +
                     "- Windows Media Player\n" +
                     "- Windows Voice Recorder\n" +
                     "- Xbox Game Bar Plugin\n" +
                     "- Xbox Game Bar\n" +
                     "- Xbox Game Speech Window\n" +
                     "- Xbox Game UI\n" +
                     "- Xbox TCUI\n" +
                     "- Your Phone\n" +
                     "- Accessibilità (Accessibilità)\n" +
                     "- File Offline\n" +
                     "- Gestione quote\n" +
                     "- Input Method Editor (IME) - Consigliato\n" +
                     "- Internet Explorer\n" +
                     "- Pagamenti\n" +
                     "- Server Desktop remoto\n" +
                     "- Telefonia\n" +
                     "- Pulizia voci rimanenti\n" +
                     "- Pulizia cartelle vuote\n";

            #endregion 

            InfoDialog infoWin11Lite = new InfoDialog(description)
            {
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen
            };
            infoWin11Lite.Show();
        }

        private void btnWin11AIO64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("a3e7a1d08a42e68dda47715d33570ffe7fe16840450f1020a341ad40f6bafda6");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                OpenLink(linkWin11AIO64);
            }
        }

        private void btnWin11Lite64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("31f05d2427bb914b3f3e5161820c3a6624eaebee036b7b66512a0b30ab332003");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                OpenLink(linkWin11Lite64);
            }
        }
        private void btnWin11ARM64_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("5416c7aa0c04f1613e51926997d75b1f7be3b30640e3bfdf822f547a96a4123f");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                OpenLink(linkWin11Arm64);
            }
        }
        private void btn_win1124h2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("d95ec65ec06b4036835c7571fe0108159848d2883ef5da3a67e480130b1f5862");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                OpenLink(linkWin11Stock6424h2);
            }
        }
        private void btn24h2ProLite_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("d95ec65ec06b4036835c7571fe0108159848d2883ef5da3a67e480130b1f5862");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                OpenLink(linkWin11Lite6424h2Pro);
            }
        }
        private void btnLTSCLite24h2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Clipboard.SetText("273d9bbcbc8df87eda6ffcb7518cede63f0f9a0e80afa74b1d397010e1032f14");

                notifyIcon.BalloonTipTitle = "SHA256 copiato!";
                notifyIcon.BalloonTipText = "Il codice hash è stato copiato negli appunti.";
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (e.Button == MouseButtons.Left)
            {
                OpenLink(linkWin11Lite6424h2LTSC);
            }
        }
        private void OpenLink(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nell'aprire l'URL: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("URL non disponibile.");
            }
        }
    }
}
