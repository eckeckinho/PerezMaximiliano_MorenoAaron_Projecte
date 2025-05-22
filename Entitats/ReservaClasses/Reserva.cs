using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.ReservaClasses
{
    public class Reserva
    {
        public int id { get; set; }
        public TimeSpan? hora { get; set; }
        public DateTime datareserva { get; set; }
        public int? numcomensals { get; set; }
        public int estatid { get; set; }
        public int taulaid { get; set; }
        public int usuariId { get; set; }
        public int durada { get; set; }
        public int restaurantid { get; set; }
        public bool valorat { get; set; }
    }

    public enum EstatReserva
    {
        EnProces = 4,
        Finalitzada = 5,
        Cancelada = 6
    }
}
