using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace AppConfigure
{
    public class BaseModel
    {
        /// <summary>
        /// Nastavení připojení k databázovému serveru.
        /// </summary>
        public class DatabaseConfOracle
        {
            /// <summary>
            /// Popis připojení k databázovému serveru.
            /// </summary>
            public string Description { get; set; } = "MAIN";
            /// <summary>
            /// Řetězec připojení k databázovému serveru.
            /// </summary>
            public string ConnectionString { get; set; } = "Data Source=MyOracleDB;User Id=myUsername;Password=myPassword;Integrated Security=no;";
        }

        /// <summary>
        /// Nastavení sériového portu.
        /// </summary>
        public class SerialPortConf
        {
            private ushort? bcsDelay = 2500;
            private string portName;
            private string description;

            /// <summary>
            /// Popis sériového portu.
            /// </summary>
            public string Description
            {
                get
                {
                    return description;
                }
                set
                {
                    if (value == null)
                    {
                        value = "MAIN";
                    }
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException("Popis portu musí být alespoň jeden znam");
                    description = value;
                }
            }

            /// <summary>
            /// Název sériového portu (výchozí je "COM1").
            /// </summary>
            public string PortName
            {
                get { return portName; }
                set
                {
                    if (value == null)
                    {
                        value = "COM1";
                    }
                    if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^COM\d+$"))
                        throw new ArgumentException("Název portu musí být ve formátu 'COMx', kde x je číslo.");
                    portName = value;
                }
            }

            /// <summary>
            /// Indikuje, zda se má vyprázdnit buffer sériového portu.
            /// Výchozí hodnota je true.
            /// </summary>
            public bool? ClearBuffer { get; set; } = true;

            /// <summary>
            /// Prodleva v komunikaci na sériovém portu (výchozí je 0).
            /// </summary>
            public ushort? BcsDelay
            {
                get
                {
                    return bcsDelay;
                }
                set
                {
                    if (value == null)
                    {
                        value = 800;
                    }
                    if (value < 800)
                        throw new ArgumentException("ReadTimeout musí být alespoň 800 milisekund.");
                    bcsDelay = value;
                }
            }
            public override string ToString()
            {
                return $"{Description} - BcsDelay je nastaven na: {BcsDelay} DiscardInBuffer je nastaven na: {ClearBuffer}, Název portu je: {PortName}";
            }
        }

        /// <summary>
        /// Nastavení okna aplikace.
        /// </summary>
        [Serializable]
        public class WindowConf
        {
            /// <summary>
            /// Indikuje, zda má být okno v režimu celé obrazovky (fullscreen).
            /// Výchozí hodnota je false.
            /// </summary>
            public bool? Fullscreen { get; set; } = false;

            /// <summary>
            /// Indikuje, zda má být okno zobrazeno na druhém monitoru.
            /// Výchozí hodnota je false.
            /// </summary>
            public bool? SecondMonitor { get; set; } = false;

            /// <summary>
            /// Indikuje, zda má být okno umístěno na střed obrazovky.
            /// Výchozí hodnota je false.
            /// </summary>
            public bool? Center { get; set; } = false;

            /// <summary>
            /// Šířka okna (výchozí hodnota je NaN).
            /// </summary>
            public double? Width { get; set; } = double.NaN;

            /// <summary>
            /// Výška okna (výchozí hodnota je NaN).
            /// </summary>
            public float Height { get; set; } = float.NaN;

            /// <summary>
            /// Pozice horního okraje okna (výchozí hodnota je NaN).
            /// </summary>
            public float Top { get; set; } = float.NaN;

            /// <summary>
            /// Pozice levého okraje okna (výchozí hodnota je NaN).
            /// </summary>
            public float Left { get; set; } = float.NaN;

            /// <summary>
            /// Indikuje, zda má být vždy používán širokoúhlý režim displeje.
            /// </summary>
            public bool WidescreenAlways { get; set; } = true;
        }

        public class LoggerConfig
        {
            public string RecordLocation { get; set; } = @"C:\PE_OUTPUT";
            public string RecordFileName { get; set; } = @"LOG";
            public string AppLogPathName { get; set; } = "_Applog";
            public string AppLogErorPath { get; set; } = "_ErrLog";
            public string AppLogErrorInternal { get; set; } = "_InternalErrorLog";
        }
    }
}
