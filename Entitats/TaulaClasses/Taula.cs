using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.TaulaClasses
{
    public class Taula
    {
        public int id { get; set; }
        public int numComensals { get; set; }
        public bool? asignada { get; set; }
        public int restaurantId { get; set; }
    }
}
