using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.RessenyaClasses
{
    public class Ressenya
    {
        public int id { get; set; }
        public string comentari { get; set; }
        public DateTime dataressenya { get; set; }
        public double valoracio { get; set; }
        public string imatge { get; set; }
        public int usuariid { get; set; }
        public int restaurantid { get; set; }

    }
}
