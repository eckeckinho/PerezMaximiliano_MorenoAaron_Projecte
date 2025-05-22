using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.TaulaClasses
{
    public class Taula
    {
        public int id { get; set; }
        public int numComensals { get; set; }
        public int restaurantId { get; set; }
    }

    public class CapacitatTaulaCombo
    {
        public int capacitat { get; set; }
        public int quantitat { get; set; }

        public override string ToString()
        {
            return capacitat == -1 ? $"Totes ({quantitat})" : $"{capacitat} comensals ({quantitat})";
        }
    }
}
