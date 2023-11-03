namespace AppConfigure.Model.Xml.BaseModel
{
    public class LoggerConfig
    {
        /// <summary>
        /// Umístění záznamu (výchozí hodnota: C:\PE_OUTPUT)
        /// </summary>
        public string RecordLocation { get; set; } = @"C:\PE_OUTPUT";

        /// <summary>
        /// Název záznamového souboru (výchozí hodnota: LOG)
        /// </summary>
        public string RecordFileName { get; set; } = "LOG";

        /// <summary>
        /// Cesta k záznamovému souboru pro aplikaci (výchozí hodnota: _Applog)
        /// </summary>
        public string AppLogPathName { get; set; } = "_Applog";

        /// <summary>
        /// Cesta k chybovému záznamovému souboru pro aplikaci (výchozí hodnota: _ErrLog)
        /// </summary>
        public string AppLogErorPath { get; set; } = "_ErrLog";

        /// <summary>
        /// Cesta k internímu chybovému záznamovému souboru (výchozí hodnota: _InternalErrorLog)
        /// </summary>
        public string AppLogErrorInternal { get; set; } = "_InternalErrorLog";
    }
}
