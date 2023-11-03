using AppConfigure.Model.Xml.BaseModel;
using System.IO.Ports;

namespace AppConfigure.Model.BaseModelProgr
{
    public partial class BaseModelProgr
    {
        /// <summary>
        /// Třída reprezentující konfiguraci sériového portu pro programování.
        /// Rozšiřuje základní konfiguraci sériového portu.
        /// </summary>
        public class SerialPortConfProg
        {
            /// <summary>
            /// Získá nebo nastaví objekt sériového portu pro programování.
            /// </summary>
            public SerialPort SerialPort { get; set; }

            public SerialPortConf SerialPortConf {get;set;}
        }
    }
}
