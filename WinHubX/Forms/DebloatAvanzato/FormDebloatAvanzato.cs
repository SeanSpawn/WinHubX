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
            foreach (var selectedItem in checkedListBox1.CheckedItems)
            {
                string packageName = selectedItem.ToString();
                string command = $"Get-AppxPackage -allusers {packageName} | Remove-AppxPackage";
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Verb = "runas",
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
            if (checkBox_WindowsDefender.Checked)
            {
                DialogResult result = MessageBox.Show(
                    LanguageManager.GetTranslation("Global", "restartrequired"),
                    "WinHubX",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.OK)
                {
                    string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                    string resourcePath = $"{assemblyName}.Resources.PowerRun.exe";
                    try
                    {
                        byte[] exeBytes = LoadEmbeddedResource(resourcePath);
                        string tempExePath = Path.Combine(Path.GetTempPath(), "PowerRun.exe");
                        File.WriteAllBytes(tempExePath, exeBytes);
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender"" /v ""DisableAntiSpyware"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableBehaviorMonitoring"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableIOAVProtection"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableOnAccessProtection"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"" /v ""DisableRealtimeMonitoring"" /t REG_DWORD /d 1 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SecurityHealthService"" /v ""Start"" /t REG_DWORD /d 4 /f""");
                        RunCommand(tempExePath, @"cmd.exe /c ""reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WinDefend"" /v ""Start"" /t REG_DWORD /d 4 /f""");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                }
            }
            else
            {

            }
        }

        static byte[] LoadEmbeddedResource(string resourcePath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                    throw new InvalidOperationException("Error: " + resourcePath);
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
            checkedListBox1.Items.Clear();
            foreach (var packageName in packageNames)
            {
                if (packageName.ToLower().Contains(searchText))
                {
                    checkedListBox1.Items.Add(packageName);
                }
            }
        }

    }
}
