using AppConfigure.Model.Args;
using AppConfigure.Model.Xml;
using AppConfigure.Model.Xml.BaseModel;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace AppConfigure.Utils
{
    public static class ArgsCooperation
    {
        /// <summary>
        /// Pokusí se přečíst konfigurační XML soubor a deserializovat jej na instanci třídy 'DaikinAppConfigure'.
        /// </summary>
        /// <param name="daikinAppConfigure">Výstupní instance 'DaikinAppConfigure', kam bude uložena načtená konfigurace, pokud operace proběhne úspěšně.</param>
        /// <param name="error">Textový popis chyby v případě neúspěchu operace.</param>
        /// <param name="filePath">Cesta k XML souboru s konfigurací. Výchozí hodnota je "CONFIG\\CONFIG.xml".</param>
        /// <returns>
        /// True, pokud operace proběhla úspěšně, a konfigurace byla načtena do 'daikinAppConfigure'.
        /// False, pokud operace selhala a v 'error' je uložen popis chyby.
        /// </returns>
        public static bool TryReadXML(out AppConfiguration appConfiguration, out string error, string filePath = "CONFIG\\CONFIG.xml")
        {
            appConfiguration = null;
            error = string.Empty;

            try
            {
                if (File.Exists(filePath))
                {
                    // Inicializace XML serializeru pro třídu 'DaikinAppConfigure'.
                    var serializer = new XmlSerializer(typeof(AppConfiguration));

                    // Otevření a čtení XML souboru.
                    using (var sr = new StreamReader(filePath))
                    {
                        // Deserializace XML souboru na instanci 'DaikinAppConfigure'.
                        appConfiguration = (AppConfiguration)serializer.Deserialize(sr);
                    }
                }
                else
                {
                    error = $"Soubor {filePath} nebyl nalezen.";
                }

                // Vrací true, pokud nebyla zjištěna žádná chyba při operaci.
                return error.Length == 0;
            }
            catch (Exception ex)
            {
                // V případě výjimky nastaví 'error' na popis chyby a vrací false.
                error = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Zpracovává argumenty a konfiguruje instanci třídy 'DaikinAppConfigure' a 'Argumenty' na základě zadaných argumentů.
        /// </summary>
        /// <param name="konfiguraceAplikace">Instance 'DaikinAppConfigure', která má být konfigurována na základě zpracovaných argumentů.</param>
        /// <param name="argumentyPole">Pole řetězců obsahující argumenty, které budou zpracovány.</param>
        /// <returns>Instance 'ArgsCooperationModel', která obsahuje konfigurovanou instanci 'DaikinAppConfigure' a objekt 'Argumenty' s extrahovanými hodnotami argumentů.</returns>
        public static ArgsCooperationModel GetCooperationArguments(this AppConfiguration konfiguraceAplikace, string[] argumentyPole)
        {
            var argumenty = new Argumenty();

            // Zpracování argumentů s využitím metody ParseArguments definované v ArgumentyPole (necháme ji na uživateli ji definovat).
            argumentyPole.ParseArguments(ref argumenty);

            if (argumenty.ZobrazitNaCelouObrazovku)
            {
                if (konfiguraceAplikace.WindowConf == null)
                {
                    konfiguraceAplikace.WindowConf = new WindowConf();
                }
                konfiguraceAplikace.WindowConf.Fullscreen = true;
            }

            if (!argumenty.VyprázdnitBufferSériovéhoPortu)
            {
                if (konfiguraceAplikace.SerialPort == null)
                {
                    konfiguraceAplikace.SerialPort = new ObservableCollection<SerialPortConf>();
                }
                if (konfiguraceAplikace.SerialPort.FirstOrDefault(ee => ee.Description == "MAIN") == null)
                {
                    konfiguraceAplikace.SerialPort.Add(new SerialPortConf { PortName = "COM1", BcsDelay = 0, Description = "MAIN", ClearBuffer = false });
                }
                else
                {
                    konfiguraceAplikace.SerialPort.FirstOrDefault(ee => ee.Description == "MAIN").ClearBuffer = false;
                }
            }

            if (argumenty.ProdlevaSériovéKomunikace > 0)
            {
                if (konfiguraceAplikace.SerialPort == null)
                {
                    konfiguraceAplikace.SerialPort = new ObservableCollection<SerialPortConf>();
                }
                if (konfiguraceAplikace.SerialPort.FirstOrDefault(ee => ee.Description == "MAIN") == null)
                {
                    konfiguraceAplikace.SerialPort.Add(new SerialPortConf { PortName = "COM1", BcsDelay = (ushort)argumenty.ProdlevaSériovéKomunikace, Description = "MAIN", ClearBuffer = true });
                }
                else
                {
                    konfiguraceAplikace.SerialPort.FirstOrDefault(ee => ee.Description == "MAIN").BcsDelay = (ushort)argumenty.ProdlevaSériovéKomunikace;
                }
            }

            if (argumenty.NázevSériovéhoPortu.ToUpper().StartsWith("COM") && argumenty.NázevSériovéhoPortu.Length >= 4)
            {
                if (konfiguraceAplikace.SerialPort == null)
                {
                    konfiguraceAplikace.SerialPort = new ObservableCollection<SerialPortConf>();
                }
                if (konfiguraceAplikace.SerialPort.FirstOrDefault(ee => ee.Description == "MAIN") == null)
                {
                    konfiguraceAplikace.SerialPort.Add(new SerialPortConf { PortName = argumenty.NázevSériovéhoPortu.ToUpper(), BcsDelay = 0, Description = "MAIN", ClearBuffer = true });
                }
                else
                {
                    konfiguraceAplikace.SerialPort.FirstOrDefault(ee => ee.Description == "MAIN").PortName = argumenty.NázevSériovéhoPortu.ToUpper();
                }
            }

            if (argumenty?.VýškaOkna > 50)
            {
                if (konfiguraceAplikace.WindowConf == null)
                {
                    konfiguraceAplikace.WindowConf = new WindowConf();
                }
                konfiguraceAplikace.WindowConf.Height = argumenty.VýškaOkna ?? 800;
            }

            if (argumenty?.ŠířkaOkna > 50)
            {
                if (konfiguraceAplikace.WindowConf == null)
                {
                    konfiguraceAplikace.WindowConf = new WindowConf();
                }
                konfiguraceAplikace.WindowConf.Width = argumenty.ŠířkaOkna ?? 800;
            }

            if (argumenty?.HorníPozice != null)
            {
                if (konfiguraceAplikace.WindowConf == null)
                {
                    konfiguraceAplikace.WindowConf = new WindowConf();
                }
                konfiguraceAplikace.WindowConf.Top = argumenty.HorníPozice ?? 0;
            }

            if (argumenty?.LeváPozice != null)
            {
                if (konfiguraceAplikace.WindowConf == null)
                {
                    konfiguraceAplikace.WindowConf = new WindowConf();
                }
                konfiguraceAplikace.WindowConf.Left = argumenty.LeváPozice ?? 0;
            }

            if (argumenty?.ZakázatŠirokoúhlýDisplej == true)
            {
                if (konfiguraceAplikace.WindowConf == null)
                {
                    konfiguraceAplikace.WindowConf = new WindowConf();
                }
                konfiguraceAplikace.WindowConf.WidescreenAlways = false;
            }


            // Vrací objekt 'ArgsCooperationModel' s konfigurací aplikace a objektem argumentů.
            return new ArgsCooperationModel { KonfiguraceAplikace = konfiguraceAplikace, Argumenty = argumenty };
        }

        /// <summary>
        /// Parsuje pole řetězců obsahující argumenty a aktualizuje objekt 'Argumenty' na základě těchto argumentů.
        /// </summary>
        /// <param name="argumentyPole">Pole řetězců obsahující argumenty.</param>
        /// <param name="argumenty">Odkaz na objekt 'Argumenty', který má být aktualizován s vyextrahovanými hodnotami.</param>
        public static void ParseArguments(this string[] argumentyPole, ref Argumenty argumenty)
        {
            string seznamArgumentů = string.Empty;
            string výrobníLinka = string.Empty;
            ushort? poziceVeVýrobě = null;
            bool celáObrazovka = false;
            bool vyprázdnitBuffer = true;
            ushort? prodlevaSériovéKomunikace = null;
            string informaceOArgumentech = string.Empty;
            string názevSériovéhoPortu = string.Empty;
            float? šířkaOkna = null;
            float? výškaOkna = null;
            float? horníPozice = null;
            float? leváPozice = null;
            bool? druhýMonitor = null;
            bool? zapnoutSkrytíFunkcí = null;
            string čísloZáznamuDashboardu = string.Empty;

            foreach (var položka in argumentyPole)
            {
                seznamArgumentů += položka;

                // Argument pro identifikaci v produkci - LINK
                if (položka.ToUpper().Contains("LINE="))
                {
                    výrobníLinka = položka.ToUpper().Replace("LINE=", "");
                }

                // Argument pro pozici v produkci - POSITION
                if (položka.ToUpper().Contains("POSITION="))
                {
                    var pozice = položka.ToUpper().Replace("POSITION=", "");
                    poziceVeVýrobě = ushort.TryParse(pozice, out ushort poziceVProdukci) ? poziceVProdukci : (ushort)1;
                }

                // Aktivace celoobrazovkového režimu - FULLSCREEN
                if (položka.ToUpper().Contains("FULLSCREEN"))
                {
                    celáObrazovka = true;
                }

                // Argument pro druhý monitor - SECOND
                if (položka.ToUpper().Contains("SECOND"))
                {
                    druhýMonitor = true;
                }

                // Argument pro skrytí funkcí - FEATURE
                if (položka.ToUpper().Contains("FEATURE"))
                {
                    zapnoutSkrytíFunkcí = true;
                }

                // Deaktivace vyprázdnění bufferu sériového portu - CLEARBUFFER
                if (položka.ToUpper().Contains("CLEARBUFFER"))
                {
                    vyprázdnitBuffer = false;
                }

                // Standardní režim okna - STANDARD
                if (položka.ToUpper().Contains("STANDARD"))
                {
                    druhýMonitor = false;
                }

                // Prodleva pro sériovou komunikaci - BCSDELAY
                if (položka.ToUpper().Contains("BCSDELAY="))
                {
                    var prodleva = položka.ToUpper().Replace("BCSDELAY=", "");
                    prodlevaSériovéKomunikace = ushort.TryParse(prodleva, out ushort prodlevaKomunikace) ? prodlevaKomunikace : (ushort)1000;
                }

                // Nastavení názvu sériového portu - COM
                if (položka.ToUpper().Contains("COM="))
                {
                    názevSériovéhoPortu = položka.ToUpper().Replace("COM=", "");
                }

                // Číslo záznamu pro Dashboard - REC_NO
                if (položka.ToUpper().Contains("REC_NO="))
                {
                    čísloZáznamuDashboardu = položka.ToUpper().Replace("REC_NO=", "");
                }

                // Výška okna - HEIGHT
                if (položka.ToUpper().Contains("HEIGHT="))
                {
                    try
                    {
                        výškaOkna = int.Parse(položka.ToUpper().Replace("HEIGHT=", ""));
                    }
                    catch { }
                }

                // Šířka okna - WIDTH
                if (položka.ToUpper().Contains("WIDTH="))
                {
                    try
                    {
                        šířkaOkna = int.Parse(položka.ToUpper().Replace("WIDTH=", ""));
                    }
                    catch { }
                }

                // Horní pozice okna - TOP
                if (položka.ToUpper().Contains("TOP="))
                {
                    try
                    {
                        horníPozice = int.Parse(položka.ToUpper().Replace("TOP=", ""));
                    }
                    catch { }
                }

                // Levá pozice okna - LEFT
                if (položka.ToUpper().Contains("LEFT="))
                {
                    try
                    {
                        leváPozice = int.Parse(položka.ToUpper().Replace("LEFT=", ""));
                    }
                    catch { }
                }

                // Informace o argumentech pro hlavní MessageBox
                informaceOArgumentech = $"VÝROBNÍ LINKA: {výrobníLinka}\nPOZICE: {poziceVeVýrobě}\nCELOOBRAZOVKOVÝ REŽIM: {celáObrazovka}\nVYPRÁZDNIT BUFFER SÉRIOVÉHO PORTU: {vyprázdnitBuffer}\nPRODLEVA SÉRIOVÉ KOMUNIKACE: {prodlevaSériovéKomunikace}\nNÁZEV SÉRIOVÉHO PORTU: {názevSériovéhoPortu}";
            }

            argumenty = new Argumenty
            {
                ZapnoutSkrytíFunkcí = zapnoutSkrytíFunkcí,
                ArgumentList = seznamArgumentů,
                InformaceOArgumentech = informaceOArgumentech,
                ProdlevaSériovéKomunikace = prodlevaSériovéKomunikace,
                VyprázdnitBufferSériovéhoPortu = vyprázdnitBuffer,
                ZobrazitNaCelouObrazovku = celáObrazovka,
                VýrobníLinka = výrobníLinka,
                PoziceVeVýrobě = poziceVeVýrobě,
                NázevSériovéhoPortu = názevSériovéhoPortu,
                ŠířkaOkna = šířkaOkna,
                VýškaOkna = výškaOkna,
                HorníPozice = horníPozice,
                LeváPozice = leváPozice,
                ČísloZáznamuDashboardu = čísloZáznamuDashboardu,
                DruhýMonitor = druhýMonitor ?? false
            };
        }
    }
}
