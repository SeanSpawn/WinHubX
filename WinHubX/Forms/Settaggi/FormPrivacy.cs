using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System.ServiceProcess;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormPrivacy : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormPrivacy(FormSettaggi formSettaggi, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formSettaggi = formSettaggi;
            LoadCheckboxStates();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form1.lblPanelTitle.Text = "Settaggi";
            form1.PnlFormLoader.Controls.Clear();
            formSettaggi = new FormSettaggi(form1)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            form1.PnlFormLoader.Controls.Add(formSettaggi);
            formSettaggi.Show();
        }

        private void SetCheckboxState(string itemName, bool isChecked)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\WinHubX"))
            {
                key.SetValue(itemName, isChecked ? 1 : 0, RegistryValueKind.DWord);
            }
        }

        private bool GetCheckboxState(string itemName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\WinHubX"))
            {
                if (key != null)
                {
                    object value = key.GetValue(itemName);
                    if (value != null)
                    {
                        return (int)value == 1;
                    }
                }
            }
            return false;
        }

        private void LoadCheckboxStates()
        {
            int index = DisabilitaPrivacy.Items.IndexOf("Disabilita Opzioni Lingua");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaOpzioniLingua"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Suggerimenti App");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaSuggerimentiApp"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Telemetria");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaTelemetria"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Tracking");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaTracking"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Segnalazione Errori");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaSegnalazioneErrori"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Tracking Diagnostica");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaTrackingDiagnostica"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita WAP Push Service");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaWAPPushService"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disbailita Home Group");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisbailitaHomeGroup"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Assistenza Remota");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaAssistenzaRemota"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disbailita Schedul Defrag");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisbailitaSchedulDefrag"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Xbox Features");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaXboxFeatures"));
            }
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaAutoManteinance"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Spazio Riservato");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaSpazioRiservato"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Tweaks Game DVR");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaTweaksGameDVR"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Storia Attivita");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaStoriaAttivita"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Opzioni Lingua");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaOpzioniLingua"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Suggerimenti App");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaSuggerimentiApp"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Telemetria");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaTelemetria"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Tracking");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaTracking"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Segnalazione Errori");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaSegnalazioneErrori"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Tracking Diagnostica");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaTrackingDiagnostica"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita WAP Push Service");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaWAPPushService"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Home Group");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaHomeGroup"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Assistenza Remota");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaAssistenzaRemota"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Schedul Defrag");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaSchedulDefrag"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Xbox Features");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaXboxFeatures"));
            }
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaAutoManteinance"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Spazio Riservato");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaSpazioRiservato"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Tweaks Game DVR");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaTweaksGameDVR"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Storie Attivita");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaStoriaAttivita"));
            }
        }

        private void ExecutePowerShellScript(string script, bool use32BitRegistry = false)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    // Se stai lavorando con il registro a 32 bit, modifica i percorsi delle chiavi di conseguenza
                    if (use32BitRegistry)
                    {
                        // Modifica gli script per puntare al percorso corretto per 32 bit
                        script = script.Replace("HKLM:\\SOFTWARE\\", "HKLM:\\SOFTWARE\\WOW6432Node\\");
                    }

                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe",
                        Arguments = $"-Command \"{script}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        if (process != null)
                        {
                            process.WaitForExit();

                            var output = process.StandardOutput.ReadToEnd();
                            var error = process.StandardError.ReadToEnd();

                            // Log o gestisci output e errori
                            if (!string.IsNullOrEmpty(output))
                            {
                                Console.WriteLine("Output:");
                                Console.WriteLine(output);
                            }

                            if (!string.IsNullOrEmpty(error))
                            {
                                Console.WriteLine("Error:");
                                Console.WriteLine(error);
                            }
                        }
                        else
                        {

                        }
                    }
                }
                catch (Exception ex)
                {

                }
            });

            thread.Start();
        }


        private void btnAvviaSelezionati_Click(object sender, EventArgs e)
        {
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Opzioni Lingua"))
            {
                SetCheckboxState("DisabilitaOpzioniLingua", true);

                try
                {
                    // Imposta il valore nella vista a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
                                                          .OpenSubKey(@"Control Panel\International\User Profile", writable: true))
                    {
                        key64?.SetValue("HttpAcceptLanguageOptOut", 1, RegistryValueKind.DWord);
                    }

                    // Imposta il valore nella vista a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32)
                                                          .OpenSubKey(@"Control Panel\International\User Profile", writable: true))
                    {
                        key32?.SetValue("HttpAcceptLanguageOptOut", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaOpzioniLingua", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Suggerimenti App"))
            {
                SetCheckboxState("DisabilitaSuggerimentiApp", true);

                try
                {
                    // Dizionario contenente i percorsi e i valori da impostare nel registro
                    var registrySettings = new Dictionary<string, Tuple<string, int>>
            {
                { @"SOFTWARE\Policies\Microsoft\Windows\CloudContent", new Tuple<string, int>("DisableThirdPartySuggestions", 1) },
                { @"SOFTWARE\Policies\Microsoft\Windows\CloudContent", new Tuple<string, int>("DisableWindowsConsumerFeatures", 1) },
                { @"SOFTWARE\Microsoft\Windows\CurrentVersion\Device Metadata", new Tuple<string, int>("PreventDeviceMetadataFromNetwork", 1) },
                { @"SOFTWARE\Policies\Microsoft\MRT", new Tuple<string, int>("DontOfferThroughWUAU", 1) },
                { @"SOFTWARE\Policies\Microsoft\SQMClient\Windows", new Tuple<string, int>("CEIPEnable", 0) },
                { @"SOFTWARE\Policies\Microsoft\Windows\AppCompat", new Tuple<string, int>("AITEnable", 0) },
                { @"SOFTWARE\Policies\Microsoft\Windows\AppCompat", new Tuple<string, int>("DisableUAR", 1) },
                { @"SYSTEM\CurrentControlSet\Control\WMI\AutoLogger\AutoLogger-Diagtrack-Listener", new Tuple<string, int>("Start", 0) },
                { @"SYSTEM\CurrentControlSet\Control\WMI\AutoLogger\SQMLogger", new Tuple<string, int>("Start", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SilentInstalledAppsEnabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SystemPaneSuggestionsEnabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SoftLandingEnabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SubscribedContent", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SubscribedContent-310093Enabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SubscribedContent-314559Enabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SubscribedContent-338393Enabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SubscribedContent-353694Enabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SubscribedContent-353698Enabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("ContentDeliveryAllowed", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("OemPreInstalledAppsEnabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("PreInstalledAppsEnabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("PreInstalledAppsEverEnabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SubscribedContent-338387Enabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SubscribedContent-338388Enabled", 0) },
                { @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", new Tuple<string, int>("SubscribedContent-338389Enabled", 0) }
            };

                    // Applicazione delle modifiche per 64-bit e 32-bit
                    foreach (var registryView in new[] { RegistryView.Registry64, RegistryView.Registry32 })
                    {
                        foreach (var setting in registrySettings)
                        {
                            using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                            using (RegistryKey subKey = baseKey.CreateSubKey(setting.Key, writable: true))
                            {
                                subKey?.SetValue(setting.Value.Item1, setting.Value.Item2, RegistryValueKind.DWord);
                            }
                        }

                        using (RegistryKey baseKeyCU = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, registryView))
                        {
                            foreach (var setting in registrySettings.Where(s => s.Key.StartsWith("Software", StringComparison.OrdinalIgnoreCase)))
                            {
                                using (RegistryKey subKey = baseKeyCU.CreateSubKey(setting.Key, writable: true))
                                {
                                    subKey?.SetValue(setting.Value.Item1, setting.Value.Item2, RegistryValueKind.DWord);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaSuggerimentiApp", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Telemetria"))
            {
                SetCheckboxState("DisabilitaTelemetria", true);

                try
                {
                    // Imposta il valore nella vista a 64-bit
                    using (RegistryKey key64_1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection", writable: true))
                    {
                        key64_1?.SetValue("AllowTelemetry", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64_2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection", writable: true))
                    {
                        key64_2?.SetValue("AllowTelemetry", 0, RegistryValueKind.DWord);
                    }

                    // Imposta il valore nella vista a 32-bit
                    using (RegistryKey key32_1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection", writable: true))
                    {
                        key32_1?.SetValue("AllowTelemetry", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key32_2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection", writable: true))
                    {
                        key32_2?.SetValue("AllowTelemetry", 0, RegistryValueKind.DWord);
                    }

                    // Disabilita i task pianificati relativi alla telemetria
                    ExecutePowerShellScript(@"
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\ProgramDataUpdater"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Autochk\Proxy"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Customer Experience Improvement Program\Consolidator"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Customer Experience Improvement Program\UsbCeip"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\DiskDiagnostic\Microsoft-Windows-DiskDiagnosticDataCollector"";
        ");
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaTelemetria", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tracking"))
            {
                SetCheckboxState("DisabilitaTracking", true);

                try
                {
                    // Imposta il valore nella vista a 64-bit
                    using (RegistryKey key64_1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location", writable: true))
                    {
                        key64_1?.SetValue("Value", "Deny", RegistryValueKind.String);
                    }

                    using (RegistryKey key64_2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}", writable: true))
                    {
                        key64_2?.SetValue("SensorPermissionState", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64_3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .OpenSubKey(@"SYSTEM\CurrentControlSet\Services\lfsvc\Service\Configuration", writable: true))
                    {
                        key64_3?.SetValue("Status", 0, RegistryValueKind.DWord);
                    }

                    // Imposta il valore nella vista a 32-bit
                    using (RegistryKey key32_1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location", writable: true))
                    {
                        key32_1?.SetValue("Value", "Deny", RegistryValueKind.String);
                    }

                    using (RegistryKey key32_2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}", writable: true))
                    {
                        key32_2?.SetValue("SensorPermissionState", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key32_3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .OpenSubKey(@"SYSTEM\CurrentControlSet\Services\lfsvc\Service\Configuration", writable: true))
                    {
                        key32_3?.SetValue("Status", 0, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaTracking", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Segnalazione Errori"))
            {
                SetCheckboxState("DisabilitaSegnalazioneErrori", true);

                try
                {
                    // Imposta il valore nella vista a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                              .OpenSubKey(@"SOFTWARE\Microsoft\Windows\Windows Error Reporting", writable: true))
                    {
                        key64?.SetValue("Disabled", 1, RegistryValueKind.DWord);
                    }

                    // Imposta il valore nella vista a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                              .OpenSubKey(@"SOFTWARE\Microsoft\Windows\Windows Error Reporting", writable: true))
                    {
                        key32?.SetValue("Disabled", 1, RegistryValueKind.DWord);
                    }

                    // Disabilita il task schedulato "QueueReporting"
                    using (Microsoft.Win32.TaskScheduler.TaskService ts = new Microsoft.Win32.TaskScheduler.TaskService())
                    {
                        Microsoft.Win32.TaskScheduler.Task task = ts.GetTask(@"Microsoft\Windows\Windows Error Reporting\QueueReporting");
                        if (task != null)
                        {
                            task.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaSegnalazioneErrori", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tracking Diagnostica"))
            {
                SetCheckboxState("DisabilitaTrackingDiagnostica", true);

                try
                {
                    // Ferma il servizio "DiagTrack"
                    using (ServiceController service = new ServiceController("DiagTrack"))
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped);
                    }

                    // Imposta il tipo di avvio su disabilitato usando PowerShell
                    ExecutePowerShellScript(@"Set-Service -Name 'DiagTrack' -StartupType Disabled -ErrorAction SilentlyContinue");

                    // Imposta il valore nel registro per la vista a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                          .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", writable: true))
                    {
                        key64?.SetValue("DisableDiagnostics", 1, RegistryValueKind.DWord);
                    }

                    // Imposta il valore nel registro per la vista a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                          .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", writable: true))
                    {
                        key32?.SetValue("DisableDiagnostics", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaTrackingDiagnostica", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita WAP Push Service"))
            {
                SetCheckboxState("DisabilitaWAPPushService", true);

                try
                {
                    // Ferma il servizio "dmwappushservice"
                    using (ServiceController service = new ServiceController("dmwappushservice"))
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped);
                    }

                    // Imposta il tipo di avvio su disabilitato usando PowerShell
                    ExecutePowerShellScript(@"Stop-Service -Name 'dmwappushservice' -WarningAction SilentlyContinue;
                Set-Service -Name 'dmwappushservice' -StartupType Disabled");

                    // Imposta il valore nel registro per la vista a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                          .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", writable: true))
                    {
                        key64?.SetValue("DisableWAPPushService", 1, RegistryValueKind.DWord);
                    }

                    // Imposta il valore nel registro per la vista a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                          .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", writable: true))
                    {
                        key32?.SetValue("DisableWAPPushService", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaWAPPushService", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disbailita Home Group"))
            {
                SetCheckboxState("DisbailitaHomeGroup", true);

                try
                {
                    // Ferma i servizi HomeGroup
                    using (ServiceController listenerService = new ServiceController("HomeGroupListener"))
                    {
                        listenerService.Stop();
                        listenerService.WaitForStatus(ServiceControllerStatus.Stopped);
                    }

                    using (ServiceController providerService = new ServiceController("HomeGroupProvider"))
                    {
                        providerService.Stop();
                        providerService.WaitForStatus(ServiceControllerStatus.Stopped);
                    }

                    // Imposta il tipo di avvio su disabilitato usando PowerShell
                    ExecutePowerShellScript(@"Stop-Service -Name 'HomeGroupListener' -WarningAction SilentlyContinue;
                Set-Service -Name 'HomeGroupListener' -StartupType Disabled;
                Stop-Service -Name 'HomeGroupProvider' -WarningAction SilentlyContinue;
                Set-Service -Name 'HomeGroupProvider' -StartupType Disabled;");

                    // Imposta il valore nel registro per la vista a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                          .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", writable: true))
                    {
                        key64?.SetValue("DisableHomeGroup", 1, RegistryValueKind.DWord);
                    }

                    // Imposta il valore nel registro per la vista a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                          .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", writable: true))
                    {
                        key32?.SetValue("DisableHomeGroup", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisbailitaHomeGroup", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Assistenza Remota"))
            {
                SetCheckboxState("DisabilitaAssistenzaRemota", true);

                try
                {
                    // Imposta il valore nel registro per la vista a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                          .OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Remote Assistance", writable: true))
                    {
                        key64?.SetValue("fAllowToGetHelp", 0, RegistryValueKind.DWord);
                    }

                    // Imposta il valore nel registro per la vista a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                          .OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Remote Assistance", writable: true))
                    {
                        key32?.SetValue("fAllowToGetHelp", 0, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaAssistenzaRemota", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disbailita Schedul Defrag"))
            {
                SetCheckboxState("DisbailitaSchedulDefrag", true);
                ExecutePowerShellScript(@"Disable-ScheduledTask -TaskName \""Microsoft\\Windows\\Defrag\\ScheduledDefrag\""");
            }
            else
            {
                SetCheckboxState("DisbailitaSchedulDefrag", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Xbox Features"))
            {
                SetCheckboxState("DisabilitaXboxFeatures", true);

                try
                {
                    // Rimuovi le app Xbox
                    ExecutePowerShellScript(@"
                Get-AppxPackage ""Microsoft.XboxApp"" | Remove-AppxPackage -ErrorAction SilentlyContinue;
                Get-AppxPackage ""Microsoft.XboxIdentityProvider"" | Remove-AppxPackage -ErrorAction SilentlyContinue;
                Get-AppxPackage ""Microsoft.XboxSpeechToTextOverlay"" | Remove-AppxPackage -ErrorAction SilentlyContinue;
                Get-AppxPackage ""Microsoft.XboxGameOverlay"" | Remove-AppxPackage -ErrorAction SilentlyContinue;
                Get-AppxPackage ""Microsoft.Xbox.TCUI"" | Remove-AppxPackage -ErrorAction SilentlyContinue;
            ");

                    // Imposta il valore GameDVR_Enabled nel registro a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32)
                                                             .OpenSubKey(@"System\GameConfigStore", writable: true))
                    {
                        key32?.SetValue("GameDVR_Enabled", 0, RegistryValueKind.DWord);
                    }

                    // Imposta il valore AllowGameDVR nel registro a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\GameDVR", writable: true))
                    {
                        key64?.SetValue("AllowGameDVR", 0, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaXboxFeatures", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Auto Manteinance"))
            {
                SetCheckboxState("DisabilitaAutoManteinance", true);

                try
                {
                    // Imposta il valore MaintenanceDisabled nel registro a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance", writable: true))
                    {
                        key64?.SetValue("MaintenanceDisabled", 1, RegistryValueKind.DWord);
                    }

                    // Imposta il valore MaintenanceDisabled nel registro a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance", writable: true))
                    {
                        key32?.SetValue("MaintenanceDisabled", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaAutoManteinance", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Spazio Riservato"))
            {
                SetCheckboxState("DisabilitaSpazioRiservato", true);

                try
                {
                    // Esegui il comando PowerShell per disabilitare lo spazio riservato
                    ExecutePowerShellScript(@"Set-WindowsReservedStorageState -State Disabled");

                    // Imposta le chiavi di registro per la configurazione a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ReservedStorage", writable: true))
                    {
                        key64?.SetValue("ReservedStorageState", 0, RegistryValueKind.DWord);
                    }

                    // Imposta le chiavi di registro per la configurazione a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ReservedStorage", writable: true))
                    {
                        key32?.SetValue("ReservedStorageState", 0, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaSpazioRiservato", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Tweaks Game DVR"))
            {
                SetCheckboxState("DisabilitaTweaksGameDVR", true);

                try
                {
                    // Esegui il comando PowerShell per impostare le proprietà di Game DVR per entrambe le architetture
                    ExecutePowerShellScript(@"
                Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -Type Hex -Value 00000000;
                Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -Type Hex -Value 00000000;
                Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_EFSEFeatureFlags"" -Type Hex -Value 00000000;
                Set-ItemProperty -Path ""HKLM:\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -Type DWord -Value 00000000;
            ", false); // Chiama il PowerShell per 64 bit

                    ExecutePowerShellScript(@"
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\WOW6432Node\System\GameConfigStore"" -Name ""GameDVR_DXGIHonorFSEWindowsCompatible"" -Type Hex -Value 00000000;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\WOW6432Node\System\GameConfigStore"" -Name ""GameDVR_HonorUserFSEBehaviorMode"" -Type Hex -Value 00000000;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\WOW6432Node\System\GameConfigStore"" -Name ""GameDVR_EFSEFeatureFlags"" -Type Hex -Value 00000000;
                Set-ItemProperty -Path ""HKLM:\SOFTWARE\WOW6432Node\System\GameConfigStore"" -Name ""GameDVR_Enabled"" -Type DWord -Value 00000000;
            ", true); // Chiama il PowerShell per 32 bit

                    // Imposta le chiavi di registro per la configurazione a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .OpenSubKey(@"SYSTEM\GameConfigStore", writable: true))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("GameDVR_DXGIHonorFSEWindowsCompatible", 0, RegistryValueKind.Binary);
                            key64.SetValue("GameDVR_HonorUserFSEBehaviorMode", 0, RegistryValueKind.Binary);
                            key64.SetValue("GameDVR_EFSEFeatureFlags", 0, RegistryValueKind.Binary);
                            key64.SetValue("GameDVR_Enabled", 0, RegistryValueKind.DWord);
                        }
                    }

                    // Imposta le chiavi di registro per la configurazione a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .OpenSubKey(@"SYSTEM\GameConfigStore", writable: true))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("GameDVR_DXGIHonorFSEWindowsCompatible", 0, RegistryValueKind.Binary);
                            key32.SetValue("GameDVR_HonorUserFSEBehaviorMode", 0, RegistryValueKind.Binary);
                            key32.SetValue("GameDVR_EFSEFeatureFlags", 0, RegistryValueKind.Binary);
                            key32.SetValue("GameDVR_Enabled", 0, RegistryValueKind.DWord);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaTweaksGameDVR", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Storia Attivita"))
            {
                SetCheckboxState("DisabilitaStoriaAttivita", true);

                try
                {
                    // Imposta le chiavi di registro per la configurazione a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System"))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("EnableActivityFeed", 0, RegistryValueKind.DWord);
                            key64.SetValue("PublishUserActivities", 0, RegistryValueKind.DWord);
                            key64.SetValue("UploadUserActivities", 0, RegistryValueKind.DWord);
                        }
                    }

                    // Imposta le chiavi di registro per la configurazione a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System"))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("EnableActivityFeed", 0, RegistryValueKind.DWord);
                            key32.SetValue("PublishUserActivities", 0, RegistryValueKind.DWord);
                            key32.SetValue("UploadUserActivities", 0, RegistryValueKind.DWord);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaStoriaAttivita", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Opzioni Lingua"))
            {
                SetCheckboxState("AbilitaOpzioniLingua", true);

                try
                {
                    // Imposta la chiave di registro per abilitare le opzioni lingua a livello di utente
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Control Panel\International\User Profile"))
                    {
                        key?.SetValue("HttpAcceptLanguageOptOut", 0, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaOpzioniLingua", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Suggerimenti App"))
            {
                SetCheckboxState("AbilitaSuggerimentiApp", true);

                try
                {
                    // Chiave di registro per le impostazioni del ContentDeliveryManager
                    string contentDeliveryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";

                    // Imposta i valori per abilitare i suggerimenti delle app
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(contentDeliveryPath))
                    {
                        if (key != null)
                        {
                            key.SetValue("ContentDeliveryAllowed", 1, RegistryValueKind.DWord);
                            key.SetValue("OemPreInstalledAppsEnabled", 1, RegistryValueKind.DWord);
                            key.SetValue("PreInstalledAppsEnabled", 1, RegistryValueKind.DWord);
                            key.SetValue("PreInstalledAppsEverEnabled", 1, RegistryValueKind.DWord);
                            key.SetValue("SilentInstalledAppsEnabled", 1, RegistryValueKind.DWord);
                            key.SetValue("SubscribedContent-338388Enabled", 1, RegistryValueKind.DWord);
                            key.SetValue("SubscribedContent-338389Enabled", 1, RegistryValueKind.DWord);
                            key.SetValue("SystemPaneSuggestionsEnabled", 1, RegistryValueKind.DWord);

                            // Rimuove le chiavi non necessarie, se esistono
                            key.DeleteValue("SubscribedContent-338387Enabled", false);
                            key.DeleteValue("SubscribedContent-353698Enabled", false);
                        }
                    }

                    // Rimuovi la chiave dalla sezione Policies se esiste
                    string cloudContentPath = @"SOFTWARE\Policies\Microsoft\Windows\CloudContent";
                    using (RegistryKey policyKey = Registry.LocalMachine.OpenSubKey(cloudContentPath, writable: true))
                    {
                        policyKey?.DeleteValue("DisableWindowsConsumerFeatures", false);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaSuggerimentiApp", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Telemetria"))
            {
                SetCheckboxState("AbilitaTelemetria", true);

                try
                {
                    // Chiave di registro per la telemetria
                    string dataCollectionPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection";
                    string wow6432NodePath = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection";
                    string policiesPath = @"SOFTWARE\Policies\Microsoft\Windows\DataCollection";

                    // Imposta i valori per abilitare la telemetria
                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(dataCollectionPath))
                    {
                        key?.SetValue("AllowTelemetry", 3, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(wow6432NodePath))
                    {
                        key?.SetValue("AllowTelemetry", 3, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(policiesPath))
                    {
                        key?.SetValue("AllowTelemetry", 3, RegistryValueKind.DWord);
                    }

                    // Avvia i servizi necessari
                    StartService("DiagTrack");
                    StartService("dmwappushservice");
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaTelemetria", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tracking"))
            {
                SetCheckboxState("AbilitaTracking", true);

                try
                {
                    // Chiave di registro per la configurazione del tracking
                    string capabilityAccessPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location";
                    string sensorOverridesPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}";
                    string serviceConfigurationPath = @"SYSTEM\CurrentControlSet\Services\lfsvc\Service\Configuration";

                    // Imposta il valore per consentire il tracking della posizione
                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(capabilityAccessPath))
                    {
                        key?.SetValue("Value", "Allow", RegistryValueKind.String);
                    }

                    // Imposta lo stato del permesso del sensore
                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(sensorOverridesPath))
                    {
                        key?.SetValue("SensorPermissionState", 1, RegistryValueKind.DWord);
                    }

                    // Abilita il servizio lfsvc
                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(serviceConfigurationPath))
                    {
                        key?.SetValue("Status", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaTracking", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Segnalazione Errori"))
            {
                SetCheckboxState("AbilitaSegnalazioneErrori", true);

                try
                {
                    // Rimuovi la chiave 'Disabled' per il registro 64 bit
                    string errorReportingPath64 = @"SOFTWARE\Microsoft\Windows\Windows Error Reporting";
                    using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(errorReportingPath64, writable: true))
                    {
                        key64?.DeleteValue("Disabled", false);
                    }

                    // Rimuovi la chiave 'Disabled' per il registro 32 bit
                    string errorReportingPath32 = @"SOFTWARE\WOW6432Node\Microsoft\Windows\Windows Error Reporting";
                    using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(errorReportingPath32, writable: true))
                    {
                        key32?.DeleteValue("Disabled", false);
                    }

                    // Abilita il task pianificato per la segnalazione degli errori
                    using (var taskService = new TaskService())
                    {
                        var task = taskService.GetTask(@"Microsoft\Windows\Windows Error Reporting\QueueReporting");
                        if (task != null)
                        {
                            // Abilita il task se è disabilitato
                            if (task.State == TaskState.Disabled)
                            {
                                task.Enabled = true;
                                taskService.RootFolder.RegisterTaskDefinition(task.Name, task.Definition);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaSegnalazioneErrori", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tracking Diagnostica"))
            {
                SetCheckboxState("AbilitaTrackingDiagnostica", true);

                try
                {
                    // Imposta le chiavi di registro per la Tracking Diagnostica nel registro 64 bit
                    using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection", writable: true))
                    {
                        key64?.SetValue("AllowTelemetry", 3, RegistryValueKind.DWord); // Imposta il valore per la telemetria
                    }

                    // Imposta le chiavi di registro per la Tracking Diagnostica nel registro 32 bit
                    using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection", writable: true))
                    {
                        key32?.SetValue("AllowTelemetry", 3, RegistryValueKind.DWord); // Imposta il valore per la telemetria
                    }

                    // Configura e avvia il servizio DiagTrack
                    var service = new System.ServiceProcess.ServiceController("DiagTrack");
                    if (service.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                    {
                        service.Start();
                        service.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                    }

                    // Usa PowerShell per impostare il tipo di avvio su Automatico
                    ExecutePowerShellScript(@"Set-Service -Name 'DiagTrack' -StartupType 'Automatic'");

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaTrackingDiagnostica", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita WAP Push Service"))
            {
                SetCheckboxState("AbilitaWAPPushService", true);

                try
                {
                    // Imposta le chiavi di registro per WAP Push Service nel registro 64 bit
                    using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\dmwappushservice", writable: true))
                    {
                        key64?.SetValue("DelayedAutoStart", 1, RegistryValueKind.DWord); // Imposta DelayedAutoStart
                    }

                    // Imposta le chiavi di registro per WAP Push Service nel registro 32 bit
                    using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\WOW6432Node\CurrentControlSet\Services\dmwappushservice", writable: true))
                    {
                        key32?.SetValue("DelayedAutoStart", 1, RegistryValueKind.DWord); // Imposta DelayedAutoStart
                    }

                    // Configura e avvia il servizio dmwappushservice
                    var service = new System.ServiceProcess.ServiceController("dmwappushservice");
                    if (service.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                    {
                        service.Start();
                        service.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                    }

                    // Usa PowerShell per impostare il tipo di avvio su Automatico
                    ExecutePowerShellScript(@"Set-Service -Name 'dmwappushservice' -StartupType 'Automatic'");

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaWAPPushService", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Home Group"))
            {
                SetCheckboxState("AbilitaHomeGroup", true);

                try
                {
                    // Ferma i servizi HomeGroupListener e HomeGroupProvider se sono in esecuzione
                    StopService("HomeGroupListener");
                    SetServiceStartupType("HomeGroupListener", "Manual");

                    StopService("HomeGroupProvider");
                    SetServiceStartupType("HomeGroupProvider", "Manual");

                    // Usa PowerShell per fermare e configurare i servizi
                    ExecutePowerShellScript(@"
                Stop-Service -Name 'HomeGroupListener' -WarningAction SilentlyContinue;
                Set-Service -Name 'HomeGroupListener' -StartupType 'Manual';
                Stop-Service -Name 'HomeGroupProvider' -WarningAction SilentlyContinue;
                Set-Service -Name 'HomeGroupProvider' -StartupType 'Manual';
            ");
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaHomeGroup", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Assistenza Remota"))
            {
                SetCheckboxState("AbilitaAssistenzaRemota", true);

                try
                {
                    // Percorso del registro per l'assistenza remota
                    string remoteAssistanceKey64 = @"SYSTEM\CurrentControlSet\Control\Remote Assistance";
                    string remoteAssistanceKey32 = @"SOFTWARE\WOW6432Node\SYSTEM\CurrentControlSet\Control\Remote Assistance";

                    // Imposta il valore per il registro a 64 bit
                    using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(remoteAssistanceKey64, true))
                    {
                        key64?.SetValue("fAllowToGetHelp", 1, RegistryValueKind.DWord);
                    }

                    // Imposta il valore per il registro a 32 bit
                    using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(remoteAssistanceKey32, true))
                    {
                        key32?.SetValue("fAllowToGetHelp", 1, RegistryValueKind.DWord);
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaAssistenzaRemota", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Schedul Defrag"))
            {
                SetCheckboxState("AbilitaSchedulDefrag", true);

                try
                {
                    // Abilitare il Task di Defrag
                    using (TaskService ts = new TaskService())
                    {
                        Microsoft.Win32.TaskScheduler.Task task = ts.FindTask("Microsoft\\Windows\\Defrag\\ScheduledDefrag");

                        if (task != null)
                        {
                            // Abilita il task
                            task.Enabled = true;

                        }
                        else
                        {

                        }
                    }

                    // Modifica le chiavi del registro sia a 32 che a 64 bit
                    ModifyRegistryForDefrag(true);  // Per 32 bit
                    ModifyRegistryForDefrag(false); // Per 64 bit
                }
                catch (UnauthorizedAccessException)
                {

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaSchedulDefrag", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Xbox Features"))
            {
                SetCheckboxState("AbilitaXboxFeatures", true);
                ExecutePowerShellScript(@"Get-AppxPackage -AllUsers """"Microsoft.XboxApp"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Get-AppxPackage -AllUsers """"Microsoft.XboxIdentityProvider"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Get-AppxPackage -AllUsers """"Microsoft.XboxSpeechToTextOverlay"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Get-AppxPackage -AllUsers """"Microsoft.XboxGameOverlay"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Get-AppxPackage -AllUsers """"Microsoft.Xbox.TCUI"""" | ForEach {Add-AppxPackage -DisableDevelopmentMode -Register """"$($_.InstallLocation)\AppXManifest.xml""""};
                     Set-ItemProperty -Path """"HKCU:\System\GameConfigStore"""" -Name """"GameDVR_Enabled"""" -Type DWord -Value 1;
                     Remove-ItemProperty -Path """"HKLM:\SOFTWARE\Policies\Microsoft\Windows\GameDVR"""" -Name """"AllowGameDVR"""" -ErrorAction SilentlyContinue""");
            }
            else
            {
                SetCheckboxState("AbilitaXboxFeatures", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Auto Manteinance"))
            {
                SetCheckboxState("AbilitaAutoManteinance", true);
                try
                {
                    // Modifica le chiavi di registro per abilitare Auto Maintenance nel registro 64 bit
                    using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance", writable: true))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("MaintenanceDisabled", 0, RegistryValueKind.DWord); // Imposta il valore per abilitare Auto Maintenance
                        }
                        else
                        {

                        }
                    }

                    // Modifica le chiavi di registro per abilitare Auto Maintenance nel registro 32 bit
                    using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance", writable: true))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("MaintenanceDisabled", 0, RegistryValueKind.DWord); // Imposta il valore per abilitare Auto Maintenance
                        }
                        else
                        {

                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaAutoManteinance", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Spazio Riservato"))
            {
                SetCheckboxState("AbilitaSpazioRiservato", true);
                ExecutePowerShellScript(@"Set-WindowsReservedStorageState -State Enabled");
            }
            else
            {
                SetCheckboxState("AbilitaSpazioRiservato", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tweaks Game DVR"))
            {
                SetCheckboxState("AbilitaTweaksGameDVR", true);
                try
                {
                    // Rimuovi le proprietà nel registro 64 bit
                    using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\GameConfigStore", writable: true))
                    {
                        if (key64 != null)
                        {
                            key64.DeleteValue("GameDVR_DXGIHonorFSEWindowsCompatible", throwOnMissingValue: false);
                            key64.DeleteValue("GameDVR_HonorUserFSEBehaviorMode", throwOnMissingValue: false);
                            key64.DeleteValue("GameDVR_EFSEFeatureFlags", throwOnMissingValue: false);
                            key64.DeleteValue("GameDVR_Enabled", throwOnMissingValue: false);
                        }
                        else
                        {

                        }
                    }

                    // Rimuovi le proprietà nel registro 32 bit
                    using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\SYSTEM\GameConfigStore", writable: true))
                    {
                        if (key32 != null)
                        {
                            key32.DeleteValue("GameDVR_DXGIHonorFSEWindowsCompatible", throwOnMissingValue: false);
                            key32.DeleteValue("GameDVR_HonorUserFSEBehaviorMode", throwOnMissingValue: false);
                            key32.DeleteValue("GameDVR_EFSEFeatureFlags", throwOnMissingValue: false);
                            key32.DeleteValue("GameDVR_Enabled", throwOnMissingValue: false);
                        }
                        else
                        {

                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaTweaksGameDVR", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Storie Attivita"))
            {
                SetCheckboxState("AbilitaStoriaAttivita", true);
                try
                {
                    // Imposta le chiavi di registro nel registro 64 bit
                    using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System", writable: true))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("EnableActivityFeed", 1, RegistryValueKind.DWord);
                            key64.SetValue("PublishUserActivities", 1, RegistryValueKind.DWord);
                            key64.SetValue("UploadUserActivities", 1, RegistryValueKind.DWord);
                        }
                        else
                        {

                        }
                    }

                    // Imposta le chiavi di registro nel registro 32 bit
                    using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Policies\Microsoft\Windows\System", writable: true))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("EnableActivityFeed", 1, RegistryValueKind.DWord);
                            key32.SetValue("PublishUserActivities", 1, RegistryValueKind.DWord);
                            key32.SetValue("UploadUserActivities", 1, RegistryValueKind.DWord);
                        }
                        else
                        {

                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaStoriaAttivita", false);
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StopService(string serviceName)
        {
            var service = new System.ServiceProcess.ServiceController(serviceName);
            if (service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            {
                service.Stop();
                service.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
            }
        }

        // Metodo per impostare il tipo di avvio di un servizio
        private void SetServiceStartupType(string serviceName, string startupType)
        {
            ExecutePowerShellScript($"Set-Service -Name '{serviceName}' -StartupType '{startupType}'");
        }

        private void StartService(string serviceName)
        {
            try
            {
                using (var serviceController = new ServiceController(serviceName))
                {
                    if (serviceController.Status != ServiceControllerStatus.Running)
                    {
                        // Imposta il tipo di avvio del servizio su Automatic
                        serviceController.Start();
                        serviceController.WaitForStatus(ServiceControllerStatus.Running);
                    }
                    // Setta il tipo di avvio su Automatic
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}", true))
                    {
                        key?.SetValue("Start", 2, RegistryValueKind.DWord); // 2 = Automatic
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ModifyRegistryForDefrag(bool is32Bit)
        {
            try
            {
                string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Defrag";
                RegistryKey registryKey;

                if (is32Bit)
                {
                    registryKey = Registry.LocalMachine.OpenSubKey(registryPath, true);
                }
                else
                {
                    registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(registryPath, true);
                }

                if (registryKey != null)
                {
                    // Modifica il valore per attivare la Schedulazione di Defrag
                    registryKey.SetValue("ScheduledDefrag", 1, RegistryValueKind.DWord);
                    registryKey.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
