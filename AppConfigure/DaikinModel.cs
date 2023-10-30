using System;
using System.Windows;
using System.Xml.Serialization;

namespace AppConfigure
{
    public struct DaikinModel
    {
        /// <summary>
        /// Reprezentuje aktivní desku.
        /// </summary>
        public class ActiveBoard
        {
            /// <summary>
            /// Popis aktivní desky.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Číslo záznamu aktivní desky.
            /// </summary>
            public ushort RecNo { get; set; }
        }

        /// <summary>
        /// Tabulky používané v aplikaci Daikin.
        /// </summary>
        [Serializable]
        public class DaikinTables
        {
            /// <summary>
            /// Tabulka NETSU_FA.
            /// </summary>
            public string NetsuFa { get; set; }

            /// <summary>
            /// Tabulka KUMI_FATable.
            /// </summary>
            public string KumiFaTable { get; set; }

            /// <summary>
            /// Tabulka SBNTable.
            /// </summary>
            public string SbnTable { get; set; }

            /// <summary>
            /// Tabulka DDSTable.
            /// </summary>
            public string DdsTable { get; set; }

            /// <summary>
            /// Tabulka ID_DATA.
            /// </summary>
            public string IdData { get; set; }
        }

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
}
