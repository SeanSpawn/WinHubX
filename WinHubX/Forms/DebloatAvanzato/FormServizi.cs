﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Management;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Diagnostics;

namespace WinHubX.Forms.DebloatAvanzato
{
    public partial class FormServizi : Form
    {
        private int totalSteps = 0;
        public FormServizi()
        {
            InitializeComponent();
        }

        private async void FormServizi_Load(object sender, EventArgs e)
        {
            string url = "https://raw.githubusercontent.com/AMStore-na/WinHubX-Resource/refs/heads/main/Servizi.json";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    ServiziRoot serviziRoot = JsonConvert.DeserializeObject<ServiziRoot>(json);

                    for (int i = 0; i < serviziRoot.service.Count; i++)
                    {
                        var servizio = serviziRoot.service[i];
                        DisabilitaServizi.Items.Add(servizio.Name);
                        DisabilitaServizi.SetItemChecked(i, true); // Spunta l'elemento
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei servizi: " + ex.Message);
            }
        }


        private async void ModificaServiziButton_Click(object sender, EventArgs e)
        {
            int totalSteps = DisabilitaServizi.CheckedItems.Count;
            if (totalSteps == 0) totalSteps = 1;

            progressBar1.Maximum = totalSteps;
            progressBar1.Value = 0;
            richTextBox1.Clear(); // Pulisce il RichTextBox all'inizio

            await EseguiModificaServiziAsync();
        }

        private async Task EseguiModificaServiziAsync()
        {
            string url = "https://raw.githubusercontent.com/AMStore-na/WinHubX-Resource/refs/heads/main/Servizi.json";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    ServiziRoot serviziRoot = JsonConvert.DeserializeObject<ServiziRoot>(json);

                    int currentStep = 0;

                    foreach (var checkedItem in DisabilitaServizi.CheckedItems)
                    {
                        string serviceName = checkedItem.ToString();
                        var servizio = serviziRoot.service.FirstOrDefault(s => s.Name == serviceName);

                        if (servizio != null)
                        {
                            // Prima fermiamo il servizio
                            string stopComando = $"Get-Service -Name \"{servizio.Name}\" -ErrorAction Stop | Stop-Service";

                            string comando = $"Set-Service -Name \"{servizio.Name}\" -StartupType {servizio.StartupType}";

                            string stato = await Task.Run(() =>
                            {
                                try
                                {
                                    ProcessStartInfo psi = new ProcessStartInfo
                                    {
                                        FileName = "powershell.exe",
                                        Arguments = $"-Command \"{stopComando}; {comando}\"", // Aggiungi il comando per fermare il servizio
                                        Verb = "runas",
                                        UseShellExecute = false,
                                        CreateNoWindow = true,
                                        RedirectStandardOutput = true,
                                        RedirectStandardError = true
                                    };

                                    using (var proc = Process.Start(psi))
                                    {
                                        string output = proc.StandardOutput.ReadToEnd();
                                        string error = proc.StandardError.ReadToEnd();
                                        proc.WaitForExit();

                                        if (proc.ExitCode == 0)
                                        {
                                            // Formatta il messaggio di successo come richiesto
                                            return $"Servizio \"{servizio.Name}\" → ✅ Modificato con successo";
                                        }
                                        else
                                        {
                                            // Estrai solo il messaggio di errore principale
                                            string errorMessage = error.Split(new[] { "\r\n" }, StringSplitOptions.None).FirstOrDefault() ?? error;
                                            return $"❌ Errore: {errorMessage}";
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    return $"❌ Errore: {ex.Message}";
                                }
                            });

                            richTextBox1.Invoke((MethodInvoker)(() =>
                            {
                                richTextBox1.AppendText($"{stato}\n");
                                richTextBox1.ScrollToCaret();
                                progressBar1.Value = Math.Min(++currentStep, progressBar1.Maximum);
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Invoke((MethodInvoker)(() =>
                {
                    richTextBox1.AppendText($"❌ Errore nel recupero dei dati");
                }));
            }
        }

    }

    public class Servizio
    {
        public string Name { get; set; }
        public string StartupType { get; set; }
        public string OriginalType { get; set; }
    }

    public class ServiziRoot
    {
        public List<Servizio> service { get; set; }
    }
}
