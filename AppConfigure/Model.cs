using System;

namespace AppConfigure
{
    public struct Model
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
            public DaikinAppConfigure KonfiguraceAplikace { get; set; }
        }

        /// <summary>
        /// Model pro argumenty aplikace.
        /// </summary>
        public class Argumenty
        {
            /// <summary>
            /// Seznam argumentů předaných aplikaci.
            /// </summary>
            public string ArgumentList { get; set; }

            /// <summary>
            /// Linka výroby použitá v produkci.
            /// </summary>
            public string VýrobníLinka { get; set; }

            /// <summary>
            /// Pozice v rámci výrobního procesu.
            /// </summary>
            public ushort? PoziceVeVýrobě { get; set; }

            /// <summary>
            /// Režim zobrazení na celou obrazovku.
            /// </summary>
            public bool ZobrazitNaCelouObrazovku { get; set; }

            /// <summary>
            /// Vyprázdnění bufferu sériového portu.
            /// </summary>
            public bool VyprázdnitBufferSériovéhoPortu { get; set; }

            /// <summary>
            /// Prodleva (delay) pro komunikaci přes sériový port.
            /// </summary>
            public ushort? ProdlevaSériovéKomunikace { get; set; }

            /// <summary>
            /// Informace o předaných argumentech pro hlavní okno aplikace.
            /// </summary>
            public string InformaceOArgumentech { get; set; }

            /// <summary>
            /// Název sériového portu.
            /// </summary>
            public string NázevSériovéhoPortu { get; set; }

            /// <summary>
            /// Šířka okna aplikace.
            /// </summary>
            public float? ŠířkaOkna { get; set; }

            /// <summary>
            /// Výška okna aplikace.
            /// </summary>
            public float? VýškaOkna { get; set; }

            /// <summary>
            /// Horní pozice okna.
            /// </summary>
            public float? HorníPozice { get; set; }

            /// <summary>
            /// Levá pozice okna.
            /// </summary>
            public float? LeváPozice { get; set; }

            /// <summary>
            /// Číslo záznamu Dashboard v produkci.
            /// </summary>
            public string ČísloZáznamuDashboardu { get; set; }

            /// <summary>
            /// Druhý monitor.
            /// </summary>
            public bool DruhýMonitor { get; set; }

            /// <summary>
            /// Zapnutí/skrytí určitých funkcí.
            /// </summary>
            public bool? ZapnoutSkrytíFunkcí { get; set; } 

            /// <summary>
            /// Zakázat režim širokoúhlého displeje.
            /// </summary>
            public bool ZakázatŠirokoúhlýDisplej { get; set; }
        }
    }
}
