using AppConfigure.Model.Xml.BaseModel;
using System.Data;

namespace AppConfigure.Model.BaseModelProgr
{
    public partial class BaseModelProgr
    {
        /// <summary>
        /// Třída reprezentující konfiguraci databáze pro programování.
        /// Rozšiřuje základní konfiguraci databáze.
        /// </summary>
        public class DatabaseConfProg
        {
            /// <summary>
            /// Získá nebo nastaví objekt sériového portu pro programování.
            /// </summary>
            public IDbConnection DbConnection { get; set; }

            public DatabaseConfOracle DatabaseConf { get; set; }
        }
    }
}
