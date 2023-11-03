using System;
using System.Collections.ObjectModel;
using static AppConfigure.DaikinModel;
using static AppConfigure.BaseModel;

namespace AppConfigure
{
    /// <summary>
    /// Třída pro konfiguraci aplikace.
    /// </summary>
    public class AppConfiguration
    {
        /// <summary>
        /// Název aplikace (zobrazuje se v titulku hlavního okna).
        /// </summary>
        public string AppName { get; set; } = "AppName";

        /// <summary>
        /// Kolekce nastavení připojení k databázovým serverům.
        /// Výchozí databáze pro aplikaci je "MAIN".
        /// </summary>
        public ObservableCollection<DatabaseConfOracle> Database { get; set; } = new ObservableCollection<DatabaseConfOracle> ();

        /// <summary>
        /// Kolekce nastavení sériových portů.
        /// Výchozí sériový port pro aplikaci je "MAIN".
        /// </summary>
        public ObservableCollection<SerialPortConf> SerialPort { get; set; } = new ObservableCollection<SerialPortConf> ();

        /// <summary>
        /// Nastavení okna.
        /// </summary>
        public WindowConf WindowConf { get; set; } = new WindowConf();

        /// <summary>
        /// Logger aplikace.
        /// </summary>
        public LoggerConfig Logger { get; set; } = new LoggerConfig();


        /// <summary>
        /// Složka obrázků.
        /// </summary>
        public ImgFolder ImgFolder { get; set; } = new ImgFolder();
    }
}
