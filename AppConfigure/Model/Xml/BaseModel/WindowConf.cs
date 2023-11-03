using System;

namespace AppConfigure.Model.Xml.BaseModel
{
        /// <summary>
        /// Nastavení okna aplikace.
        /// </summary>
        [Serializable]
        public class WindowConf
        {
            /// <summary>
            /// Indikuje, zda má být okno v režimu celé obrazovky (fullscreen).
            /// Výchozí hodnota je false.
            /// </summary>
            public bool? Fullscreen { get; set; } = false;

            /// <summary>
            /// Indikuje, zda má být okno zobrazeno na druhém monitoru.
            /// Výchozí hodnota je false.
            /// </summary>
            public bool? SecondMonitor { get; set; } = false;

            /// <summary>
            /// Indikuje, zda má být okno umístěno na střed obrazovky.
            /// Výchozí hodnota je false.
            /// </summary>
            public bool? Center { get; set; } = false;

            /// <summary>
            /// Šířka okna (výchozí hodnota je NaN).
            /// </summary>
            public double? Width { get; set; } = double.NaN;

            /// <summary>
            /// Výška okna (výchozí hodnota je NaN).
            /// </summary>
            public float Height { get; set; } = float.NaN;

            /// <summary>
            /// Pozice horního okraje okna (výchozí hodnota je NaN).
            /// </summary>
            public float Top { get; set; } = float.NaN;

            /// <summary>
            /// Pozice levého okraje okna (výchozí hodnota je NaN).
            /// </summary>
            public float Left { get; set; } = float.NaN;

            /// <summary>
            /// Indikuje, zda má být vždy používán širokoúhlý režim displeje.
            /// </summary>
            public bool WidescreenAlways { get; set; } = true;
        }
}
