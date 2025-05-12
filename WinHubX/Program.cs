using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WinHubX
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole(); // Per creare una console se necessario

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        [STAThread]
        static void Main(string[] args)
        {
            // Ottieni il percorso attuale dell'eseguibile usando BaseDirectory
            string exePath = AppDomain.CurrentDomain.BaseDirectory;

            // Ottieni il valore attuale della variabile PATH a livello utente
            string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User) ?? "";

            // Separatore di percorsi (Windows usa ";")
            char pathSeparator = Path.PathSeparator;

            // Rimuove vecchi riferimenti a WinHubX dalla variabile PATH
            var paths = currentPath.Split(pathSeparator)
                                   .Where(p => !p.Contains("WinHubX", StringComparison.OrdinalIgnoreCase))
                                   .ToList();

            // Aggiungi il nuovo percorso dell'eseguibile
            paths.Add(exePath);

            // Creazione della nuova stringa PATH
            string newPath = string.Join(pathSeparator.ToString(), paths);

            // Aggiorna la variabile d'ambiente PATH a livello utente
            Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.User);

            // Controlla e mostra la variabile PATH aggiornata
            string updatedPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);


            // Controlla se sono stati passati argomenti
            if (args.Length > 0)
            {
                // Modalit� console: crea una console e processa i comandi
                AllocConsole();
                ProcessCommandLineArgs(args);
                Console.WriteLine("Premi un tasto per uscire...");
                Console.ReadKey();
                FreeConsole();
            }
            else
            {
                // Modalit� GUI: avvia l'app WinForms normalmente
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }

        static void ProcessCommandLineArgs(string[] args)
        {
            // Verifica che gli argomenti siano ricevuti
            string receivedArgs = string.Join(", ", args);

            // Controlla il primo argomento passato
            string command = args[0].ToLower();

            switch (command)
            {
                case "/help":
                    ShowHelp();
                    break;
                case "/statoattivazione":
                    ShowActivationStatus();
                    break;
                case "/aggiornamentolite":
                    if (args.Length > 1)
                    {
                        // Verifica se � stato passato un percorso file
                        string isoPath = args[1];
                        AggiornaLite(isoPath);
                    }
                    else
                    {
                        // Mostra il messaggio per aggiungere il percorso ISO
                        Console.WriteLine("Errore: devi specificare un percorso per il file ISO.\nEsempio:\n" +
                                          "winhubx /aggiornamentolite \"C:\\Users\\Download\\isolite.iso\"");
                    }
                    break;
                case "/bios":
                    VaiNelBios();
                    break;
                case "/verificaram":
                    VerificaRam();
                    break;
                case "/cronologiadefender":
                    DefenderHistory();
                    break;
                case "/batteria":
                    ReportBatteria();
                    break;
                case "/temp":
                    PuliziaCartellaTemp();
                    break;
                case "/deallocati":
                    FileDeallocati();
                    break;
                case "/driver":
                    SalvaDriver();
                    break;
                case "/puliziaupdate":
                    PulisciUpdate();
                    break;
                case "/iso":
                    if (args.Length > 1)
                    {
                        string isoType = args[1].ToLower();
                        ShowIsoOptions(isoType);
                    }
                    else
                    {
                        Console.WriteLine("Quale ISO vuoi creare? Usa i seguenti parametri:\n" +
                                        "/iso -server\n" +
                                        "/iso -10ltsc\n" +
                                        "/iso -11ltsc", "Opzioni ISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                default:
                    Console.WriteLine("Comando non riconosciuto. Usa '/help' per visualizzare i comandi disponibili.", "Errore Comando", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        static void ShowHelp()
        {
            // Mostra i comandi disponibili in un MessageBox
            string helpMessage = "Comandi disponibili:\n" +
                                 "/help            - Mostra questo messaggio di aiuto.\n" +
                                 "/statoattivazione - Mostra lo stato di attivazione.\n" +
                                 "/bios - Vai nel bios.\n" +
                                 "/verificaram - Verifica stato ram\n" +
                                 "/cronologiadefender - Cancella cronologia minaccie defender\n" +
                                 "/puliziaupdate - Cancella file tempornaei update\n" +
                                 "/batteria - Report batteria (pc portatili)\n" +
                                 "/temp - Cancella cartelle tempornae\n" +
                                 "/deallocati - Elimina file deallocati\n" +
                                 "/driver - Salva i driver del pc\n" +
                                 "/aggiornamentolite - Upgrade in-place lite.\n" +
                                 "/iso <opzione>   - Scarica la ISO con l'opzione specificata.\n" +
                                 "    Opzioni per /iso:\n" +
                                 "    -10ltsc         - Scarica la ISO LTSC.\n" +
                                 "    -11ltsc         - Scarica la ISO LTSC.\n" +
                                 "    -server         - Scarica la LTSC.\n";
            Console.WriteLine(helpMessage, "Aiuto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void PulisciUpdate()
        {
            Console.WriteLine("Arresto del servizio Windows Update...");
            ExecutePowerShellCommand("Stop-Service", "wuauserv -Force");

            Thread.Sleep(10000);

            Console.WriteLine("Eliminazione della cartella SoftwareDistribution...");
            ExecutePowerShellCommand("Remove-Item", "C:\\Windows\\SoftwareDistribution\\Download -Recurse -Force");

            Console.WriteLine("Riavvio del servizio Windows Update...");
            ExecutePowerShellCommand("Start-Service", "wuauserv");

            Console.WriteLine("Operazione completata.");
        }

        private static void ExecutePowerShellCommand(string command, string arguments)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-Command \"{command} {arguments}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Verb = "runas"  // Esegui come amministratore
                };

                process.StartInfo = startInfo;
                process.Start();

                // Legge l'output della console di PowerShell
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine("Output PowerShell: " + output);
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Errore PowerShell: " + error);
                }
            }
        }
        static void SalvaDriver()
        {
            try
            {
                string driverDirectory = @"C:\DriverPC";
                if (!Directory.Exists(driverDirectory))
                {
                    Directory.CreateDirectory(driverDirectory);
                    Console.WriteLine($"Cartella creata: {driverDirectory}");
                }
                var dismProcess = Process.Start(new ProcessStartInfo
                {
                    FileName = "dism.exe",
                    Arguments = $"/online /export-driver /destination:{driverDirectory}",
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    Verb = "runus",
                    CreateNoWindow = false
                });
                string outputPath = Path.Combine(driverDirectory, "driver.txt");
                using (var commandProcess = new Process())
                {
                    commandProcess.StartInfo.FileName = "cmd.exe";
                    commandProcess.StartInfo.Arguments = $"/c driverquery > \"{outputPath}\"";
                    commandProcess.StartInfo.UseShellExecute = false;
                    commandProcess.StartInfo.CreateNoWindow = true;
                    commandProcess.Start();
                    commandProcess.WaitForExit();
                }
            }
            finally
            {
                Console.WriteLine("Trovi la cartella in C:\\DriverPC");
                Console.WriteLine("Per ripristinare tutti i driver, salvati la cartella su USB e, con ISO installata, usa \"pnputil /add-driver 'percorsodriver\\*.inf' /subdirs /install /reboot\".");
            }
        }
        static void FileDeallocati()
        {
            string fileName = "cipher.exe";
            string arguments = "/w:c";
            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.Verb = "runus";
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardError = false;
            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
            }
        }
        static void PuliziaCartellaTemp()
        {
            try
            {
                string tempPath = Environment.GetEnvironmentVariable("TEMP");
                string systemTempPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\Temp";

                // Usa robocopy per svuotare le cartelle ignorando i file in uso
                Process.Start("cmd.exe", "/c robocopy \"" + tempPath + "\" NUL /mir /njh /njs /np /r:1 /w:1 && rmdir /s /q \"" + tempPath + "\"");
                Process.Start("cmd.exe", "/c robocopy \"" + systemTempPath + "\" NUL /mir /njh /njs /np /r:1 /w:1 && rmdir /s /q \"" + systemTempPath + "\"");

                Console.WriteLine("Temp folders cleared successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing temp folders: {ex.Message}");
            }
        }

        static void ReportBatteria()
        {
            GenerateBatteryReport(@"C:\battery_report.html");
        }

        private static void GenerateBatteryReport(string filePath)
        {
            string command = $"powercfg /batteryreport /output \"{filePath}\"";

            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Verb = "runas"  // Per eseguire come amministratore
            };

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                    process.StandardInput.WriteLine(command);
                    process.StandardInput.WriteLine("exit"); // Esce da cmd
                    process.StandardInput.Flush();
                    process.StandardInput.Close();
                    process.WaitForExit();
                }

                if (File.Exists(filePath))
                {
                    Console.WriteLine($"Trovi il report della batteria in {filePath}.");
                }
                else
                {
                    Console.WriteLine("Impossibile generare il report della batteria.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
        }

        static void DefenderHistory()
        {
            bool clearAV = true;
            bool clearCFA = true;
            bool removeTask = true;

            string scans = "C:\\ProgramData\\Microsoft\\Windows Defender\\Scans";
            string service = Path.Combine(scans, "History", "Service");
            string db = Path.Combine(scans, "mpenginedb.db*");
            string taskName = "DWDH";

            string command = "cmd.exe /c ";
            if (clearAV)
                command += $"rd /s /q \"{service}\" & ";
            if (clearCFA)
                command += $"del /f \"{db}\" & ";
            if (removeTask)
                command += $"schtasks /delete /f /tn {taskName}";

            Process.Start(new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-Command \"{command}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            });

            Console.Write("A restart is required to clear the Protection history. Enter y to restart now: ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "shutdown",
                    Arguments = "/r /t 0",
                    UseShellExecute = false,
                    CreateNoWindow = true
                });
            }
        }

        static void VerificaRam()
        {
            try
            {
                string fileName = @"C:\Windows\System32\mdsched.exe";

                if (!System.IO.File.Exists(fileName))
                {
                    Console.WriteLine("Il file mdsched.exe non esiste nel percorso specificato.");
                    return;
                }

                ProcessStartInfo psi = new ProcessStartInfo(fileName)
                {
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    Verb = "runas"
                };

                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
        }

        static void VaiNelBios()
        {
            string fileName = "shutdown.exe";
            string arguments = "/t 0 /r /fw";
            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.Verb = "runus";
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardError = false;
            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
            }
        }
        static void AggiornaLite(string isoPath = null)
        {
            string upgradeFolder = @"C:\StartOnUpgrade";
            string startBatPath = Path.Combine(upgradeFolder, "Start.bat");
            string extractPath = Path.Combine(Path.GetTempPath(), "WinUpgrade");

            try
            {
                // 1. Creare la cartella C:\StartOnUpgrade se non esiste
                if (!Directory.Exists(upgradeFolder))
                {
                    Directory.CreateDirectory(upgradeFolder);
                }

                // 2. Creare il file Start.bat con il contenuto desiderato
                if (!File.Exists(startBatPath))
                {
                    string startBatContent = @"@echo off" + Environment.NewLine +
                                             "setlocal EnableDelayedExpansion" + Environment.NewLine +
                                             "" + Environment.NewLine +
                                             "rem Ask for admin privileges" + Environment.NewLine +
                                             "set \"params=%*\"" + Environment.NewLine +
                                             "cd /d \"%~dp0\" && ( if exist \"%temp%\\getadmin.vbs\" del \"%temp%\\getadmin.vbs\" ) && fsutil dirty query %systemdrive%  1>nul 2>nul || ( echo Set UAC = CreateObject^(\"Shell.Application\"^) : UAC.ShellExecute \"cmd.exe\", \"/c cd \"\"%~sdp0\"\" && %~s0 %params%\", \"\", \"runas\", 1 >> \"%temp%\\getadmin.vbs\" && \"%temp%\\getadmin.vbs\" && exit /B )" + Environment.NewLine +
                                             "" + Environment.NewLine +
                                             "if exist C:\\Windows\\start.ps1 (" + Environment.NewLine +
                                             "    powershell -ExecutionPolicy Bypass -File C:\\Windows\\start.ps1" + Environment.NewLine +
                                             ")" + Environment.NewLine +
                                             "if exist C:\\Windows\\start10.ps1 (" + Environment.NewLine +
                                             "    powershell -ExecutionPolicy Bypass -File C:\\Windows\\start10.ps1" + Environment.NewLine +
                                             ")" + Environment.NewLine;

                    File.WriteAllText(startBatPath, startBatContent);
                }

                // 3. Aggiungere il comando RunOnce per avviare start.bat dopo l'aggiornamento
                string regCmd = @"reg add HKLM\Software\Microsoft\Windows\CurrentVersion\RunOnce /v StartPostUpgrade /t REG_SZ /d ""cmd /c C:\StartOnUpgrade\start.bat"" /f";
                RunCommand("cmd.exe", $"/c {regCmd}");

                // Creare cartella per estrazione
                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }

                // Controlla quale software di estrazione � disponibile
                string extractorPath = null;
                string extractorArgs = null;

                string sevenZipPath = @"C:\Program Files\7-Zip\7z.exe";
                string winRarPath = @"C:\Program Files\WinRAR\WinRAR.exe";

                if (File.Exists(sevenZipPath))
                {
                    extractorPath = sevenZipPath;
                    extractorArgs = $"x \"{isoPath}\" -o\"{extractPath}\" sources\\* -y";
                }
                else if (File.Exists(winRarPath))
                {
                    extractorPath = winRarPath;
                    extractorArgs = $"x \"{isoPath}\" \"{extractPath}\\sources\" sources\\*";
                }
                else
                {
                    Console.WriteLine("N� 7-Zip n� WinRAR sono installati! Installane uno per procedere.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Estrarre la cartella "sources"
                RunCommand(extractorPath, extractorArgs);

                // Rinominare appraiserres.dll.bak in appraiserres.dll
                string sourcesPath = Path.Combine(extractPath, "sources");
                string appraiserBak = Path.Combine(sourcesPath, "appraiserres.dll.bak");
                string appraiserDll = Path.Combine(sourcesPath, "appraiserres.dll");

                if (File.Exists(appraiserBak))
                {
                    if (File.Exists(appraiserDll))
                    {
                        File.Delete(appraiserDll);
                    }
                    File.Move(appraiserBak, appraiserDll);
                }

                // Avviare il setup di Windows
                string setupPath = Path.Combine(sourcesPath, "setupprep.exe");

                if (File.Exists(setupPath))
                {
                    Process.Start(setupPath, "/product server");
                }
                else
                {
                    Console.WriteLine("File setupprep.exe non trovato!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static string RunCommand(string fileName, string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    return reader.ReadToEnd();
                }
            }
        }

        static void ShowActivationStatus()
        {
            string fileName = "WinHubXStatoAttivazione.cmd";
            string resourceName = "WinHubX.Resources.WinHubXStatoAttivazione.cmd"; string tempPath = Path.GetTempPath();
            string tempFilePath = Path.Combine(tempPath, fileName);
            try
            {
                using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (resourceStream != null)
                    {
                        using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                    }
                }
                Process.Start(tempFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nell'avviare l'applicazione: {ex.Message}");
            }
        }

        static void ShowIsoOptions(string isoType)
        {
            // Gestisci la creazione della ISO in base all'argomento
            switch (isoType)
            {
                case "-10ltsc":
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "https://devuploads.com/6spxhaj8unvw",
                        UseShellExecute = true
                    });
                    break;
                case "-11ltsc":
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "https://devuploads.com/3ri4e4ihu91m",
                        UseShellExecute = true
                    });
                    break;
                case "-server":
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "https://devuploads.com/n5oteoer128s",
                        UseShellExecute = true
                    });
                    break;
                default:
                    Console.WriteLine("Opzione ISO non riconosciuta. Usa '/iso' per vedere le opzioni disponibili.", "Errore Opzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
