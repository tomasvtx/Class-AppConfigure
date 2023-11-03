namespace AppConfigure.Model.Xml
{
    /// <summary>
    /// Třída pro čtení konfigurace z XML souboru.
    /// </summary>
    public struct ReaderXml
    {
        /// <summary>
        /// Načtená konfigurace DAIKIN_AppConfigure.
        /// </summary>
        public AppConfiguration DaikinAppConfigure { get; set; }

        /// <summary>
        /// Chybová zpráva v případě, že došlo k výjimce při čtení XML.
        /// </summary>
        public string Exception { get; set; }
    }
}
