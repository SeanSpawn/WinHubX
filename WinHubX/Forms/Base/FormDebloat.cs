﻿using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using WinHubX.Forms.DebloatAvanzato;
using WinHubX.Forms.ReinstallaAPP;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHubX.Forms.Base
{
    public partial class FormDebloat : Form
    {
        private Form1 form1;
        private List<string> appxNames = new List<string>();
        private Dictionary<string, string> appNameMappings = new Dictionary<string, string>();
        private Dictionary<string, string> imageUrls = new Dictionary<string, string>();
        private int totalSteps = 0;

        public FormDebloat(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.HorizontalScroll.Maximum = 0;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.AutoScrollMinSize = new Size(0, 0);
            InizializzaDati();
        }

        private void InizializzaDati()
        {
            Task.Run(async () =>
            {
                Task.WhenAll(CaricaAppNameMappings(), CaricaImmaginiApp()).Wait();
                CaricaAppxPackages();
            });
        }

        private class ImmagineData
        {
            public string Nome { get; set; }
            public string ID { get; set; }
            public string ImmagineUrl { get; set; }
        }
        private async Task CaricaImmaginiApp()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("https://raw.githubusercontent.com/MrNico98/ImageDebloat/refs/heads/main/ImmaginiDebloat.json");
                    var immaginiList = JsonSerializer.Deserialize<List<ImmagineData>>(json);

                    if (immaginiList != null)
                    {
                        foreach (var item in immaginiList)
                        {
                            string chiave = item.ID ?? item.Nome; // Usa "ID" se presente, altrimenti "Nome"
                            if (!string.IsNullOrEmpty(chiave) && !string.IsNullOrEmpty(item.ImmagineUrl))
                            {
                                imageUrls[chiave] = item.ImmagineUrl;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CaricaAppNameMappings()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("https://raw.githubusercontent.com/MrNico98/ImageDebloat/refs/heads/main/AssociazioniDebloat.json");
                    appNameMappings = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CaricaAppxPackages()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-Command \"Get-AppxPackage | Where-Object { $_.SignatureKind -eq 'Store' } | Select-Object -ExpandProperty Name\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    appxNames = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                this.Invoke(new Action(() =>
                {
                    AggiornaUI(appxNames);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AggiornaUI(List<string> filteredApps)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (string appName in filteredApps)
            {
                AggiungiElemento(appName);
            }
        }

        private void AggiungiElemento(string nomeTecnico)
        {
            string nomeLeggibile = OttieniNomeLeggibile(nomeTecnico);
            string imgUrl = imageUrls.ContainsKey(nomeLeggibile) ? imageUrls[nomeLeggibile] : null;
            if (string.IsNullOrEmpty(imgUrl) && imageUrls.ContainsKey("Generale"))
            {
                imgUrl = imageUrls["Generale"];
            }

            int panelWidth = (flowLayoutPanel1.ClientSize.Width / 2) - 20;
            int panelHeight = 50;

            Panel panel = new Panel
            {
                Width = panelWidth,
                Height = panelHeight,
                Padding = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3),
                BackColor = Color.FromArgb(37, 38, 39)
            };

            PictureBox pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 30,
                Height = 30,
                Left = 5,
                Top = (panelHeight - 30) / 2
            };

            if (!string.IsNullOrEmpty(imgUrl))
            {
                try
                {
                    pictureBox.Load(imgUrl);
                }
                catch
                {
                    pictureBox.Image = null;
                }
            }

            Label lblNome = new Label
            {
                Text = nomeLeggibile,
                AutoSize = false,
                Width = panelWidth - 80,
                Height = 30,
                Left = 40,
                Top = (panelHeight - 30) / 2,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.White,
                Font = new Font("Arial", 9, FontStyle.Bold),
                Padding = new Padding(0, 5, 0, 0)
            };

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(lblNome, nomeTecnico);

            CheckBox checkBox = new CheckBox
            {
                AutoSize = true,
                Left = panelWidth - 25,
                Top = (panelHeight - 15) / 2
            };

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(lblNome);
            panel.Controls.Add(checkBox);
            flowLayoutPanel1.Controls.Add(panel);
        }

        private string OttieniNomeLeggibile(string nomeTecnico)
        {
            if (appNameMappings.ContainsKey(nomeTecnico))
            {
                return appNameMappings[nomeTecnico];
            }
            return nomeTecnico.Replace("Microsoft.", "").Replace("_", " ");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string filtro = textBox1.Text.Trim().ToLower();
                List<string> risultati = appxNames
                    .Where(app => OttieniNomeLeggibile(app).ToLower().Contains(filtro))
                    .ToList();

                AggiornaUI(risultati);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.SelectionStart = 0;
                AggiornaUI(appxNames);
            }
        }
        private void btnAvviaSelezionatiDebloat_Click(object sender, EventArgs e)
        {
            totalSteps = 0;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();
                    Label lblNome = panel.Controls.OfType<Label>().FirstOrDefault();
                    if (checkBox != null && checkBox.Checked && lblNome != null)
                    {
                        totalSteps++;
                    }
                }
            }
            if (totalSteps == 0)
            {
                totalSteps = 1;
            }
            progressBar1.Maximum = totalSteps;
            progressBar1.Value = 0;
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void RimuoviApp(string nomeApp)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments = $"-Command \"Get-AppxPackage -allusers {nomeApp} | Remove-AppxPackage\""
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RimuoviProvisioning(string nomeApp)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments = $"-Command \"Get-AppxProvisionedPackage -Online | Where-Object {{ $_.DisplayName -like '*{nomeApp}*' }} | Remove-AppxProvisionedPackage -Online\""
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante la rimozione del provisioning di {nomeApp}: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDebloatAuto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Sei sicuro di voler eseguire questa operazione?",
                                                  "Conferma",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string powerShellCommand = GetPowerShellCommand();
                if (powerShellCommand != null)
                {
                    ExecutePowerShellCommand(powerShellCommand);
                    string messaggio = LanguageManager.GetTranslation("Global", "modifichesuccesso");

                    MessageBox.Show(
                        messaggio,
                        "WinHubX",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private string? GetPowerShellCommand()
        {
            int version = Environment.OSVersion.Version.Major;
            if (version < 10)
            {
                return null;
            }

            string[] commonAppsToRemove = {
        "Microsoft.VP9VideoExtensions", "Microsoft.WebMediaExtensions",
        "Microsoft.WebpImageExtension", "Microsoft.Windows.ShellExperienceHost",
        "Microsoft.VCLibs*",
        "Microsoft.WindowsStore", "Microsoft.XboxIdentityProvider", "Microsoft.HEIFImageExtension",
        "Microsoft.UI.Xaml*"
    };

            string notepad = version == 11 ? "| Notepad" : "";

            string command = $"$ErrorActionPreference = 'SilentlyContinue'; Get-AppxPackage -AllUsers | Where-Object {{$_.name -notmatch '{string.Join("|", commonAppsToRemove)}'{notepad}}} | Remove-AppxPackage";

            return command;
        }

        private void ExecutePowerShellCommand(string command)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-command \"{command}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Verb = "runas"
            };

            using (var process = Process.Start(processStartInfo))
            {
                if (process != null)
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();
                }
            }
        }
        private void btnDebloatAvanzato_Click(object sender, EventArgs e)
        {
            // Crea una nuova istanza di FormDebloatAvanzato
            FormDebloatAvanzato formDebloat = new FormDebloatAvanzato();

            // Mostra il form
            formDebloat.Show();
        }

        private void btnServizi_Click(object sender, EventArgs e)
        {
            FormServizi formServizi = new FormServizi();

            // Mostra il form
            formServizi.Show();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int currentStep = 0;
            List<string> appsToRemove = new List<string>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();
                    Label lblNome = panel.Controls.OfType<Label>().FirstOrDefault();

                    if (checkBox != null && checkBox.Checked && lblNome != null)
                    {
                        string nomeTecnico = appxNames.FirstOrDefault(app => OttieniNomeLeggibile(app) == lblNome.Text);
                        if (!string.IsNullOrEmpty(nomeTecnico))
                        {
                            appsToRemove.Add(nomeTecnico);

                        }
                    }
                }
            }

            foreach (string app in appsToRemove)
            {
                RimuoviApp(app);
                RimuoviProvisioning(app);
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
            }
            CaricaAppxPackages();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = Math.Min(e.ProgressPercentage, progressBar1.Maximum);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            string messaggio = LanguageManager.GetTranslation("Global", "modifichesuccesso");

            MessageBox.Show(
                messaggio,
                "WinHubX",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
