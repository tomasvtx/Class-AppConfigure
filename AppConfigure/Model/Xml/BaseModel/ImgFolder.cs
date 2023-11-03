namespace AppConfigure.Model.Xml.BaseModel
{
        /// <summary>
        /// Složka pro obrázky.
        /// </summary>
        public class ImgFolder
        {
            /// <summary>
            /// Název složky s obrázky.
            /// </summary>
            public string FolderLocation { get; set; }

            /// <summary>
            /// Určuje, zda se má složka s obrázky umístit do umístění aplikace.
            /// </summary>
            public bool UseAppLocation { get; set; }
                
            /// <summary>
            /// Uživatelské jméno pro FTP přenos obrázků.
            /// </summary>
            public string FtpUsername { get; set; }

            /// <summary>
            /// Heslo pro FTP přenos obrázků.
            /// </summary>
            public string FtpPassword { get; set; }
    }
}
