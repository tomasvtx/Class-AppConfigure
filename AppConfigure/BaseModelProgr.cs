using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using static AppConfigure.BaseModel;

namespace AppConfigure
{
    public class BaseModelProgr
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
