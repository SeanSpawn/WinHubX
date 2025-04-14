using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System.ComponentModel;
using System.ServiceProcess;
using System.Windows.Forms;
using WinHubX.Forms.Base;

namespace WinHubX.Forms.Settaggi
{
    public partial class FormPrivacy : Form
    {
        private Form1 form1;
        private FormSettaggi formSettaggi;
        private int tIndex = -1;
        private int totalSteps = 0;
        public FormPrivacy(FormSettaggi formSettaggi, Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formSettaggi = formSettaggi;
            LoadCheckboxStates();
            DisabilitaPrivacy.MouseMove += new MouseEventHandler(checkedListBox1_MouseMove);
            AbilitaPrivacy.MouseMove += new MouseEventHandler(checkedListBox2_MouseMove);

        }

        private void checkedListBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int index = DisabilitaPrivacy.IndexFromPoint(e.Location);
            if (tIndex != index)
            {
                tIndex = index;
                if (tIndex > -1)
                {
                    // Aggiungi i tuoi tooltips specifici per ciascun elemento
                    string tooltipText = GetTooltipTextDisa(tIndex);
                    toolTip1.SetToolTip(DisabilitaPrivacy, tooltipText);
                }
            }
        }

        private void checkedListBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int index = AbilitaPrivacy.IndexFromPoint(e.Location);
            if (tIndex != index)
            {
                tIndex = index;
                if (tIndex > -1)
                {
                    // Aggiungi i tuoi tooltips specifici per ciascun elemento
                    string tooltipText = GetTooltipTextAbil(tIndex);
                    toolTip1.SetToolTip(AbilitaPrivacy, tooltipText);
                }
            }
        }

        private string GetTooltipTextDisa(int index)
        {
            switch (index)
            {
                case 0:
                    return "Disabilita le opzioni relative alla lingua nel sistema, impedendo modifiche alla lingua di sistema e alle impostazioni di localizzazione.";
                case 1:
                    return "Disabilita i suggerimenti e le raccomandazioni dell'app, evitando notifiche e consigli da parte delle applicazioni.";
                case 2:
                    return "Disabilita la raccolta e l'invio dei dati di telemetria al fine di migliorare il sistema operativo, proteggendo la privacy dell'utente.";
                case 3:
                    return "Disabilita il tracciamento delle attività dell'utente da parte del sistema, evitando la registrazione delle azioni e comportamenti.";
                case 4:
                    return "Disabilita la segnalazione automatica degli errori e dei bug al sistema, impedendo l'invio di report ai server di Microsoft.";
                case 5:
                    return "Disabilita il tracciamento diagnostico delle prestazioni e degli errori nel sistema operativo, evitando l'invio di report diagnostici.";
                case 6:
                    return "Disabilita il servizio di messaggistica WAP Push, impedendo l'invio e la ricezione di notifiche push tramite il servizio.";
                case 7:
                    return "Disabilita la funzionalità di HomeGroup, evitando la creazione e gestione di gruppi domestici per la condivisione di file e dispositivi in rete locale.";
                case 8:
                    return "Disabilita l'assistenza remota, impedendo ad altri utenti di connettersi al computer per supporto tecnico tramite desktop remoto.";
                case 9:
                    return "Disabilita la pianificazione e l'esecuzione automatica di defrag dei dischi rigidi, impedendo la deframmentazione automatica dei file.";
                case 10:
                    return "Disabilita le funzionalità di Xbox, come la sincronizzazione dei dati e le app correlate all'account Xbox sul computer.";
                case 11:
                    return "Disabilita la manutenzione automatica, impedendo al sistema di eseguire automaticamente attività di manutenzione come la pulizia del disco e la verifica della sicurezza.";
                case 12:
                    return "Disabilita la gestione dello spazio riservato sul sistema, impedendo al sistema operativo di allocare automaticamente spazio per file temporanei e aggiornamenti.";
                case 13:
                    return "Disabilita i miglioramenti delle performance di gioco tramite Game DVR, evitando la registrazione automatica dei giochi e altre ottimizzazioni legate al gaming.";
                case 14:
                    return "Disabilita la cronologia delle attività, impedendo la registrazione e la visualizzazione delle azioni precedenti, come gli appunti e le attività aperte.";
                case 15:
                    return "Disabilita WiFi Sense, impedendo la connessione automatica a reti Wi-Fi pubbliche e la condivisione delle reti con i contatti Microsoft.";
                case 16:
                    return "Disabilita la barra delle notifiche e il calendario, impedendo la visualizzazione delle notifiche di sistema e delle informazioni sul calendario.";
                default:
                    return string.Empty;
            }
        }
        private string GetTooltipTextAbil(int index)
        {
            switch (index)
            {
                case 0:
                    return "Abilita le opzioni linguistiche e regionali nel sistema, consentendo modifiche alla lingua di sistema e alle impostazioni di localizzazione.";
                case 1:
                    return "Abilita i suggerimenti e le raccomandazioni dell'app, mostrando notifiche e consigli da parte delle applicazioni.";
                case 2:
                    return "Abilita la raccolta e l'invio dei dati di telemetria, contribuendo al miglioramento del sistema operativo e dei prodotti Microsoft.";
                case 3:
                    return "Abilita il tracciamento delle attività dell'utente, registrando le azioni e i comportamenti all'interno del sistema.";
                case 4:
                    return "Abilita la segnalazione automatica degli errori e dei bug al sistema, inviando report ai server di Microsoft per miglioramenti.";
                case 5:
                    return "Abilita il tracciamento diagnostico delle prestazioni e degli errori nel sistema operativo, consentendo la raccolta dei dati diagnostici.";
                case 6:
                    return "Abilita il servizio di messaggistica WAP Push, consentendo l'invio e la ricezione di notifiche push tramite il servizio.";
                case 7:
                    return "Abilita la funzionalità di HomeGroup, permettendo la creazione e la gestione di gruppi domestici per la condivisione di file e dispositivi in rete locale.";
                case 8:
                    return "Abilita l'assistenza remota, permettendo ad altri utenti di connettersi al computer per supporto tecnico tramite desktop remoto.";
                case 9:
                    return "Abilita la pianificazione e l'esecuzione automatica di defrag dei dischi rigidi, consentendo la deframmentazione automatica dei file.";
                case 10:
                    return "Abilita le funzionalità di Xbox, come la sincronizzazione dei dati e le app correlate all'account Xbox sul computer.";
                case 11:
                    return "Abilita la manutenzione automatica, consentendo al sistema di eseguire automaticamente attività di manutenzione come la pulizia del disco e la verifica della sicurezza.";
                case 12:
                    return "Abilita la gestione dello spazio riservato sul sistema, consentendo al sistema operativo di allocare automaticamente spazio per file temporanei e aggiornamenti.";
                case 13:
                    return "Abilita i miglioramenti delle performance di gioco tramite Game DVR, consentendo la registrazione automatica dei giochi e altre ottimizzazioni legate al gaming.";
                case 14:
                    return "Abilita la cronologia delle attività, consentendo la registrazione e la visualizzazione delle azioni precedenti, come gli appunti e le attività aperte.";
                case 15:
                    return "Abilita WiFi Sense, consentendo la connessione automatica a reti Wi-Fi pubbliche e la condivisione delle reti con i contatti Microsoft.";
                case 16:
                    return "Abilita la barra delle notifiche e il calendario, mostronado le notifiche di sistema e le informazioni sul calendario.";
                default:
                    return string.Empty;
            }
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
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Auto Manteinance");
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
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Wifi-Sense");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaWifiSense"));
            }
            index = DisabilitaPrivacy.Items.IndexOf("Disabilita Notifiche Tray/Calendario");
            if (index != -1)
            {
                DisabilitaPrivacy.SetItemChecked(index, GetCheckboxState("DisabilitaNotificheTrayCalendario"));
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
            index = AbilitaPrivacy.Items.IndexOf("Abilita Wifi-Sense");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaWifiSense"));
            }
            index = AbilitaPrivacy.Items.IndexOf("Abilita Notifiche Tray/Calendario");
            if (index != -1)
            {
                AbilitaPrivacy.SetItemChecked(index, GetCheckboxState("AbilitaNotificheTrayCalendario"));
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

                            }

                            if (!string.IsNullOrEmpty(error))
                            {

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
            // Conta i passi basati sugli oggetti checked
            totalSteps = 0;
            foreach (var item in DisabilitaPrivacy.CheckedItems)
            {
                totalSteps++;
            }
            foreach (var item in AbilitaPrivacy.CheckedItems)
            {
                totalSteps++;
            }

            if (totalSteps == 0)
            {
                totalSteps = 1;  // Imposta almeno 1 passo
            }

            progressBar1.Maximum = totalSteps;
            progressBar1.Value = 0;

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private async void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Modifiche apportate con successo", "WinHubX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Non usare direttamente e.ProgressPercentage se può essere > Maximum
            progressBar1.Value = Math.Min(e.ProgressPercentage, progressBar1.Maximum);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int currentStep = 0;
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Opzioni Lingua"))
            {
                SetCheckboxState("DisabilitaOpzioniLingua", true);
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"))
                    {
                        key.SetValue("ContentDeliveryAllowed", 0, RegistryValueKind.DWord);
                        key.SetValue("OemPreInstalledAppsEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("PreInstalledAppsEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("PreInstalledAppsEverEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SilentInstalledAppsEnabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338387Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338388Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-338389Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SubscribedContent-353698Enabled", 0, RegistryValueKind.DWord);
                        key.SetValue("SystemPaneSuggestionsEnabled", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Siuf\Rules"))
                    {
                        key.SetValue("NumberOfSIUFInPeriod", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection"))
                    {
                        key.SetValue("DoNotShowFeedbackNotifications", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CloudContent"))
                    {
                        key.SetValue("DisableTailoredExperiencesWithDiagnosticData", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\AdvertisingInfo"))
                    {
                        key.SetValue("DisabledByGroupPolicy", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\Windows Error Reporting"))
                    {
                        key.SetValue("Disabled", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Config"))
                    {
                        key.SetValue("DODownloadMode", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Remote Assistance"))
                    {
                        key.SetValue("fAllowToGetHelp", 0, RegistryValueKind.DWord);
                    }
                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Windows Feeds"))
                    {
                        key.SetValue("EnableFeeds", 0, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Feeds"))
                    {
                        key.SetValue("ShellFeedsTaskbarViewMode", 2, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"))
                    {
                        key.SetValue("HideSCAMeetNow", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\UserProfileEngagement"))
                    {
                        key.SetValue("ScoobeSystemSettingEnabled", 0, RegistryValueKind.DWord);
                    }

                    // Disabilita i task pianificati relativi alla telemetria
                    ExecutePowerShellScript(@"
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\ProgramDataUpdater"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Autochk\Proxy"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Customer Experience Improvement Program\Consolidator"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\Customer Experience Improvement Program\UsbCeip"";
            Disable-ScheduledTask -TaskName ""Microsoft\Windows\DiskDiagnostic\Microsoft-Windows-DiskDiagnosticDataCollector"";
    Disable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClient"";
    Disable-ScheduledTask -TaskName ""Microsoft\Windows\Feedback\Siuf\DmClientOnScenarioDownload"";
    Disable-ScheduledTask -TaskName ""Microsoft\Windows\Windows Error Reporting\QueueReporting"";
    Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\MareBackup"";
    Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\StartupAppTask"";
    Disable-ScheduledTask -TaskName ""Microsoft\Windows\Application Experience\PcaPatchDbTask"";
    Disable-ScheduledTask -TaskName ""Microsoft\Windows\Maps\MapsUpdateTask"";
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Wifi-Sense"))
            {
                SetCheckboxState("DisabilitaWifiSense", true);
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
                try
                {
                    // Imposta le chiavi di registro per la configurazione a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .CreateSubKey(@"Software\Microsoft\PolicyManager\default\WiFi"))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("AllowWiFiHotSpotReporting", 0, RegistryValueKind.DWord);
                            key64.SetValue("AllowAutoConnectToWiFiSenseHotspots", 0, RegistryValueKind.DWord);
                        }
                    }

                    // Imposta le chiavi di registro per WiFi HotSpot Reporting e AutoConnect nella configurazione a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .CreateSubKey(@"Software\Microsoft\PolicyManager\default\WiFi"))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("AllowWiFiHotSpotReporting", 0, RegistryValueKind.DWord);
                            key32.SetValue("AllowAutoConnectToWiFiSenseHotspots", 0, RegistryValueKind.DWord);
                        }
                    }
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
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaWifiSense", false);
            }
            if (DisabilitaPrivacy.CheckedItems.Contains("Disabilita Notifiche Tray/Calendario"))
            {
                SetCheckboxState("DisabilitaNotificheTrayCalendario", true);
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
                try
                {
                    // Imposta le chiavi di registro per la configurazione a 64-bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
                                                             .CreateSubKey(@"Software\Policies\Microsoft\Windows\Explorer"))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("DisableNotificationCenter", 1, RegistryValueKind.DWord);
                        }
                    }

                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
                                                             .CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\PushNotifications"))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("ToastEnabled", 0, RegistryValueKind.DWord);
                        }
                    }

                    // Imposta le chiavi di registro per disabilitare il Notification Center e le Toast Notifications nella configurazione a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32)
                                                             .CreateSubKey(@"Software\Policies\Microsoft\Windows\Explorer"))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("DisableNotificationCenter", 1, RegistryValueKind.DWord);
                        }
                    }

                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32)
                                                             .CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\PushNotifications"))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("ToastEnabled", 0, RegistryValueKind.DWord);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                SetCheckboxState("DisabilitaNotificheTrayCalendario", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Opzioni Lingua"))
            {
                SetCheckboxState("AbilitaOpzioniLingua", true);
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
                SetCheckboxState("AbilitaSpazioRiservato", true);
                ExecutePowerShellScript(@"Set-WindowsReservedStorageState -State Enabled");
            }
            else
            {
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
                SetCheckboxState("AbilitaSpazioRiservato", false);
            }
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Tweaks Game DVR"))
            {
                SetCheckboxState("AbilitaTweaksGameDVR", true);
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
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
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Wifi-Sense"))
            {
                SetCheckboxState("AbilitaWifiSense", true);
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
                try
                {
                    // Imposta le chiavi di registro nel registro 64 bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                                             .CreateSubKey(@"Software\Microsoft\PolicyManager\default\WiFi"))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("AllowWiFiHotSpotReporting", 1, RegistryValueKind.DWord);
                            key64.SetValue("AllowAutoConnectToWiFiSenseHotspots", 1, RegistryValueKind.DWord);
                        }
                    }

                    // Imposta le chiavi di registro per WiFi HotSpot Reporting e AutoConnect nella configurazione a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                                             .CreateSubKey(@"Software\Microsoft\PolicyManager\default\WiFi"))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("AllowWiFiHotSpotReporting", 1, RegistryValueKind.DWord);
                            key32.SetValue("AllowAutoConnectToWiFiSenseHotspots", 1, RegistryValueKind.DWord);
                        }
                    }
                    using (RegistryKey key32WiFiHotSpot = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowWiFiHotSpotReporting", true))
                    {
                        key32WiFiHotSpot?.SetValue("Value", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64WiFiHotSpot = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowWiFiHotSpotReporting", true))
                    {
                        key64WiFiHotSpot?.SetValue("Value", 1, RegistryValueKind.DWord);
                    }

                    // HKLM\SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots -> Value
                    using (RegistryKey key32AutoConnect = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots", true))
                    {
                        key32AutoConnect?.SetValue("Value", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64AutoConnect = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\PolicyManager\default\WiFi\AllowAutoConnectToWiFiSenseHotspots", true))
                    {
                        key64AutoConnect?.SetValue("Value", 1, RegistryValueKind.DWord);
                    }

                    // HKLM\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config -> AutoConnectAllowedOEM
                    using (RegistryKey key32OEM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true))
                    {
                        key32OEM?.SetValue("AutoConnectAllowedOEM", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64OEM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true))
                    {
                        key64OEM?.SetValue("AutoConnectAllowedOEM", 1, RegistryValueKind.DWord);
                    }

                    // HKLM\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config -> WiFISenseAllowed
                    using (RegistryKey key32SenseAllowed = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true))
                    {
                        key32SenseAllowed?.SetValue("WiFISenseAllowed", 1, RegistryValueKind.DWord);
                    }

                    using (RegistryKey key64SenseAllowed = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config", true))
                    {
                        key64SenseAllowed?.SetValue("WiFISenseAllowed", 1, RegistryValueKind.DWord);
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
            if (AbilitaPrivacy.CheckedItems.Contains("Abilita Notifiche Tray/Calendario"))
            {
                SetCheckboxState("AbilitaNotificheTrayCalendario", true);
                currentStep++;
                backgroundWorker1.ReportProgress(currentStep);
                try
                {
                    // Imposta le chiavi di registro nel registro 64 bit
                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
                                                             .CreateSubKey(@"Software\Policies\Microsoft\Windows\Explorer"))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("DisableNotificationCenter", 0, RegistryValueKind.DWord);
                        }
                    }

                    using (RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
                                                             .CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\PushNotifications"))
                    {
                        if (key64 != null)
                        {
                            key64.SetValue("ToastEnabled", 1, RegistryValueKind.DWord);
                        }
                    }

                    // Imposta le chiavi di registro per disabilitare il Notification Center e le Toast Notifications nella configurazione a 32-bit
                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32)
                                                             .CreateSubKey(@"Software\Policies\Microsoft\Windows\Explorer"))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("DisableNotificationCenter", 0, RegistryValueKind.DWord);
                        }
                    }

                    using (RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32)
                                                             .CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\PushNotifications"))
                    {
                        if (key32 != null)
                        {
                            key32.SetValue("ToastEnabled", 1, RegistryValueKind.DWord);
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
                SetCheckboxState("AbilitaNotificheTrayCalendario", false);
            }
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
