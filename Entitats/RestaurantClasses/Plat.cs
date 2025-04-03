using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.RestaurantClasses
{
    public class Plat
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string descripcio { get; set; }
        public decimal preu { get; set; }
        public int restaurantid { get; set; }
        public int tipusPlatId { get; set; }
    }
}
