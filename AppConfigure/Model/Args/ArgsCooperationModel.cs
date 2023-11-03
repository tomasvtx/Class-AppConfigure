using AppConfigure.Model.Xml;

namespace AppConfigure.Model.Args
{
        /// <summary>
        /// Model pro argumenty a nastavení aplikace.
        /// </summary>
        public struct ArgsCooperationModel
        {
            /// <summary>
            /// Seznam argumentů předaných aplikaci.
            /// </summary>
            public Argumenty Argumenty { get; set; }

            /// <summary>
            /// Konfigurace hlavní aplikace.
            /// </summary>
            public AppConfiguration KonfiguraceAplikace { get; set; }
        }
}
