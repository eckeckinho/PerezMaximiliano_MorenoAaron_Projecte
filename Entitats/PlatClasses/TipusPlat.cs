using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.PlatClasses
{
    public class TipusPlat
    {
        public int id { get; set; }
        public string descripcio { get; set; }
    }

    public class TipusPlatCombo
    {
        public int id { get; set; }
        public string descripcio { get; set; }
        public int quantitat { get; set; }

        public override string ToString()
        {
            return id == -1 ? $"Tots ({quantitat})" : $"{descripcio} ({quantitat})";
        }
    }

}
