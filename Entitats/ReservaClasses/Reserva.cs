using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.ReservaClasses
{
    public class Reserva
    {
        public int id { get; set; }
        public TimeSpan hora { get; set; }
        public DateTime datareserva { get; set; } 
        public int numcomensals { get; set; } 
        public int estatid { get; set; } 
        public int taulaid { get; set; } 
    }
}
