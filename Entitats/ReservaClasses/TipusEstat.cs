using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.ReservaClasses
{
    public class TipusEstat
    {
        public int id { get; set; }
        public string descripcio { get; set; }
    }

    public class EstatAmbCompte
    {
        public int id { get; set; }
        public string descripcio { get; set; }
        public int compte { get; set; }
        public string mostrarText => $"{descripcio} ({compte})";
    }
}
