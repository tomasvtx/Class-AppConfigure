using System;
using System.Text.RegularExpressions;

namespace AppConfigure.Model.Xml.BaseModel
{
    /// <summary>
    /// Nastavení sériového portu.
    /// </summary>
    public class SerialPortConf
    {
        private ushort? bcsDelay = 2500;
        private string portName;
        private string description;

        /// <summary>
        /// Popis sériového portu.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value == null)
                {
                    value = "MAIN";
                }
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Popis portu musí být alespoň jeden znam");
                description = value;
            }
        }

        /// <summary>
        /// Název sériového portu (výchozí je "COM1").
        /// </summary>
        public string PortName
        {
            get { return portName; }
            set
            {
                if (value == null)
                {
                    value = "COM1";
                }
                if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^COM\d+$"))
                    throw new ArgumentException("Název portu musí být ve formátu 'COMx', kde x je číslo.");
                portName = value;
            }
        }

        /// <summary>
        /// Indikuje, zda se má vyprázdnit buffer sériového portu.
        /// Výchozí hodnota je true.
        /// </summary>
        public bool? ClearBuffer { get; set; } = true;

        /// <summary>
        /// Prodleva v komunikaci na sériovém portu (výchozí je 0).
        /// </summary>
        public ushort? BcsDelay
        {
            get
            {
                return bcsDelay;
            }
            set
            {
                if (value == null)
                {
                    value = 800;
                }
                if (value < 800)
                    throw new ArgumentException("ReadTimeout musí být alespoň 800 milisekund.");
                bcsDelay = value;
            }
        }
        public override string ToString()
        {
            return $"{Description} - BcsDelay je nastaven na: {BcsDelay} DiscardInBuffer je nastaven na: {ClearBuffer}, Název portu je: {PortName}";
        }
    }
}
