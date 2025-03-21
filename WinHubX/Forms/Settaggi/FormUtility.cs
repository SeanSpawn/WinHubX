using Microsoft.Win32;
using System.Diagnostics;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormUtility : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        public FormUtility(FormSettaggi formSettaggi, Form1 form1)
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
            int index = DisabilitaUtility.Items.IndexOf("Disabilita Background App");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaBackgroundApp"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Feedback");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaFeedback"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Advertising ID");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaAdvertisingID"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Filtro Smart Screen");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaFiltroSmartScreen"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Wifi Sense");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaWifiSense"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Desktop Remoto");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaDesktopRemoto"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita attivazione del Numlock in avvio");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaattivazionedelNumlockinavvio"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita News e Interessi");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaNewseInteressi"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Index File");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaIndexFile"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Edge PDF");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaEdgePDF"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Mappe");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaMappe"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita UWP apps");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaUWPapps"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Esperienze Personalizzate Microsoft");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaEsperienzePersonalizzateMicrosoft"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Esperienze Personalizzate Microsoft");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaEsperienzePersonalizzateMicrosoft"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Storage Check");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaStorageCheck"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Superfetch");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaSuperfetch"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Ibernazione");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaIbernazione"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Ottimizzazione FullScreen");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaOttimizzazioneFullScreen"));
            }
            index = DisabilitaUtility.Items.IndexOf("Disabilita Avvio Rapido");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("DisabilitaAvvioRapido"));
            }
            index = DisabilitaUtility.Items.IndexOf("Normal Bandwidth");
            if (index != -1)
            {
                DisabilitaUtility.SetItemChecked(index, GetCheckboxState("NormalBandwidth"));
            }
            index = AbilitaUtility.Items.IndexOf("All Bandwidth");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AllBandwidth"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Storage Check");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaStorageCheck"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Superfetch");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaSuperfetch"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Ibernazione");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaIbernazione"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Ottimizzazione FullScreen");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaOttimizzazioneFullScreen"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Avvio Rapido");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaAvvioRapido"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Background App");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaBackgroundApp"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Feedback");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaFeedback"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Advertising ID");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaAdvertisingID"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Filtro Smart Screen");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaFiltroSmartScreen"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Wifi Sense");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaWifiSense"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Desktop Remoto");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaDesktopRemoto"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita attivazione del Numlock in avvio");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaattivazionedelNumlockinavvio"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita News e Interessi");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaNewseInteressi"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Risparmio Energetico Personalizzato");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaRisparmioEnergeticoPersonalizzato"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Mappe");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaMappe"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita UWP apps");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaUWPapps"));
            }
            index = AbilitaUtility.Items.IndexOf("Abilita Esperienze Personalizzate Microsoft");
            if (index != -1)
            {
                AbilitaUtility.SetItemChecked(index, GetCheckboxState("AbilitaEsperienzePersonalizzateMicrosoft"));
            }
        }

        private void btnAvviaSelezionatiUti_Click(object sender, EventArgs e)
        {
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Background App"))
            {
                SetCheckboxState("DisabilitaBackgroundApp", true);

                try
                {
                    // Imposta la chiave del registro di sistema per disabilitare le applicazioni in background (64-bit)
                    using (RegistryKey key64 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", true))
                    {
                        key64?.SetValue("GlobalUserDisabled", 1, RegistryValueKind.DWord);
                    }

                    // Imposta la chiave del registro di sistema per disabilitare le applicazioni in background (32-bit)
                    using (RegistryKey key32 = Registry.CurrentUser.OpenSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", true))
                    {
                        key32?.SetValue("GlobalUserDisabled", 1, RegistryValueKind.DWord);
                    }

                    // Disabilita tutte le applicazioni di background, esclusa Cortana
                    using (RegistryKey baseKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", true))
                    {
                        if (baseKey != null)
                        {
                            foreach (string subKeyName in baseKey.GetSubKeyNames())
                            {
                                if (!subKeyName.StartsWith("Microsoft.Windows.Cortana"))
                                {
                                    using (RegistryKey subKey = baseKey.OpenSubKey(subKeyName, true))
                                    {
                                        subKey?.SetValue("Disabled", 1, RegistryValueKind.DWord);
                                        subKey?.SetValue("DisabledByUser", 1, RegistryValueKind.DWord);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaBackgroundApp", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Feedback"))
            {
                SetCheckboxState("DisabilitaFeedback", true);

                try
                {
                    // Disabilita le impostazioni di feedback nel registro di sistema per 32-bit e 64-bit
                    // HKCU\SOFTWARE\Microsoft\Siuf\Rules
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\Siuf\Rules", true))
                    {
                        key32?.SetValue("NumberOfSIUFInPeriod", 0, RegistryValueKind.DWord);
                    }
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Siuf\Rules", true))
                    {
                        key64?.SetValue("NumberOfSIUFInPeriod", 0, RegistryValueKind.DWord);
                    }

                    // HKLM\SOFTWARE\Policies\Microsoft\Windows\DataCollection
                    using (RegistryKey key32LM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection", true))
                    {
                        key32LM?.SetValue("DoNotShowFeedbackNotifications", 1, RegistryValueKind.DWord);
                    }
                    using (RegistryKey key64LM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection", true))
                    {
                        key64LM?.SetValue("DoNotShowFeedbackNotifications", 1, RegistryValueKind.DWord);
                    }

                    // Disabilita i task di feedback programmati
                    DisableScheduledTask(@"Microsoft\Windows\Feedback\Siuf\DmClient");
                    DisableScheduledTask(@"Microsoft\Windows\Feedback\Siuf\DmClientOnScenarioDownload");
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaFeedback", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Advertising ID"))
            {
                SetCheckboxState("DisabilitaAdvertisingID", true);

                try
                {
                    // Disabilita Advertising ID nel registro sia per 32-bit che 64-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\AdvertisingInfo", true))
                    {
                        key32?.SetValue("DisabledByGroupPolicy", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\AdvertisingInfo", true))
                    {
                        key64?.SetValue("DisabledByGroupPolicy", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaAdvertisingID", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Filtro Smart Screen"))
            {
                SetCheckboxState("DisabilitaFiltroSmartScreen", true);

                try
                {
                    // Disabilita SmartScreen nel registro sia per 32-bit che 64-bit
                    // HKLM\SOFTWARE\Policies\Microsoft\Windows\System -> EnableSmartScreen
                    using (RegistryKey key32System = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System", true))
                    {
                        key32System?.SetValue("EnableSmartScreen", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64System = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System", true))
                    {
                        key64System?.SetValue("EnableSmartScreen", 0, RegistryValueKind.DWord);
                    }

                    // HKLM\SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter -> EnabledV9
                    using (RegistryKey key32Edge = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter", true))
                    {
                        key32Edge?.SetValue("EnabledV9", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64Edge = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter", true))
                    {
                        key64Edge?.SetValue("EnabledV9", 0, RegistryValueKind.DWord);
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaFiltroSmartScreen", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Wifi Sense"))
            {
                SetCheckboxState("DisabilitaWifiSense", true);

                try
                {
                    // Disabilita WiFi Sense nel registro sia per 32-bit che 64-bit

                    // HKLM\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowWiFiHotSpotReporting -> Value
                    using (RegistryKey key32WiFiHotSpot = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowWiFiHotSpotReporting", true))
                    {
                        key32WiFiHotSpot?.SetValue("Value", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64WiFiHotSpot = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowWiFiHotSpotReporting", true))
                    {
                        key64WiFiHotSpot?.SetValue("Value", 0, RegistryValueKind.DWord);
                    }

                    // HKLM\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots -> Value
                    using (RegistryKey key32AutoConnect = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots", true))
                    {
                        key32AutoConnect?.SetValue("Value", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64AutoConnect = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots", true))
                    {
                        key64AutoConnect?.SetValue("Value", 0, RegistryValueKind.DWord);
                    }

                    // HKLM\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config -> AutoConnectAllowedOEM
                    using (RegistryKey key32OEM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true))
                    {
                        key32OEM?.SetValue("AutoConnectAllowedOEM", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64OEM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true))
                    {
                        key64OEM?.SetValue("AutoConnectAllowedOEM", 0, RegistryValueKind.DWord);
                    }

                    // HKLM\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config -> WiFISenseAllowed
                    using (RegistryKey key32SenseAllowed = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true))
                    {
                        key32SenseAllowed?.SetValue("WiFISenseAllowed", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64SenseAllowed = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true))
                    {
                        key64SenseAllowed?.SetValue("WiFISenseAllowed", 0, RegistryValueKind.DWord);
                    }

                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaWifiSense", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Desktop Remoto"))
            {
                SetCheckboxState("DisabilitaDesktopRemoto", true);

                try
                {
                    // Disabilita Desktop Remoto nel registro sia per 32-bit che 64-bit

                    // HKLM\SYSTEM\CurrentControlSet\Control\Terminal Server -> fDenyTSConnections
                    using (RegistryKey key32TSConnections = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server", true))
                    {
                        key32TSConnections?.SetValue("fDenyTSConnections", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64TSConnections = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server", true))
                    {
                        key64TSConnections?.SetValue("fDenyTSConnections", 1, RegistryValueKind.DWord);
                    }

                    // HKLM\SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp -> UserAuthentication
                    using (RegistryKey key32UserAuth = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp", true))
                    {
                        key32UserAuth?.SetValue("UserAuthentication", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64UserAuth = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp", true))
                    {
                        key64UserAuth?.SetValue("UserAuthentication", 1, RegistryValueKind.DWord);
                    }


                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaDesktopRemoto", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita attivazione del Numlock in avvio"))
            {
                SetCheckboxState("DisabilitaattivazionedelNumlockinavvio", true);

                try
                {
                    // Impostare "InitialKeyboardIndicators" a 2147483648 (disabilita NumLock all'avvio)

                    // Registro a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry32).OpenSubKey(@".DEFAULT\Control Panel\Keyboard", true))
                    {
                        key32?.SetValue("InitialKeyboardIndicators", 2147483648, RegistryValueKind.DWord);
                    }

                    // Registro a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry64).OpenSubKey(@".DEFAULT\Control Panel\Keyboard", true))
                    {
                        key64?.SetValue("InitialKeyboardIndicators", 2147483648, RegistryValueKind.DWord);
                    }

                    // Disattivare il NumLock se attualmente attivo
                    if (Control.IsKeyLocked(Keys.NumLock))
                    {
                        // Simula il tasto NumLock per disattivarlo
                        SendKeys.SendWait("{NUMLOCK}");
                    }


                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaattivazionedelNumlockinavvio", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita News e Interessi"))
            {
                SetCheckboxState("DisabilitaNewseInteressi", true);

                try
                {
                    // Chiude il processo di Explorer
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "taskkill",
                        Arguments = "/IM explorer.exe /F",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }).WaitForExit();

                    // Imposta il valore di ShellFeedsTaskbarViewMode e IsFeedsAvailable per CurrentUser (registro a 32 e 64 bit)
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Feeds"))
                    {
                        key32?.SetValue("ShellFeedsTaskbarViewMode", 2, RegistryValueKind.DWord);
                        key32?.SetValue("IsFeedsAvailable", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Feeds"))
                    {
                        key64?.SetValue("ShellFeedsTaskbarViewMode", 2, RegistryValueKind.DWord);
                        key64?.SetValue("IsFeedsAvailable", 0, RegistryValueKind.DWord);
                    }

                    // Imposta il valore di EnableFeeds per LocalMachine (registro a 32 e 64 bit)
                    using (RegistryKey keyLM32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Windows Feeds"))
                    {
                        keyLM32?.SetValue("EnableFeeds", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey keyLM64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Windows Feeds"))
                    {
                        keyLM64?.SetValue("EnableFeeds", 0, RegistryValueKind.DWord);
                    }

                    // Riavvia il processo di Explorer
                    RestartExplorer();

                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaNewseInteressi", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Index File"))
            {
                SetCheckboxState("DisabilitaIndexFile", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Arguments = @"
                $obj = Get-WmiObject -Class Win32_Volume -Filter ""DriveLetter='$Drive'"";
                $indexing = $obj.IndexingEnabled;
                if ($indexing -eq $True) {
                    $obj | Set-WmiInstance -Arguments @{IndexingEnabled=$False} | Out-Null
                }
            ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaIndexFile", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Edge PDF"))
            {
                SetCheckboxState("DisabilitaEdgePDF", true);
                try
                {
                    // Imposta le chiavi di registro per disabilitare Edge PDF
                    string pdfKeyPath = @"Software\Classes\.pdf";
                    string openWithProgidsPath = @"Software\Classes\.pdf\OpenWithProgids";
                    string openWithListPath = @"Software\Classes\.pdf\OpenWithList";

                    // Chiavi a 32-bit
                    using (RegistryKey pdfKey32 = Registry.CurrentUser.CreateSubKey(pdfKeyPath))
                    {
                        if (pdfKey32 != null)
                        {
                            pdfKey32.SetValue("NoOpenWith", "", RegistryValueKind.String);
                            pdfKey32.SetValue("NoStaticDefaultVerb", "", RegistryValueKind.String);
                        }
                    }

                    using (RegistryKey openWithProgidsKey32 = Registry.CurrentUser.CreateSubKey(openWithProgidsPath))
                    {
                        if (openWithProgidsKey32 != null)
                        {
                            openWithProgidsKey32.SetValue("NoOpenWith", "", RegistryValueKind.String);
                            openWithProgidsKey32.SetValue("NoStaticDefaultVerb", "", RegistryValueKind.String);
                        }
                    }

                    using (RegistryKey openWithListKey32 = Registry.CurrentUser.CreateSubKey(openWithListPath))
                    {
                        if (openWithListKey32 != null)
                        {
                            openWithListKey32.SetValue("NoOpenWith", "", RegistryValueKind.String);
                            openWithListKey32.SetValue("NoStaticDefaultVerb", "", RegistryValueKind.String);
                        }
                    }

                    // Chiavi a 64-bit
                    string edgeKeyPath = @"Software\Classes\AppXd4nrz8ff68srnhf9t5a8sbjyar1cr723_";

                    using (RegistryKey edgeKey64 = Registry.CurrentUser.CreateSubKey(edgeKeyPath))
                    {
                        edgeKey64?.SetValue("AppXd4nrz8ff68srnhf9t5a8sbjyar1cr723_", "", RegistryValueKind.String);
                    }


                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaEdgePDF", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Mappe"))
            {
                SetCheckboxState("DisabilitaMappe", true);
                try
                {
                    // Imposta il valore di AutoUpdateEnabled a 0 nel registro di sistema (32 bit)
                    using (RegistryKey key32 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Maps"))
                    {
                        key32?.SetValue("AutoUpdateEnabled", 0, RegistryValueKind.DWord);
                    }

                    // Imposta il valore di AutoUpdateEnabled a 0 nel registro di sistema (64 bit)
                    using (RegistryKey key64 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Maps"))
                    {
                        key64?.SetValue("AutoUpdateEnabled", 0, RegistryValueKind.DWord);
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaMappe", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita UWP apps"))
            {
                SetCheckboxState("DisabilitaUWPapps", true);
                try
                {
                    // Verifica la versione di Windows
                    Version osVersion = Environment.OSVersion.Version;
                    if (osVersion.Build >= 17763)
                    {
                        // Crea la chiave di registro AppPrivacy se non esiste
                        using (RegistryKey appPrivacyKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\AppPrivacy"))
                        {
                            if (appPrivacyKey != null)
                            {
                                appPrivacyKey.SetValue("LetAppsRunInBackground", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsActivateWithVoice", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsActivateWithVoiceAboveLock", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessNotifications", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessAccountInfo", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessContacts", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessCalendar", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessPhone", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessCallHistory", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessEmail", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessTasks", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessMessaging", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsAccessRadios", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsSyncWithDevices", 2, RegistryValueKind.DWord);
                                appPrivacyKey.SetValue("LetAppsGetDiagnosticInfo", 2, RegistryValueKind.DWord);
                            }
                        }

                        // Impostazioni di accesso alla libreria
                        using (RegistryKey capabilityAccessKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore"))
                        {
                            if (capabilityAccessKey != null)
                            {
                                capabilityAccessKey.CreateSubKey("documentsLibrary")?.SetValue("Value", "Deny", RegistryValueKind.String);
                                capabilityAccessKey.CreateSubKey("picturesLibrary")?.SetValue("Value", "Deny", RegistryValueKind.String);
                                capabilityAccessKey.CreateSubKey("videosLibrary")?.SetValue("Value", "Deny", RegistryValueKind.String);
                                capabilityAccessKey.CreateSubKey("broadFileSystemAccess")?.SetValue("Value", "Deny", RegistryValueKind.String);
                            }
                        }

                        // Imposta SwapfileControl
                        using (RegistryKey memoryManagementKey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management"))
                        {
                            memoryManagementKey?.SetValue("SwapfileControl", 0, RegistryValueKind.DWord);
                        }
                    }
                    else
                    {
                        // Disabilita le app UWP su versioni precedenti
                        using (RegistryKey backgroundAccessKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", true))
                        {
                            if (backgroundAccessKey != null)
                            {
                                foreach (var subKey in backgroundAccessKey.GetSubKeyNames())
                                {
                                    if (!subKey.StartsWith("Microsoft.Windows.Cortana") && !subKey.StartsWith("Microsoft.Windows.ShellExperienceHost"))
                                    {
                                        using (var appKey = backgroundAccessKey.OpenSubKey(subKey, true))
                                        {
                                            appKey?.SetValue("Disabled", 1, RegistryValueKind.DWord);
                                            appKey?.SetValue("DisabledByUser", 1, RegistryValueKind.DWord);
                                        }
                                    }
                                }
                            }
                        }
                    }


                }
                catch (Exception)
                {
                }
            }
            else
            {
                SetCheckboxState("DisabilitaUWPapps", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Esperienze Personalizzate Microsoft"))
            {
                SetCheckboxState("DisabilitaEsperienzePersonalizzateMicrosoft", true);
                try
                {
                    // Modifica le impostazioni nel registro a 64 bit
                    using (var systemKey64 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System"))
                    {
                        if (systemKey64 != null)
                        {
                            systemKey64.SetValue("EnableCdp", 0, RegistryValueKind.DWord);
                            systemKey64.SetValue("EnableMmx", 0, RegistryValueKind.DWord);
                        }
                    }

                    // Modifica le impostazioni nel registro a 32 bit (WOW6432Node)
                    using (var systemKey32 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\WOW6432Node\Policies\Microsoft\Windows\System"))
                    {
                        if (systemKey32 != null)
                        {
                            systemKey32.SetValue("EnableCdp", 0, RegistryValueKind.DWord);
                            systemKey32.SetValue("EnableMmx", 0, RegistryValueKind.DWord);
                        }
                    }

                    // Impostazioni per l'utente corrente
                    using (var cloudContentKey64 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent"))
                    {
                        cloudContentKey64?.SetValue("DisableTailoredExperiencesWithDiagnosticData", 1, RegistryValueKind.DWord);
                    }

                    using (var cloudContentKey32 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WOW6432Node\Policies\Microsoft\Windows\CloudContent"))
                    {
                        cloudContentKey32?.SetValue("DisableTailoredExperiencesWithDiagnosticData", 1, RegistryValueKind.DWord);
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaEsperienzePersonalizzateMicrosoft", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Storage Check"))
            {
                SetCheckboxState("DisabilitaStorageCheck", true);
                try
                {
                    // Elimina la chiave nella vista a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        key64.DeleteSubKeyTree(@"SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy", false);
                    }
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32))
                    {
                        key32.DeleteSubKeyTree(@"SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy", false);
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaStorageCheck", false);
            }
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Superfetch"))
            {
                SetCheckboxState("DisabilitaSuperfetch", true);
                try
                {
                    // Disabilita il servizio SysMain (Superfetch)
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Services\SysMain", "Start", 4); // 4 = Disabled
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaSuperfetch", false);
            }

            // Disabilita Storage Check
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Storage Check"))
            {
                SetCheckboxState("DisabilitaStorageCheck", true);
                try
                {
                    // Rimuove la chiave di StoragePolicy
                    DeleteRegistryKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters", "StoragePolicy", RegistryView.Registry32);
                    DeleteRegistryKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters", "StoragePolicy", RegistryView.Registry64);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaStorageCheck", false);
            }

            // Disabilita Ibernazione
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Ibernazione"))
            {
                SetCheckboxState("DisabilitaIbernazione", true);
                try
                {
                    // Disabilita l'ibernazione
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power", "HibernateEnabled", 0);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings", "ShowHibernateOption", 0);

                    // Disabilita ibernazione tramite comando (richiede amministrazione)
                    System.Diagnostics.Process.Start("cmd.exe", "/C powercfg /hibernate off");
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaIbernazione", false);
            }

            // Disabilita Ottimizzazione FullScreen
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Ottimizzazione FullScreen"))
            {
                SetCheckboxState("DisabilitaOttimizzazioneFullScreen", true);
                try
                {
                    SetRegistryValue(@"System\GameConfigStore", "GameDVR_DXGIHonorFSEWindowsCompatible", 1, RegistryView.Registry32);
                    SetRegistryValue(@"System\GameConfigStore", "GameDVR_DXGIHonorFSEWindowsCompatible", 1, RegistryView.Registry64);
                    SetRegistryValue(@"System\GameConfigStore", "GameDVR_FSEBehavior", 2, RegistryView.Registry32);
                    SetRegistryValue(@"System\GameConfigStore", "GameDVR_FSEBehavior", 2, RegistryView.Registry64);
                    SetRegistryValue(@"System\GameConfigStore", "GameDVR_FSEBehaviorMode", 2, RegistryView.Registry32);
                    SetRegistryValue(@"System\GameConfigStore", "GameDVR_FSEBehaviorMode", 2, RegistryView.Registry64);
                    SetRegistryValue(@"System\GameConfigStore", "GameDVR_HonorUserFSEBehaviorMode", 1, RegistryView.Registry32);
                    SetRegistryValue(@"System\GameConfigStore", "GameDVR_HonorUserFSEBehaviorMode", 1, RegistryView.Registry64);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaOttimizzazioneFullScreen", false);
            }

            // Disabilita Avvio Rapido
            if (DisabilitaUtility.CheckedItems.Contains("Disabilita Avvio Rapido"))
            {
                SetCheckboxState("DisabilitaAvvioRapido", true);
                try
                {
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power", "HiberbootEnabled", 0);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaAvvioRapido", false);
            }

            // Normal Bandwidth
            if (DisabilitaUtility.CheckedItems.Contains("Normal Bandwidth"))
            {
                SetCheckboxState("NormalBandwidth", true);
                try
                {
                    DeleteRegistryKey(@"SOFTWARE\Policies\Microsoft\Psched", "NonBestEffortLimit", RegistryView.Registry32);
                    DeleteRegistryKey(@"SOFTWARE\Policies\Microsoft\Psched", "NonBestEffortLimit", RegistryView.Registry64);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("NormalBandwidth", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Storage Check"))
            {
                SetCheckboxState("AbilitaStorageCheck", true);

                try
                {
                    // Percorso del registro per Storage Sense
                    string storagePolicyKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\StorageSense\Parameters\StoragePolicy";

                    // Imposta il valore per le chiavi specificate sia per 32 che per 64 bit
                    using (RegistryKey key32 = Registry.CurrentUser.OpenSubKey(storagePolicyKey, true))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("01", 1, RegistryValueKind.DWord);
                            key32.SetValue("04", 1, RegistryValueKind.DWord);
                            key32.SetValue("08", 1, RegistryValueKind.DWord);
                            key32.SetValue("32", 0, RegistryValueKind.DWord);
                            key32.SetValue("StoragePoliciesNotified", 1, RegistryValueKind.DWord);
                        }
                        else
                        {

                        }
                    }

                    // Per la versione a 64 bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(storagePolicyKey, true))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("01", 1, RegistryValueKind.DWord);
                            key64.SetValue("04", 1, RegistryValueKind.DWord);
                            key64.SetValue("08", 1, RegistryValueKind.DWord);
                            key64.SetValue("32", 0, RegistryValueKind.DWord);
                            key64.SetValue("StoragePoliciesNotified", 1, RegistryValueKind.DWord);
                        }
                        else
                        {

                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaStorageCheck", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Superfetch"))
            {
                SetCheckboxState("AbilitaSuperfetch", true);
                try
                {
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Services\SysMain", "Start", 2, RegistryView.Registry32); // 2 = Automatic
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Services\SysMain", "Start", 2, RegistryView.Registry64);
                    System.Diagnostics.Process.Start("cmd.exe", "/C sc start SysMain");
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaSuperfetch", false);
            }

            // Abilita Ibernazione
            if (AbilitaUtility.CheckedItems.Contains("Abilita Ibernazione"))
            {
                SetCheckboxState("AbilitaIbernazione", true);
                try
                {
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power", "HibernateEnabled", 1, RegistryView.Registry32);
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power", "HibernateEnabled", 1, RegistryView.Registry64);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings", "ShowHibernateOption", 1, RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings", "ShowHibernateOption", 1, RegistryView.Registry64);
                    // Abilita ibernazione tramite comando (richiede amministrazione)
                    System.Diagnostics.Process.Start("cmd.exe", "/C powercfg /hibernate on");
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaIbernazione", false);
            }

            // Abilita Ottimizzazione FullScreen
            if (AbilitaUtility.CheckedItems.Contains("Abilita Ottimizzazione FullScreen"))
            {
                SetCheckboxState("AbilitaOttimizzazioneFullScreen", true);
                try
                {
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\GameConfigStore", "GameDVR_DXGIHonorFSEWindowsCompatible", 0, RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\GameConfigStore", "GameDVR_DXGIHonorFSEWindowsCompatible", 0, RegistryView.Registry64);
                    DeleteRegistryKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\GameConfigStore", "GameDVR_FSEBehavior", RegistryView.Registry32);
                    DeleteRegistryKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\GameConfigStore", "GameDVR_FSEBehavior", RegistryView.Registry64);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\GameConfigStore", "GameDVR_FSEBehaviorMode", 0, RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\GameConfigStore", "GameDVR_FSEBehaviorMode", 0, RegistryView.Registry64);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\GameConfigStore", "GameDVR_HonorUserFSEBehaviorMode", 0, RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\GameConfigStore", "GameDVR_HonorUserFSEBehaviorMode", 0, RegistryView.Registry64);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaOttimizzazioneFullScreen", false);
            }

            // Abilita Avvio Rapido
            if (AbilitaUtility.CheckedItems.Contains("Abilita Avvio Rapido"))
            {
                SetCheckboxState("AbilitaAvvioRapido", true);
                try
                {
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power", "HiberbootEnabled", 1, RegistryView.Registry32);
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power", "HiberbootEnabled", 1, RegistryView.Registry64);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaAvvioRapido", false);
            }

            // All Bandwidth
            if (AbilitaUtility.CheckedItems.Contains("All Bandwidth"))
            {
                SetCheckboxState("AllBandwidth", true);
                try
                {
                    SetRegistryValue(@"SOFTWARE\Policies\Microsoft\Psched", "NonBestEffortLimit", 0, RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Policies\Microsoft\Psched", "NonBestEffortLimit", 0, RegistryView.Registry64);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AllBandwidth", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Background App"))
            {
                SetCheckboxState("AbilitaBackgroundApp", true);

                try
                {
                    // Gestione per RegistryView 32 e 64
                    RegistryView view32 = RegistryView.Registry32;
                    RegistryView view64 = RegistryView.Registry64;

                    // Abilita le app in background modificando il registro per entrambe le architetture
                    using (RegistryKey backgroundAppsKey32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, view32).OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", true))
                    using (RegistryKey backgroundAppsKey64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, view64).OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", true))
                    {
                        if (backgroundAppsKey32 != null)
                        {
                            // Aggiungi o modifica il valore GlobalUserDisabled in 32-bit
                            backgroundAppsKey32.SetValue("GlobalUserDisabled", 0, RegistryValueKind.DWord);

                            // Rimuovi le proprietà disabilitate
                            RemoveDisabledProperties(backgroundAppsKey32);
                        }

                        if (backgroundAppsKey64 != null)
                        {
                            // Aggiungi o modifica il valore GlobalUserDisabled in 64-bit
                            backgroundAppsKey64.SetValue("GlobalUserDisabled", 0, RegistryValueKind.DWord);

                            // Rimuovi le proprietà disabilitate
                            RemoveDisabledProperties(backgroundAppsKey64);
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaBackgroundApp", false);
            }

            if (AbilitaUtility.CheckedItems.Contains("Abilita Feedback"))
            {
                SetCheckboxState("AbilitaFeedback", true);

                try
                {
                    // Rimuovi il valore dalla chiave del registro a 32 bit
                    using (RegistryKey rulesKey32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32)
                        .OpenSubKey(@"SOFTWARE\Microsoft\Siuf\Rules", true))
                    {
                        if (rulesKey32 != null && rulesKey32.GetValue("NumberOfSIUFInPeriod") != null)
                        {
                            rulesKey32.DeleteValue("NumberOfSIUFInPeriod", false);
                        }
                    }

                    // Rimuovi il valore dalla chiave del registro a 64 bit
                    using (RegistryKey dataCollectionKey64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                        .OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection", true))
                    {
                        if (dataCollectionKey64 != null && dataCollectionKey64.GetValue("DoNotShowFeedbackNotifications") != null)
                        {
                            dataCollectionKey64.DeleteValue("DoNotShowFeedbackNotifications", false);
                        }
                    }

                    // Abilita i task pianificati
                    EnableScheduledTask("Microsoft\\Windows\\Feedback\\Siuf\\DmClient");
                    EnableScheduledTask("Microsoft\\Windows\\Feedback\\Siuf\\DmClientOnScenarioDownload");
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaFeedback", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Advertising ID"))
            {
                SetCheckboxState("AbilitaAdvertisingID", true);

                try
                {
                    // Rimuovi il valore dalla chiave del registro a 32 bit
                    using (RegistryKey advertisingKey32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                        .OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\AdvertisingInfo", true))
                    {
                        if (advertisingKey32 != null)
                        {
                            // Rimuovi il valore se esiste
                            if (advertisingKey32.GetValue("DisabledByGroupPolicy") != null)
                            {
                                advertisingKey32.DeleteValue("DisabledByGroupPolicy", false);
                            }
                        }
                    }

                    // Rimuovi il valore dalla chiave del registro a 64 bit
                    using (RegistryKey advertisingKey64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                        .OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\AdvertisingInfo", true))
                    {
                        if (advertisingKey64 != null)
                        {
                            // Rimuovi il valore se esiste
                            if (advertisingKey64.GetValue("DisabledByGroupPolicy") != null)
                            {
                                advertisingKey64.DeleteValue("DisabledByGroupPolicy", false);
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaAdvertisingID", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Filtro Smart Screen"))
            {
                SetCheckboxState("AbilitaFiltroSmartScreen", true);
                try
                {
                    // Rimuovere le proprietà dal registro relative al Filtro Smart Screen a 32 bit
                    using (RegistryKey systemKey32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System", true))
                    {
                        systemKey32?.DeleteValue("EnableSmartScreen", false);
                    }

                    using (RegistryKey edgeKey32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter", true))
                    {
                        edgeKey32?.DeleteValue("EnabledV9", false);
                    }

                    // Rimuovere le proprietà dal registro relative al Filtro Smart Screen a 64 bit
                    using (RegistryKey systemKey64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                        .OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System", true))
                    {
                        systemKey64?.DeleteValue("EnableSmartScreen", false);
                    }

                    using (RegistryKey edgeKey64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                        .OpenSubKey(@"SOFTWARE\Policies\Microsoft\MicrosoftEdge\PhishingFilter", true))
                    {
                        edgeKey64?.DeleteValue("EnabledV9", false);
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaFiltroSmartScreen", false);
            }

            if (AbilitaUtility.CheckedItems.Contains("Abilita Wifi Sense"))
            {
                SetCheckboxState("AbilitaWifiSense", true);
                try
                {
                    // Imposta i valori nel registro per abilitare WiFi Sense
                    SetRegistryValue(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi", "AllowWiFiHotSpotReporting", 1, RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi", "AllowWiFiHotSpotReporting", 1, RegistryView.Registry64);

                    SetRegistryValue(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi", "AllowAutoConnectToWiFiSenseHotspots", 1, RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi", "AllowAutoConnectToWiFiSenseHotspots", 1, RegistryView.Registry64);

                    // Rimuovi le proprietà relative al WiFi Sense, se esistono
                    using (RegistryKey configKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true))
                    {
                        if (configKey != null)
                        {
                            configKey.DeleteValue("AutoConnectAllowedOEM", false);
                            configKey.DeleteValue("WiFISenseAllowed", false);
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaWifiSense", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita Desktop Remoto"))
            {
                SetCheckboxState("AbilitaDesktopRemoto", true);
                try
                {
                    // Imposta il valore nel registro per abilitare il Desktop Remoto
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Terminal Server", "fDenyTSConnections", 0, RegistryView.Registry32);
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Terminal Server", "fDenyTSConnections", 0, RegistryView.Registry64);

                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp", "UserAuthentication", 0, RegistryView.Registry32);
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp", "UserAuthentication", 0, RegistryView.Registry64);

                    // Esegui i comandi PowerShell per abilitare il Desktop Remoto
                    string[] commands = new[]
                    {
            "Enable-NetFirewallRule -Name \"RemoteDesktop*\""
        };
                    RunPowerShellCommands(commands);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaDesktopRemoto", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita attivazione del Numlock in avvio"))
            {
                SetCheckboxState("AbilitaattivazionedelNumlockinavvio", true);
                try
                {
                    // Imposta il valore nel registro per attivare il Num Lock all'avvio
                    SetRegistryValue(@"HKEY_USERS\.DEFAULT\Control Panel\Keyboard", "InitialKeyboardIndicators", 2147483650, RegistryView.Registry32);
                    SetRegistryValue(@"HKEY_USERS\.DEFAULT\Control Panel\Keyboard", "InitialKeyboardIndicators", 2147483650, RegistryView.Registry64);

                    // Esegui i comandi PowerShell per attivare il Num Lock se non è già attivato
                    string[] commands = new[]
                    {
            "Add-Type -AssemblyName System.Windows.Forms",
            "If (!([System.Windows.Forms.Control]::IsKeyLocked('NumLock'))) { $wsh = New-Object -ComObject WScript.Shell; $wsh.SendKeys('{NUMLOCK}') }"
        };
                    RunPowerShellCommands(commands);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaattivazionedelNumlockinavvio", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita News e Interessi"))
            {
                SetCheckboxState("AbilitaNewseInteressi", true);
                try
                {
                    // Chiude il processo di Explorer
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "taskkill",
                        Arguments = "/IM explorer.exe /F",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }).WaitForExit();

                    // Imposta il valore di ShellFeedsTaskbarViewMode e IsFeedsAvailable per CurrentUser (registro a 32 e 64 bit)
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Feeds"))
                    {
                        key32?.SetValue("ShellFeedsTaskbarViewMode", 1, RegistryValueKind.DWord);
                        key32?.SetValue("IsFeedsAvailable", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Feeds"))
                    {
                        key64?.SetValue("ShellFeedsTaskbarViewMode", 1, RegistryValueKind.DWord);
                        key64?.SetValue("IsFeedsAvailable", 1, RegistryValueKind.DWord);
                    }

                    // Imposta il valore di EnableFeeds per LocalMachine (registro a 32 e 64 bit)
                    using (RegistryKey keyLM32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Windows Feeds"))
                    {
                        keyLM32?.SetValue("EnableFeeds", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey keyLM64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Windows Feeds"))
                    {
                        keyLM64?.SetValue("EnableFeeds", 1, RegistryValueKind.DWord);
                    }

                    // Riavvia il processo di Explorer
                    RestartExplorer();

                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaNewseInteressi", false);
            }

            if (AbilitaUtility.CheckedItems.Contains("Abilita Risparmio Energetico Personalizzato"))
            {
                SetCheckboxState("AbilitaRisparmioEnergeticoPersonalizzato", true);
                try
                {
                    var startInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        Arguments = "/C powercfg -duplicatescheme a1841308-3541-4fab-bc81-f71556f20b4a && powercfg -duplicatescheme 381b4222-f694-41f0-9685-ff5bb260df2e && powercfg -duplicatescheme 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c && powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runus"
                    };

                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        process.WaitForExit();

                        var output = process.StandardOutput.ReadToEnd();
                        var error = process.StandardError.ReadToEnd();
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaRisparmioEnergeticoPersonalizzato", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Migliora uso SSD"))
            {
                SetCheckboxState("MigliorausoSSD", true);
                try
                {
                    // Imposta il comportamento di fsutil per migliorare l'uso degli SSD
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\FileSystem", "DisableLastAccess", 1, RegistryView.Registry32);
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\FileSystem", "DisableLastAccess", 1, RegistryView.Registry64);

                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\FileSystem", "EncryptPagingFile", 0, RegistryView.Registry32);
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\FileSystem", "EncryptPagingFile", 0, RegistryView.Registry64);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("MigliorausoSSD", false);
            }

            if (AbilitaUtility.CheckedItems.Contains("Abilita Mappe"))
            {
                SetCheckboxState("AbilitaMappe", true);
                try
                {
                    // Utilizza la funzione SetRegistryValue per rimuovere il valore AutoUpdateEnabled
                    SetRegistryValue(@"SYSTEM\Maps", "AutoUpdateEnabled", null, RegistryView.Registry32);
                    SetRegistryValue(@"SYSTEM\Maps", "AutoUpdateEnabled", null, RegistryView.Registry64);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaMappe", false);
            }
            if (AbilitaUtility.CheckedItems.Contains("Abilita UWP apps"))
            {
                SetCheckboxState("AbilitaUWPapps", true);
                try
                {
                    // Imposta i valori nel registro per entrambe le architetture
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "SwapfileControl", null, RegistryView.Registry64);
                    SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "SwapfileControl", null, RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\documentsLibrary", "Value", "Allow", RegistryView.Registry64);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\documentsLibrary", "Value", "Allow", RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\picturesLibrary", "Value", "Allow", RegistryView.Registry64);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\picturesLibrary", "Value", "Allow", RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\videosLibrary", "Value", "Allow", RegistryView.Registry64);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\videosLibrary", "Value", "Allow", RegistryView.Registry32);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\broadFileSystemAccess", "Value", "Allow", RegistryView.Registry64);
                    SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\broadFileSystemAccess", "Value", "Allow", RegistryView.Registry32);

                    // Rimuovere le proprietà da AppPrivacy per entrambe le architetture
                    string appPrivacyPath = @"SOFTWARE\Policies\Microsoft\Windows\AppPrivacy";
                    string[] propertiesToRemove = {
                "LetAppsGetDiagnosticInfo",
                "LetAppsSyncWithDevices",
                "LetAppsAccessRadios",
                "LetAppsAccessMessaging",
                "LetAppsAccessTasks",
                "LetAppsAccessEmail",
                "LetAppsAccessCallHistory",
                "LetAppsAccessPhone",
                "LetAppsAccessCalendar",
                "LetAppsAccessContacts",
                "LetAppsAccessAccountInfo",
                "LetAppsAccessNotifications",
                "LetAppsActivateWithVoice",
                "LetAppsActivateWithVoiceAboveLock",
                "LetAppsRunInBackground"
            };

                    foreach (string property in propertiesToRemove)
                    {
                        SetRegistryValue(appPrivacyPath, property, null, RegistryView.Registry64);
                        SetRegistryValue(appPrivacyPath, property, null, RegistryView.Registry32);
                    }

                    // Rimuovere le proprietà da BackgroundAccessApplications
                    using (RegistryKey backgroundAccessKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", true))
                    {
                        if (backgroundAccessKey != null)
                        {
                            foreach (var subkeyName in backgroundAccessKey.GetSubKeyNames())
                            {
                                using (var subkey = backgroundAccessKey.OpenSubKey(subkeyName, true))
                                {
                                    if (subkey != null)
                                    {
                                        subkey.DeleteValue("Disabled", false);
                                        subkey.DeleteValue("DisabledByUser", false);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaUWPapps", false);
            }

            if (AbilitaUtility.CheckedItems.Contains("Abilita Esperienze Personalizzate Microsoft"))
            {
                SetCheckboxState("AbilitaEsperienzePersonalizzateMicrosoft", true);
                try
                {
                    SetRegistryValue(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent", "DisableTailoredExperiencesWithDiagnosticData", null, RegistryView.Registry64);
                    SetRegistryValue(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent", "DisableTailoredExperiencesWithDiagnosticData", null, RegistryView.Registry32);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                SetCheckboxState("AbilitaEsperienzePersonalizzateMicrosoft", false);
            }
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void RestartExplorer()
        {
            try
            {
                // Chiude tutti i processi explorer.exe in esecuzione
                foreach (var process in Process.GetProcessesByName("explorer"))
                {
                    process.Kill();
                }

                // Aspetta un attimo per garantire che tutti i processi siano effettivamente chiusi
                System.Threading.Thread.Sleep(500);

                // Rilancia explorer.exe usando ShellExecute
                Process.Start(new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    UseShellExecute = true,
                });
            }
            catch (Exception ex)
            {
                // Log dell'errore se necessario
                MessageBox.Show(ex.Message);
            }
        }
        private void DisableScheduledTask(string taskPath)
        {
            try
            {
                var taskService = new Microsoft.Win32.TaskScheduler.TaskService();
                var task = taskService.GetTask(taskPath);
                if (task != null)
                {
                    task.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void SetRegistryValue(string path, string name, object value, RegistryView view = RegistryView.Default)
        {
            RegistryKey baseKey = view == RegistryView.Registry64 ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view) : Registry.LocalMachine;

            using (var key = baseKey.OpenSubKey(path, true))
            {
                key?.SetValue(name, value, RegistryValueKind.DWord);
            }
        }

        private void DeleteRegistryKey(string path, string name, RegistryView view = RegistryView.Default)
        {
            RegistryKey baseKey = view == RegistryView.Registry64 ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view) : Registry.LocalMachine;

            using (var key = baseKey.OpenSubKey(path, true))
            {
                key?.DeleteValue(name, false);
            }
        }

        private void RunPowerShellCommands(string[] commands)
        {
            var commandString = string.Join("; ", commands);
            var startInfo = new System.Diagnostics.ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = commandString,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Verb = "runas"
            };

            using (var process = System.Diagnostics.Process.Start(startInfo))
            {
                process.WaitForExit();

                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }
            }
        }
        private void EnableScheduledTask(string taskName)
        {
            try
            {
                // Imposta il comando per abilitare il task
                var taskCommand = $@"schtasks /Change /TN ""{taskName}"" /ENABLE";
                var startInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = "/c " + taskCommand,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Verb = "runas" // usa "runas" per i privilegi elevati
                };

                using (var process = System.Diagnostics.Process.Start(startInfo))
                {
                    process.WaitForExit();
                }
            }
            catch (Exception)
            {

            }
        }
        private void RemoveDisabledProperties(RegistryKey backgroundAppsKey)
        {
            foreach (string subKeyName in backgroundAppsKey.GetSubKeyNames())
            {
                if (subKeyName.StartsWith("Microsoft.Windows.Cortana"))
                {
                    continue; // Salta Cortana
                }

                using (RegistryKey subKey = backgroundAppsKey.OpenSubKey(subKeyName, true))
                {
                    if (subKey != null)
                    {
                        if (subKey.GetValue("Disabled") != null)
                        {
                            subKey.DeleteValue("Disabled", false);
                        }

                        if (subKey.GetValue("DisabledByUser") != null)
                        {
                            subKey.DeleteValue("DisabledByUser", false);
                        }
                    }
                }
            }
        }
    }
}
