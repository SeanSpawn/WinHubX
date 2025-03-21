using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;

namespace WinHubX.Dialog.Tools
{
    public partial class DialogRufus4Lite : Form
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

        public DialogRufus4Lite()
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
            string tempFilePath = Path.Combine(Path.GetTempPath(), "RufusLite.exe");

            using (WebClient client = new WebClient())
            {
                try
                {
                    // Scarica il JSON di configurazione
                    string json = client.DownloadString(configUrl);

                    // Analizza il JSON per ottenere l'URL di RufusLite
                    JObject configData = JObject.Parse(json);
                    string rufusLiteUrl = configData["Dialog"]["RufusLite"].ToString();

                    // Scarica il file eseguibile RufusLite
                    client.DownloadFile(rufusLiteUrl, tempFilePath);

                    // Esegui l'applicazione RufusLite
                    Process.Start(tempFilePath);

                    MessageBox.Show("RufusLite avviato con successo!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante il download o l'avvio di RufusLite: " + ex.Message);
                }
            }
        }
    }
}
