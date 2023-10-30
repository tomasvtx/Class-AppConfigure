using System;
using System.Diagnostics;
using System.Linq;

namespace AppConfigure
{
    /// <summary>
    /// Utility pro získávání systémových informací a řízení procesů.
    /// </summary>
    public class SystemInfoUtility
    {
        private string AppName { get; }

        /// <summary>
        /// Inicializuje novou instanci třídy SystemInfoUtility s názvem aplikace.
        /// </summary>
        /// <param name="appName">Název aplikace pro kontrolu běžících procesů.</param>
        public SystemInfoUtility(string appName)
        {
            AppName = appName;
        }

        /// <summary>
        /// Zkontroluje, zda běží instance programu s daným názvem.
        /// </summary>
        /// <returns>Stav běhu programu.</returns>
        public AppRunning ZkontrolujBěžícíProgram() => (Process.GetProcesses().Count(rr => rr.ProcessName.Contains(AppName)) > 1) ? AppRunning.Běžící : AppRunning.NeBěžící;

        /// <summary>
        /// Získá informace o operačním systému.
        /// </summary>
        /// <returns>Informace o operačním systému.</returns>
        public string GetOSInfo()
        {
            try
            {
                // Získáme informace o operačním systému.
                OperatingSystem os = Environment.OSVersion;
                string servicePack = Environment.OSVersion.ServicePack;

                // Získáme informace o verzi operačního systému.
                Version verzeOS = os.Version;

                // Proměnná pro návratovou hodnotu.
                string operačníSystém = "";

                if (os.Platform == PlatformID.Win32NT)
                {
                    switch (verzeOS.Major)
                    {
                        case 5:
                            if (verzeOS.Minor == 0)
                            {
                                operačníSystém = "Windows 2000";
                            }
                            else
                            {
                                operačníSystém = $"Windows XP {servicePack}";
                            }
                            break;

                        case 6:
                            if (verzeOS.Minor == 0)
                            {
                                operačníSystém = $"Vista {servicePack}";
                            }
                            else if (verzeOS.Minor == 1)
                            {
                                operačníSystém = "Windows 7";
                            }
                            else if (verzeOS.Minor == 2)
                            {
                                operačníSystém = "Windows 8";
                            }
                            else
                            {
                                operačníSystém = "Windows 8.1";
                            }
                            break;
                        case 10:
                            operačníSystém = "Windows 10";
                            break;
                        default:
                            break;
                    }
                }
                return operačníSystém;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Uzavře procesy aplikace se stejným názvem jako hlavní aplikace, ale nepatřící k ní.
        /// </summary>
        public void UzavřiOstatníInstance()
        {
            foreach (var proces in Process.GetProcesses().Where(rr => rr.ProcessName.Contains(AppName) && !rr.MainWindowTitle.Contains("[")))
            {
                proces.Kill();
            }
        }
    }

    /// <summary>
    /// Výčet stavů provozu aplikace.
    /// </summary>
    public enum AppRunning
    {
        /// <summary>
        /// Aplikace je ve výpisu spuštěných procesů.
        /// </summary>
        Běžící,

        /// <summary>
        /// Aplikace není ve výpisu spuštěných procesů.
        /// </summary>
        NeBěžící
    }
}
