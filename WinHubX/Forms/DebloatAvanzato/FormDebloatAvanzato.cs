using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHubX.Forms.DebloatAvanzato
{
    public partial class FormDebloatAvanzato : Form
    {
        private List<string> packageNames = new List<string>();

        public FormDebloatAvanzato()
        {
            InitializeComponent();
            LoadAppxPackages();
        }

        private void LoadAppxPackages()
        {
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = "Get-AppxPackage | Select-Object -ExpandProperty Name";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            packageNames = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            checkedListBox1.Items.AddRange(packageNames.ToArray());
        }

        private void btnAvviaSelezionati_Click(object sender, EventArgs e)
        {
            // Verifica gli elementi selezionati nella CheckedListBox
            foreach (var selectedItem in checkedListBox1.CheckedItems)
            {
                // Costruisci il comando PowerShell per rimuovere il pacchetto selezionato
                string packageName = selectedItem.ToString();
                string command = $"Get-AppxPackage -allusers {packageName} | Remove-AppxPackage";

                // Esegui il comando PowerShell per rimuovere il pacchetto
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas", // Esegui come amministratore
                    UseShellExecute = false,
                    Arguments = command
                };

                Process process = new Process
                {
                    StartInfo = psi,
                    EnableRaisingEvents = true
                };

                process.Start();
            }

            // Verifica se la checkbox per Windows Defender è selezionata
            if (checkBox_WindowsDefender.Checked)
            {
                DialogResult result = MessageBox.Show("Questa operazione richiede un riavvio del PC, Continuare?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                // Check the user's response
                if (result == DialogResult.OK)
                {
                    string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                    string resourcePath = $"{assemblyName}.Resources.PowerRun.exe";

                    try
                    {
                        byte[] exeBytes = LoadEmbeddedResource(resourcePath);
                        string tempExePath = Path.Combine(Path.GetTempPath(), "PowerRun.exe");
                        File.WriteAllBytes(tempExePath, exeBytes);

                        // Esegui i comandi per disabilitare Windows Defender
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender"" /v ""DisableAntiSpyware"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableBehaviorMonitoring"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableIOAVProtection"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableOnAccessProtection"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableRealtimeMonitoring"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SecurityHealthService"" /v ""Start"" /t REG_DWORD /d 4 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend"" /v ""Start"" /t REG_DWORD /d 4 /f""");

                        MessageBox.Show("Le modifiche sono state applicate. Riavvia il PC per renderle effettive.", "Operazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Si è verificato un errore durante il processo di debloating: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Operazione Annullata", "Annullato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Operazione completata senza modificare Windows Defender.", "Operazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static byte[] LoadEmbeddedResource(string resourcePath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                    throw new InvalidOperationException("Impossibile trovare la risorsa: " + resourcePath);

                // Leggi i byte dallo stream di input
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        static void RunCommand(string fileName, string arguments)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (var process = Process.Start(startInfo))
            {
                process.WaitForExit();
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string searchText = textBox1.Text.ToLower();

            checkedListBox1.Items.Clear(); // Svuota temporaneamente la lista

            foreach (var packageName in packageNames) // Assicurati che packageNames sia una variabile di classe
            {
                if (packageName.ToLower().Contains(searchText))
                {
                    checkedListBox1.Items.Add(packageName);
                }
            }
        }

    }
}
