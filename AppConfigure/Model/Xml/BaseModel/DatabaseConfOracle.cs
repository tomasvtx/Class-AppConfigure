namespace AppConfigure.Model.Xml.BaseModel
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
}
