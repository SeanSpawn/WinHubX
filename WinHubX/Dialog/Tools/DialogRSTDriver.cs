using System.Net;

namespace WinHubX.Dialog.Tools
{
    public partial class DialogRSTDriver : Form
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

        private SaveFileDialog saveFileDialog;

        public DialogRSTDriver()
        {
            InitializeComponent();

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Zip Files (*.zip)|*.zip";
            saveFileDialog.Title = "Salva Driver RST";
            saveFileDialog.FileName = "DriverRST.zip";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            string jsonUrl = "https://aimodsitalia.store/ConfigWinHubX/configWinHubX.json";
            string driverRstUrl = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Effettua la richiesta al JSON online
                    var response = await client.GetStringAsync(jsonUrl);
                    // Analizza il JSON per trovare il link nella sezione "Dialog" > "DriverRST"
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                    driverRstUrl = json.Dialog.DriverRST;

                    // Controlla se è stato trovato il link
                    if (string.IsNullOrEmpty(driverRstUrl))
                    {
                        MessageBox.Show("Link non trovato nella sezione 'DriverRST'.");
                        return;
                    }
                }

                // Apri il dialogo di salvataggio file
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = "DriverRST.zip"; // Nome predefinito del file
                    saveFileDialog.Filter = "ZIP Files (*.zip)|*.zip";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string destPath = saveFileDialog.FileName;

                        // Scarica il file dal link
                        using (var client = new WebClient())
                        {
                            await client.DownloadFileTaskAsync(new Uri(driverRstUrl), destPath);
                        }

                        MessageBox.Show("Download completato.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il download: {ex.Message}");
            }
        }
    }
}
