
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;

namespace WinHubX.Dialog.Tools
{
    public partial class DialogMsPCManager : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int borderWidth = 2;

            Color borderColor = Color.Coral;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle borderRectangle = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);

                e.Graphics.DrawRectangle(pen, borderRectangle);
            }
        }

        public DialogMsPCManager()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string configUrl = "https://aimodsitalia.store/ConfigWinHubX/configWinHubX.json";
            string tempFilePath = Path.Combine(Path.GetTempPath(), "microsoft-pc-manager.msixbundle");

            using (WebClient client = new WebClient())
            {
                try
                {
                    // Scarica il JSON di configurazione
                    string json = client.DownloadString(configUrl);

                    // Analizza il JSON per ottenere l'URL di Microsoft PC Manager
                    JObject configData = JObject.Parse(json);
                    string pcManagerUrl = configData["Dialog"]["managersetupmicrosoft"].ToString();

                    // Scarica il file msixbundle
                    client.DownloadFile(pcManagerUrl, tempFilePath);

                    // Esegui l'installazione del pacchetto msixbundle
                    Process installProcess = new Process();
                    installProcess.StartInfo.FileName = "powershell";
                    installProcess.StartInfo.Arguments = $"-Command \"Add-AppxPackage -Path '{tempFilePath}'\"";
                    installProcess.StartInfo.UseShellExecute = false;
                    installProcess.StartInfo.CreateNoWindow = true;
                    installProcess.Start();

                    installProcess.WaitForExit();
                    MessageBox.Show("Installazione completata!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante il download o l'installazione: " + ex.Message);
                }
            }
        }
    }
}
