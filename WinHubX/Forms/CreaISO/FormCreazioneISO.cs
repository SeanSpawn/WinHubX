﻿using DiscUtils;
using DiscUtils.Udf;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.CreaISO
{
    public partial class FormCreazioneISO : Form
    {
        public Dictionary<string, string> ParametriISO { get; set; }
        private Form1 form1;
        private CancellationTokenSource _cancellationTokenSource;
        private FormCreaISO formcreaiso;
        public FormCreazioneISO(Form1 form1, FormCreaISO formcreaiso)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formcreaiso = formcreaiso;
        }
        private async void FormCreazioneISO_Shown(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            Start();
        }

        private List<Task> taskList = new();

        private async void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;
            form1.comboBox1.Enabled = false;
            form1.pictureBox3.Enabled = false;

            try
            {
                btnStop.Visible = true;
                btnStop.Enabled = true;

                await Task.Delay(3000, token);
                await AddAndAwait(Settaggi(token));
                progressBar1.Value = 10;

                await Task.Delay(2000, token);
                await AddAndAwait(CreazioneCartella(token));
                progressBar1.Value = 20;

                await Task.Delay(2000, token);
                await AddAndAwait(VerificaWIMoESD(token));
                progressBar1.Value = 30;

                await Task.Delay(2000, token);
                await AddAndAwait(MontaggioInstall(token));
                progressBar1.Value = 40;

                await Task.Delay(2000, token);
                await AddAndAwait(Unattend(token));
                progressBar1.Value = 50;

                await Task.Delay(2000, token);
                await AddAndAwait(RimozioneDiAlcuniProcessi(token));
                progressBar1.Value = 60;

                await Task.Delay(2000, token);
                await AddAndAwait(VerificaParametri(token));
                progressBar1.Value = 70;

                await Task.Delay(2000, token);
                await AddAndAwait(CopiaFileNecessari(token));
                progressBar1.Value = 80;

                // Verifica che non ci siano altri task attivi prima di procedere
                var stillRunning = taskList.Where(t => !t.IsCompleted).ToList();
                if (stillRunning.Any())
                {
                    string info = string.Join("\n", stillRunning.Select((t, i) => $"Task {i + 1} ancora attivo"));
                    MessageBox.Show("Attenzione! Ci sono task ancora attivi:\n" + info);
                    return;
                }

                await AddAndAwait(CreazioneInstall(token));
                progressBar1.Value = 90;

                await Task.Delay(2000, token);
                await AddAndAwait(CreazioneISO(token));
                progressBar1.Value = 90;

                await Task.Delay(2000, token);
                await AddAndAwait(Finito(token));
                progressBar1.Value = 100;
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Aborted");
            }
        }

        private async Task AddAndAwait(Task task)
        {
            taskList.Add(task);
            await task;
        }

        private Task Finito(CancellationToken token)
        {
            progressBar2.Value = 0;
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string successo1 = LanguageManager.GetTranslation("FormCreazioneISO", "successo1");
                    string successo2 = LanguageManager.GetTranslation("FormCreazioneISO", "successo2");
                    Color originalColor = richTextBox1.SelectionColor;
                    richTextBox1.SelectionColor = Color.Orange;
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                    richTextBox1.AppendText("\n\n" + successo1);
                    richTextBox1.AppendText("\n" + successo2);
                    richTextBox1.SelectionColor = originalColor;
                    richTextBox1.ScrollToCaret();
                });
                btnStop.Visible = false;
                btnBack.Enabled = true;
                form1.comboBox1.Enabled = true;
                form1.pictureBox3.Enabled = true;
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"\nError: {ex.Message}");
            }

            return Task.CompletedTask;
        }

        private async Task Settaggi(CancellationToken token)
        {
            if (ParametriISO != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var kvp in ParametriISO)
                {
                    token.ThrowIfCancellationRequested();

                    sb.AppendLine($"{kvp.Key} = {kvp.Value}");
                }
                richTextBox1.Text = sb.ToString();
            }

            await Task.CompletedTask;
        }

        private async Task CreazioneCartella(CancellationToken token)
        {
            if (ParametriISO != null && ParametriISO.TryGetValue("SelectedFile", out var selectedFile))
            {
                try
                {
                    if (!File.Exists(selectedFile))
                    {
                        string erroreisononcista = LanguageManager.GetTranslation("FormCreazioneISO", "erroreisonontrovata");
                        richTextBox1.AppendText($"\n{erroreisononcista} {selectedFile}");
                        return;
                    }

                    string extractPath = @"C:\ISO\WinISO";
                    Directory.CreateDirectory(extractPath);
                    progressBar2.Value = 0;

                    await Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();

                        using (FileStream fs = File.Open(selectedFile, FileMode.Open))
                        using (UdfReader reader = new UdfReader(fs))
                        {
                            DiscDirectoryInfo root = reader.GetDirectoryInfo("");
                            int totalFiles = CountFiles(root);
                            int extractedFiles = 0;
                            ExtractDirectory(root, extractPath, ref extractedFiles, totalFiles, token);
                        }
                    }, token);
                    string estrazioneiso = LanguageManager.GetTranslation("FormCreazioneISO", "estrazioneisook");
                    richTextBox1.AppendText("\n" + estrazioneiso);
                }
                catch (OperationCanceledException)
                {
                    richTextBox1.AppendText("\nAborted");
                }
                catch (Exception ex)
                {
                    richTextBox1.AppendText($"\nError: {ex.Message}");
                }
            }
        }

        private void ExtractDirectory(DiscDirectoryInfo directory, string targetPath, ref int extractedFiles, int totalFiles, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            Directory.CreateDirectory(targetPath);
            foreach (DiscFileInfo file in directory.GetFiles())
            {
                token.ThrowIfCancellationRequested();

                string destPath = Path.Combine(targetPath, file.Name);
                using (Stream source = file.OpenRead())
                using (FileStream dest = File.Create(destPath))
                {
                    source.CopyTo(dest);
                }
                extractedFiles++;
                int progress = (int)((double)extractedFiles / totalFiles * 100);
                Invoke(new Action(() => progressBar2.Value = progress));
            }
            foreach (DiscDirectoryInfo subDir in directory.GetDirectories())
            {
                token.ThrowIfCancellationRequested();

                string destPath = Path.Combine(targetPath, subDir.Name);
                ExtractDirectory(subDir, destPath, ref extractedFiles, totalFiles, token);
            }
        }


        private int CountFiles(DiscDirectoryInfo directory)
        {
            int count = 0;

            foreach (DiscFileInfo file in directory.GetFiles())
            {
                count++;
            }

            foreach (DiscDirectoryInfo subDir in directory.GetDirectories())
            {
                count += CountFiles(subDir);
            }

            return count;
        }
        private async Task VerificaWIMoESD(CancellationToken token)
        {
            string sourcesPath = @"C:\ISO\WinISO\sources";
            string esdPath = Path.Combine(sourcesPath, "install.esd");
            string wimPath = Path.Combine(sourcesPath, "install.wim");
            string wimProPath = Path.Combine(sourcesPath, "install_pro.wim");
            string erroreIndiceNonSelezionato = LanguageManager.GetTranslation("FormCreazioneISO", "erroreindicenonselezionato");
            string conversioneEsdWim = LanguageManager.GetTranslation("FormCreazioneISO", "conversioneesdwim");
            string conversioneSuccesso = LanguageManager.GetTranslation("FormCreazioneISO", "conversionesuccesso");
            string trovatoWim = LanguageManager.GetTranslation("FormCreazioneISO", "trovatoinstallwim");
            string ottimizzazioneSuccesso = LanguageManager.GetTranslation("FormCreazioneISO", "ottimizzazionesuccesso");
            string nessunFileTrovato = LanguageManager.GetTranslation("FormCreazioneISO", "nessunfilewimesd");
            string erroreOperazione = LanguageManager.GetTranslation("FormCreazioneISO", "erroreoperazione");
            string operazioneannullata = LanguageManager.GetTranslation("FormCreazioneISO", "operazioneannullatatoken");

            try
            {
                if (ParametriISO == null || !ParametriISO.TryGetValue("ComboSelected", out var indexValue))
                {
                    richTextBox1.AppendText("\n" + erroreIndiceNonSelezionato);
                    return;
                }
                if (File.Exists(esdPath))
                {
                    richTextBox1.AppendText("\n" + conversioneEsdWim);

                    string arguments = $"/export-image /SourceImageFile:\"{esdPath}\" " +
                                      $"/SourceIndex:{indexValue} " +
                                      $"/DestinationImageFile:\"{wimPath}\" " +
                                      $"/Compress:max /CheckIntegrity";
                    token.ThrowIfCancellationRequested();

                    bool success = await Task.Run(() => EseguiDISM(arguments, token), token);

                    if (success && File.Exists(wimPath))
                    {
                        File.Delete(esdPath);
                        richTextBox1.AppendText("\n" + conversioneSuccesso);
                    }
                }
                else if (File.Exists(wimPath))
                {
                    richTextBox1.AppendText("\n" + trovatoWim);

                    string arguments = $"/export-image /SourceImageFile:\"{wimPath}\" " +
                                      $"/SourceIndex:{indexValue} " +
                                      $"/DestinationImageFile:\"{wimProPath}\" " +
                                      $"/Compress:max /CheckIntegrity";
                    token.ThrowIfCancellationRequested();

                    bool success = await Task.Run(() => EseguiDISM(arguments, token), token);

                    if (success && File.Exists(wimProPath))
                    {
                        File.Delete(wimPath);
                        File.Move(wimProPath, wimPath);
                        richTextBox1.AppendText("\n" + ottimizzazioneSuccesso);
                    }
                }
                else
                {
                    richTextBox1.AppendText("\n" + nessunFileTrovato);
                }
            }
            catch (OperationCanceledException)
            {
                richTextBox1.AppendText("\n" + operazioneannullata);
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"\n{erroreOperazione}: {ex.Message}");
                if (File.Exists(wimProPath))
                {
                    try { File.Delete(wimProPath); } catch { }
                }
            }
        }

        private async Task<bool> EseguiDISM(string arguments, CancellationToken token)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    progressBar2.Maximum = 100;
                    progressBar2.Value = 0;
                });

                using (Process dismProcess = new Process())
                {
                    dismProcess.StartInfo.FileName = "dism.exe";
                    dismProcess.StartInfo.Arguments = arguments;
                    dismProcess.StartInfo.UseShellExecute = false;
                    dismProcess.StartInfo.RedirectStandardOutput = true;
                    dismProcess.StartInfo.RedirectStandardError = true;
                    dismProcess.StartInfo.CreateNoWindow = true;

                    dismProcess.OutputDataReceived += (sender, args) =>
                    {
                        if (!string.IsNullOrEmpty(args.Data))
                        {
                            UpdateProgressFromOutput(args.Data);
                        }
                    };

                    dismProcess.ErrorDataReceived += (sender, args) =>
                    {
                        if (!string.IsNullOrEmpty(args.Data))
                        {
                            richTextBox1.Invoke((MethodInvoker)delegate
                            {
                                richTextBox1.AppendText($"\nError: {args.Data}");
                            });
                        }
                    };

                    dismProcess.Start();
                    dismProcess.BeginOutputReadLine();
                    dismProcess.BeginErrorReadLine();
                    while (!dismProcess.HasExited)
                    {
                        token.ThrowIfCancellationRequested();
                        await Task.Delay(100);
                    }

                    dismProcess.WaitForExit();
                    return dismProcess.ExitCode == 0;
                }
            }
            catch (OperationCanceledException)
            {
                richTextBox1.Invoke((MethodInvoker)delegate
                {
                    string operazioneannullata = LanguageManager.GetTranslation("FormCreazioneISO", "operazioneannullatatoken");
                    richTextBox1.AppendText("\n" + operazioneannullata);
                });
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate
                {
                    progressBar2.Value = 100;
                });
            }
        }

        private void UpdateProgressFromOutput(string output)
        {
            if (output.Contains("%"))
            {
                Match match = Regex.Match(output, @"(\d+(\.\d+)?)%");
                if (match.Success)
                {
                    double percent = double.Parse(match.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
                    int progressValue = (int)Math.Round(percent);

                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBar2.Value = Math.Min(Math.Max(progressValue, 0), 100);
                    });
                }
            }
        }

        private async Task MontaggioInstall(CancellationToken token)
        {
            string wimPath = @"C:\ISO\WinISO\sources\install.wim";
            string mountDir = @"C:\mount\mount";
            string erroreFileWimNonTrovato = LanguageManager.GetTranslation("FormCreazioneISO", "errorefilewimnontrovato");
            string montaggioInCorso = LanguageManager.GetTranslation("FormCreazioneISO", "montaggioincorso");
            string montaggioSuccesso = LanguageManager.GetTranslation("FormCreazioneISO", "montaggiosuccesso");
            string erroreMontaggio = LanguageManager.GetTranslation("FormCreazioneISO", "erroremontaggio");
            string erroreGenericoMontaggio = LanguageManager.GetTranslation("FormCreazioneISO", "erroregenericomontaggio");

            try
            {
                if (!File.Exists(wimPath))
                {
                    richTextBox1.AppendText("\n" + erroreFileWimNonTrovato);
                    return;
                }

                Directory.CreateDirectory(mountDir);
                richTextBox1.AppendText("\n" + montaggioInCorso);

                string arguments = $"/mount-image /imagefile:\"{wimPath}\" /index:1 /mountdir:\"{mountDir}\"";
                bool success = await Task.Run(() => EseguiDISM(arguments, token), token);

                if (success)
                {
                    richTextBox1.AppendText("\n" + montaggioSuccesso);
                }
                else
                {
                    richTextBox1.AppendText("\n" + erroreMontaggio);
                }
            }
            catch (OperationCanceledException)
            {
                string operazioneannullata = LanguageManager.GetTranslation("FormCreazioneISO", "operazioneannullatatoken");
                richTextBox1.AppendText("\n" + operazioneannullata);
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"\n{erroreGenericoMontaggio}: {ex.Message}");
            }
        }


        private async Task Unattend(CancellationToken token)
        {
            try
            {
                if (ParametriISO == null || !ParametriISO.TryGetValue("windowsVersion", out var windowsVersion))
                {
                    richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "erroreversionewindows"));
                    return;
                }

                string sourceUnattend = Path.Combine(Path.GetTempPath(), @"RisorseCreaISO\Risorse\unattend.xml");
                string sourceUnattendStock = Path.Combine(Path.GetTempPath(), @"RisorseCreaISO\Risorse\unattendstock.xml");
                string destUnattend = @"C:\ISO\WinISO\sources\$OEM$\$$\Panther\unattend.xml";
                string mountDir = @"C:\mount\mount";
                string bootWimPath = @"C:\ISO\WinISO\sources\boot.wim";
                string bootMountDir = @"C:\mount\boot";
                string appraiserPath = @"C:\ISO\WinISO\sources\appraiserres.dll";
                string appraiserBakPath = appraiserPath + ".bak";
                string sourceUnattend10 = Path.Combine(Path.GetTempPath(), @"RisorseCreaISO\Risorse\unattend10.xml");
                string sourceUnattendx32 = Path.Combine(Path.GetTempPath(), @"RisorseCreaISO\Risorse\unattendx32.xml");

                if (!File.Exists(sourceUnattend))
                {
                    richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "erroreunattendmancante"));
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(destUnattend));
                Directory.CreateDirectory(mountDir);
                Directory.CreateDirectory(bootMountDir);
                Directory.CreateDirectory(Path.GetDirectoryName(appraiserPath));

                if (windowsVersion == "11" && ParametriISO.TryGetValue("Unattend", out var unattendType))
                {
                    if (unattendType == "Bypass")
                    {
                        if (File.Exists(sourceUnattend))
                        {
                            File.Copy(sourceUnattend, destUnattend, true);
                            richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "copiabypass"));
                        }
                        richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "configbypass"));

                        await Task.Run(async () =>
                        {
                            // Assicurati che ogni chiamata ExecuteCommand supporti l'annullamento
                            ExecuteCommand($"reg load HKLM\\TK_COMPONENTS \"{mountDir}\\Windows\\System32\\config\\COMPONENTS\"", token);
                            ExecuteCommand($"reg load HKLM\\TK_DEFAULT \"{mountDir}\\Windows\\System32\\config\\default\"", token);
                            ExecuteCommand($"reg load HKLM\\TK_NTUSER \"{mountDir}\\Users\\Default\\ntuser.dat\"", token);
                            ExecuteCommand($"reg load HKLM\\TK_SOFTWARE \"{mountDir}\\Windows\\System32\\config\\SOFTWARE\"", token);
                            ExecuteCommand($"reg load HKLM\\TK_SYSTEM \"{mountDir}\\Windows\\System32\\config\\SYSTEM\"", token);

                            var regCommands = new List<string>
{
@"reg add ""HKLM\TK_SOFTWARE\Microsoft\Windows\CurrentVersion\Communications"" /v ""ConfigureChatAutoInstall"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""OemPreInstalledAppsEnabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""PreInstalledAppsEnabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SilentInstalledAppsEnabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_SOFTWARE\Policies\Microsoft\Windows\CloudContent"" /v ""DisableWindowsConsumerFeature"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""ContentDeliveryAllowed"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_SOFTWARE\Microsoft\PolicyManager\current\device\Start"" /v ""ConfigureStartPins"" /t REG_SZ /d ""{\""pinnedList\"": [{}]}"" /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""FeatureManagementEnabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""PreInstalledAppsEverEnabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SoftLandingEnabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SubscribedContentEnabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SubscribedContent-310093Enabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SubscribedContent-338388Enabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SubscribedContent-338389Enabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SubscribedContent-338393Enabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SubscribedContent-353694Enabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SubscribedContent-353696Enabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"" /v ""SystemPaneSuggestionsEnabled"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_SOFTWARE\Policies\Microsoft\PushToInstall"" /v ""DisablePushToInstall"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_SOFTWARE\Policies\Microsoft\MRT"" /v ""DontOfferThroughWUAU"" /t REG_DWORD /d 1 /f",
@"reg delete ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager\Subscriptions"" /f",
@"reg delete ""HKLM\TK_NTUSER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager\SuggestedApps"" /f",
@"reg add ""HKLM\TK_SOFTWARE\Policies\Microsoft\Windows\CloudContent"" /v ""DisableConsumerAccountStateContent"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_SOFTWARE\Policies\Microsoft\Windows\CloudContent"" /v ""DisableCloudOptimizedContent"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_SOFTWARE\Microsoft\Windows\CurrentVersion\ReserveManager"" /v ""ShippedWithReserves"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_SOFTWARE\Policies\Microsoft\Windows\Windows Chat"" /v ""ChatIcon"" /t REG_DWORD /d 3 /f",
@"reg add ""HKLM\TK_NTUSER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced"" /v ""TaskbarMn"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_DEFAULT\Control Panel\UnsupportedHardwareNotificationCache"" /v ""SV1"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_DEFAULT\Control Panel\UnsupportedHardwareNotificationCache"" /v ""SV2"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Control Panel\UnsupportedHardwareNotificationCache"" /v ""SV1"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_NTUSER\Control Panel\UnsupportedHardwareNotificationCache"" /v ""SV2"" /t REG_DWORD /d 0 /f",
@"reg add ""HKLM\TK_SYSTEM\Setup\LabConfig"" /v ""BypassCPUCheck"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_SYSTEM\Setup\LabConfig"" /v ""BypassRAMCheck"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_SYSTEM\Setup\LabConfig"" /v ""BypassSecureBootCheck"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_SYSTEM\Setup\LabConfig"" /v ""BypassStorageCheck"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_SYSTEM\Setup\LabConfig"" /v ""BypassTPMCheck"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_SYSTEM\Setup\MoSetup"" /v ""AllowUpgradesWithUnsupportedTPMOrCPU"" /t REG_DWORD /d 1 /f",
@"reg add ""HKLM\TK_SOFTWARE\Microsoft\Windows\CurrentVersion\OOBE"" /v ""BypassNRO"" /t REG_DWORD /d 1 /f"
};

                            foreach (var cmd in regCommands)
                                ExecuteCommand(cmd, token);

                            Task.Delay(5000);
                            string[] unloadMounts = new[]
                            {
    "TK_COMPONENTS", "TK_DEFAULT", "TK_DRIVERS", "TK_NTUSER", "TK_SCHEMA", "TK_SOFTWARE", "TK_SYSTEM"
};

                            foreach (var mount in unloadMounts)
                            {
                                ExecuteCommand($"reg unload HKLM\\{mount}", token);
                                await Task.Delay(3000, token);
                            }

                            string[] subKeysToCheck = {
    "TK_COMPONENTS",
    "TK_DEFAULT",
    "TK_DRIVERS",
    "TK_NTUSER",
    "TK_SCHEMA",
    "TK_SOFTWARE",
    "TK_SYSTEM"
};
                            int maxRetryy = 5;
                            for (int i = 0; i < maxRetryy; i++)
                            {
                                bool allUnloaded = true;

                                foreach (var subKey in subKeysToCheck)
                                {
                                    string fullKeyPath = $@"HKEY_LOCAL_MACHINE\{subKey}";
                                    if (RegistryKeyExists(fullKeyPath))
                                    {
                                        allUnloaded = false;
                                        try
                                        {
                                            ExecuteCommand($"reg unload HKLM\\{subKey}", token);
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                }

                                if (allUnloaded)
                                    break;

                                await Task.Delay(5000, token);
                            }

                        }, token);

                        if (File.Exists(bootWimPath))
                        {
                            richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "montaggioboot"));

                            string arguments = $"/mount-image /imagefile:\"{bootWimPath}\" /index:2 /mountdir:\"{bootMountDir}\"";
                            bool success = await Task.Run(() => EseguiDISM(arguments, token), token);

                            if (success)
                            {
                                richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "montaggiobootsuccesso"));

                                ExecuteCommand($"reg load HKLM\\TK_BOOT_SYSTEM \"{bootMountDir}\\Windows\\System32\\Config\\SYSTEM\"", token);
                                var regCommands = new List<string>
                        {
                            @"reg add ""HKLM\TK_BOOT_SYSTEM\Setup\LabConfig"" /v ""BypassCPUCheck"" /t REG_DWORD /d 1 /f",
                            @"reg add ""HKLM\TK_BOOT_SYSTEM\Setup\LabConfig"" /v ""BypassRAMCheck"" /t REG_DWORD /d 1 /f",
                            @"reg add ""HKLM\TK_BOOT_SYSTEM\Setup\LabConfig"" /v ""BypassSecureBootCheck"" /t REG_DWORD /d 1 /f",
                            @"reg add ""HKLM\TK_BOOT_SYSTEM\Setup\LabConfig"" /v ""BypassStorageCheck"" /t REG_DWORD /d 1 /f",
                            @"reg add ""HKLM\TK_BOOT_SYSTEM\Setup\LabConfig"" /v ""BypassTPMCheck"" /t REG_DWORD /d 1 /f"
                        };

                                foreach (var cmd in regCommands) ExecuteCommand(cmd, token);
                                await Task.Delay(5000);
                                ExecuteCommand("reg unload HKLM\\TK_BOOT_SYSTEM", token);

                                if (File.Exists(appraiserPath))
                                {
                                    File.Move(appraiserPath, appraiserBakPath);
                                    richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "rinominatoappraiser"));
                                }
                                else
                                {
                                    richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "appraisernontrovato"));
                                }
                                int maxRetry = 5;
                                for (int i = 0; i < maxRetry; i++)
                                {
                                    if (!RegistryKeyExists(@"HKEY_LOCAL_MACHINE\TK_BOOT_SYSTEM"))
                                        break;

                                    await Task.Delay(3000); // Attendi prima del prossimo tentativo
                                    ExecuteCommand("reg unload HKLM\\TK_BOOT_SYSTEM", token);
                                }
                                richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "smontaggioboot"));
                                string unmountArguments = $"/unmount-image /mountdir:\"{bootMountDir}\" /commit";
                                bool unmountSuccess = await Task.Run(() => EseguiDISM(unmountArguments, token), token);

                                if (unmountSuccess)
                                    richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "smontaggiobootsuccesso"));
                                else
                                    richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "erroresmontaggioboot"));
                            }
                            else
                            {
                                richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "erroremontaggioboot"));
                            }

                            richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "bypasscompletato"));
                        }
                    }
                    else if (windowsVersion == "10" && ParametriISO.TryGetValue("Architettura", out var arch))
                    {
                        ExecuteCommand($"reg load HKLM\\TK_SOFTWARE \"{mountDir}\\Windows\\System32\\config\\SOFTWARE\"", token);
                        var regCommands = new List<string>
                {
                    @"reg add ""HKLM\TK_SOFTWARE\Microsoft\Windows\CurrentVersion\OOBE"" /v ""BypassNRO"" /t REG_DWORD /d 1 /f"
                };
                        foreach (var cmd in regCommands) ExecuteCommand(cmd, token);
                        await Task.Delay(5000);
                        ExecuteCommand("reg unload HKLM\\TK_SOFTWARE", token);
                        int maxRetry = 5;
                        for (int i = 0; i < maxRetry; i++)
                        {
                            if (!RegistryKeyExists(@"HKEY_LOCAL_MACHINE\TK_SOFTWARE"))
                                break;

                            await Task.Delay(3000); // Attendi prima del prossimo tentativo
                            ExecuteCommand("reg unload HKLM\\TK_SOFTWARE", token);
                        }
                        if (arch == "x64" && File.Exists(sourceUnattend10))
                        {
                            File.Copy(sourceUnattend10, destUnattend, true);
                            richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "copiaunattend10x64"));
                        }
                        else if (arch == "x32" && File.Exists(sourceUnattendx32))
                        {
                            File.Copy(sourceUnattendx32, destUnattend, true);
                            richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "copiaunattend10x32"));
                        }
                        else
                        {
                            richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "erroreunattendarch"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "erroregenericaunattend") + $": {ex.Message}");
            }
        }

        private bool RegistryKeyExistss(string keyPath)
        {
            try
            {
                using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(keyPath.Replace("HKEY_LOCAL_MACHINE\\", "")))
                {
                    return key != null;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool RegistryKeyExists(string keyPath)
        {
            try
            {
                using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(keyPath.Replace("HKEY_LOCAL_MACHINE\\", "")))
                {
                    return key != null;
                }
            }
            catch
            {
                return false;
            }
        }
        private async Task ExecuteCommand(string command, CancellationToken token)
        {
            // Mostra il comando in esecuzione
            richTextBox1.Invoke((MethodInvoker)(() =>
            {
                richTextBox1.AppendText($"\n[ESEGUITO] {command}");
            }));

            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C {command}";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.Start();

                var outputTask = Task.Run(() =>
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    // Puoi loggare anche output ed error se necessario
                });

                await Task.WhenAny(outputTask, Task.Delay(Timeout.Infinite, token)).ConfigureAwait(false);

                if (token.IsCancellationRequested)
                {
                    process.Kill();
                    string operazioneannullata = LanguageManager.GetTranslation("FormCreazioneISO", "operazioneannullatatoken");
                    richTextBox1.Invoke((MethodInvoker)(() =>
                    {
                        richTextBox1.AppendText("\n" + operazioneannullata);
                    }));
                }

                await outputTask.ConfigureAwait(false);
                process.WaitForExit();
            }
        }


        private async Task RimozioneDiAlcuniProcessi(CancellationToken token)
        {
            if (ParametriISO != null && ParametriISO.TryGetValue("Processi", out var processo) && processo == "RimuoviProcessi")
            {
                string[] comandi = new string[]
                {
            "powershell -Command \"Get-WindowsPackage -Path 'C:\\mount\\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-InternetExplorer-Optional-Package*'} | ForEach-Object {dism /English /image:C:\\mount\\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}\"",
            "powershell -Command \"Get-WindowsPackage -Path 'C:\\mount\\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-Kernel-LA57-FoD*'} | ForEach-Object {dism /English /image:C:\\mount\\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}\"",
            "powershell -Command \"Get-WindowsPackage -Path 'C:\\mount\\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-Handwriting*'} | ForEach-Object {dism /English /image:C:\\mount\\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}\"",
            "powershell -Command \"Get-WindowsPackage -Path 'C:\\mount\\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-OCR*'} | ForEach-Object {dism /English /image:C:\\mount\\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}\"",
            "powershell -Command \"Get-WindowsPackage -Path 'C:\\mount\\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-Speech*'} | ForEach-Object {dism /English /image:C:\\mount\\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}\"",
            "powershell -Command \"Get-WindowsPackage -Path 'C:\\mount\\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-LanguageFeatures-TextToSpeech*'} | ForEach-Object {dism /English /image:C:\\mount\\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}\"",
            "powershell -Command \"Get-WindowsPackage -Path 'C:\\mount\\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-MediaPlayer-Package*'} | ForEach-Object {dism /English /image:C:\\mount\\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}\"",
            "powershell -Command \"Get-WindowsPackage -Path 'C:\\mount\\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-TabletPCMath-Package*'} | ForEach-Object {dism /English /image:C:\\mount\\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}\"",
            "powershell -Command \"Get-WindowsPackage -Path 'C:\\mount\\mount' | Where-Object {$_.PackageName -like 'Microsoft-Windows-Wallpaper-Content-Extended-FoD*'} | ForEach-Object {dism /English /image:C:\\mount\\mount /Remove-Package /PackageName:$($_.PackageName) /NoRestart | Out-Null}\""
                };

                Invoke(new Action(() =>
                {
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = comandi.Length;
                    progressBar2.Value = 0;
                }));

                foreach (var cmd in comandi)
                {
                    if (token.IsCancellationRequested)
                    {
                        Invoke(new Action(() =>
                        {
                            string operazioneannullata = LanguageManager.GetTranslation("FormCreazioneISO", "operazioneannullatatoken");
                            richTextBox1.AppendText("\n" + operazioneannullata);
                        }));
                        break;
                    }

                    var processInfo = new ProcessStartInfo("cmd.exe", "/c " + cmd)
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = Process.Start(processInfo))
                    {
                        string output = await process.StandardOutput.ReadToEndAsync();
                        string error = await process.StandardError.ReadToEndAsync();
                        await process.WaitForExitAsync();

                        Invoke(new Action(() =>
                        {
                            if (!string.IsNullOrEmpty(output))
                                richTextBox1.AppendText($"\n{output}");
                            if (!string.IsNullOrEmpty(error))
                                richTextBox1.AppendText($"\nError: {error}");
                            if (progressBar2.Value < progressBar2.Maximum)
                                progressBar2.Value += 1;
                        }));
                    }

                    // Attesa tra i comandi (es. 1 secondo)
                    await Task.Delay(1000, token);
                }

                Invoke(new Action(() =>
                {
                    string rimozionepacchetti = LanguageManager.GetTranslation("FormCreazioneISO", "rimozionepacchetticompletata");
                    richTextBox1.AppendText("\n" + rimozionepacchetti);
                }));
            }
        }

        private async Task VerificaParametri(CancellationToken token)
        {
            string targetDir = @"C:\mount\mount\Windows";

            Invoke(new Action(() =>
            {
                progressBar2.Minimum = 0;
                progressBar2.Maximum = 3;
                progressBar2.Value = 0;
            }));

            await Task.Run(() =>
            {
                try
                {
                    // Controllo del token prima di ogni operazione
                    if (token.IsCancellationRequested) return;

                    if (!Directory.Exists(targetDir))
                        Directory.CreateDirectory(targetDir);

                    if (ParametriISO != null)
                    {
                        if (token.IsCancellationRequested) return;

                        if (ParametriISO.TryGetValue("edgeRemovalPreference", out var edgePref) && edgePref == "RemoveEdge")
                        {
                            File.Create(Path.Combine(targetDir, "noedge.pref")).Dispose();

                            File.Copy(Path.Combine(Path.GetTempPath(), @"RisorseCreaISO\Risorse\OperaGXSetup.exe"), Path.Combine(targetDir, "OperaGXSetup.exe"), true);
                            File.Copy(Path.Combine(Path.GetTempPath(), @"RisorseCreaISO\Risorse\PowerRun.exe"), Path.Combine(targetDir, "PowerRun.exe"), true);

                            Invoke(new Action(() => progressBar2.Value += 1));
                        }

                        if (token.IsCancellationRequested) return;

                        if (ParametriISO.TryGetValue("DebloatApp", out var debloat) && debloat == "Debloat")
                        {
                            File.Create(Path.Combine(targetDir, "debloatapp.pref")).Dispose();
                            Invoke(new Action(() => progressBar2.Value += 1));
                        }

                        if (token.IsCancellationRequested) return;

                        if (ParametriISO.TryGetValue("defenderPreference", out var defender) && defender == "DisableWindowsDefender")
                        {
                            File.Create(Path.Combine(targetDir, "nodefender.pref")).Dispose();
                            Invoke(new Action(() => progressBar2.Value += 1));
                        }
                    }

                    // Verifica parametri completata
                    Invoke(new Action(() =>
                    {
                        string verificaparametri = LanguageManager.GetTranslation("FormCreazioneISO", "verificaparametricompletata");
                        richTextBox1.AppendText("\n" + verificaparametri);
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        richTextBox1.AppendText($"\nError: {ex.Message}");
                    }));
                }
            }, token);
        }

        private async Task CopiaFileNecessari(CancellationToken token)
        {
            string sourceFolder = Path.Combine(Path.GetTempPath(), @"RisorseCreaISO\Risorse");
            string targetFolder = @"C:\mount\mount\Windows";

            string[] filesToCopy = new string[]
            {
        "tweaks.bat",
        "lower-ram-usage.reg",
        "start.ps1",
        "PowerRun.exe"
            };

            Invoke(new Action(() =>
            {
                progressBar2.Minimum = 0;
                progressBar2.Maximum = filesToCopy.Length;
                progressBar2.Value = 0;
            }));

            await Task.Run(() =>
            {
                try
                {
                    foreach (var file in filesToCopy)
                    {
                        if (token.IsCancellationRequested) return;

                        string sourceFilePath = Path.Combine(sourceFolder, file);
                        string targetFilePath = Path.Combine(targetFolder, file);

                        if (File.Exists(sourceFilePath))
                        {
                            if (token.IsCancellationRequested) return;

                            File.Copy(sourceFilePath, targetFilePath, true);
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText($"\n{LanguageManager.GetTranslation("FormCreazioneISO", "filenontrovato")}: {sourceFilePath}");
                            }));
                        }
                        if (token.IsCancellationRequested) return;

                        Invoke(new Action(() =>
                        {
                            progressBar2.Value += 1;
                        }));
                    }

                    // Verifica completamento
                    Invoke(new Action(() =>
                    {
                        richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "copiacompletata"));
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        richTextBox1.AppendText($"\n{LanguageManager.GetTranslation("FormCreazioneISO", "erroregenerico")}: {ex.Message}");
                    }));
                }
            }, token);
        }


        private async Task CreazioneInstall(CancellationToken token)
        {
            string mountDir = @"C:\mount\mount";

            try
            {
                if (!Directory.Exists(mountDir))
                {
                    richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "errordirectorymount"));
                    return;
                }

                richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "smontaggiosalvataggio"));
                await Task.Delay(6000);
                string arguments = $"/unmount-image /mountdir:\"{mountDir}\" /commit";
                bool success = await Task.Run(() => EseguiDISM(arguments, token), token);

                if (success)
                {
                    richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "immaginesmontata"));
                }
                else
                {
                    richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "erroresmontaggio"));
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"\n{LanguageManager.GetTranslation("FormCreazioneISO", "errorecreazioneinstall")}: {ex.Message}");
            }
        }

        private async Task CreazioneISO(CancellationToken token)
        {
            string sourcePath = @"C:\ISO\WinISO";
            string isoOutputPath = @"C:\ISO\WindowsISO_edited.iso";
            string oscdimgPath = Path.Combine(Path.GetTempPath(), @"RisorseCreaISO\Risorse\oscdimg");

            Invoke(new Action(() =>
            {
                progressBar2.Minimum = 0;
                progressBar2.Maximum = 3;
                progressBar2.Value = 0;
            }));

            await Task.Run(() =>
            {
                try
                {
                    string oscdimgArguments = $"-m -o -u2 -bootdata:2#p0,e,b{sourcePath}\\boot\\etfsboot.com#pEF,e,b{sourcePath}\\efi\\microsoft\\boot\\efisys.bin {sourcePath} {isoOutputPath}";
                    ProcessStartInfo oscdimgProcess = new ProcessStartInfo
                    {
                        FileName = oscdimgPath,
                        Arguments = oscdimgArguments,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    // Esegui il processo con supporto per l'annullamento
                    using (Process oscdimgProc = Process.Start(oscdimgProcess))
                    {
                        while (!oscdimgProc.HasExited)
                        {
                            if (token.IsCancellationRequested)
                            {
                                oscdimgProc.Kill();
                                return;
                            }

                            Thread.Sleep(100);
                        }
                    }

                    Invoke(new Action(() =>
                    {
                        progressBar2.Value += 1;
                    }));

                    string destinationPath = @"C:\WindowsISO_edited.iso";
                    File.Copy(isoOutputPath, destinationPath, true);

                    Invoke(new Action(() =>
                    {
                        progressBar2.Value += 1;
                    }));

                    Directory.Delete(@"C:\ISO", true);
                    Directory.Delete(@"C:\mount", true);

                    Invoke(new Action(() =>
                    {
                        progressBar2.Value += 1;
                        richTextBox1.AppendText("\n" + LanguageManager.GetTranslation("FormCreazioneISO", "creazioneisocompletata"));
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        richTextBox1.AppendText($"\n{LanguageManager.GetTranslation("FormCreazioneISO", "errorecreazioneiso")}: {ex.Message}");
                    }));
                }
            }, token);
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            string creazioneiso = LanguageManager.GetTranslation("Form1", "titoloCreaISO");
            form1.lblPanelTitle.Text = "creazioneiso";
            form1.PnlFormLoader.Controls.Clear();
            formcreaiso = new FormCreaISO(form1)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            form1.PnlFormLoader.Controls.Add(formcreaiso);
            formcreaiso.Show();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            btnBack.Enabled = true;
            btnBack.Cursor = Cursors.Hand;
            form1.comboBox1.Enabled = true;
            form1.pictureBox3.Enabled = true;
        }
    }
}
