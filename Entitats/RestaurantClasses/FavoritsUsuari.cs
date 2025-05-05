using System;
using System.Collections.Generic;
using System.Text;

namespace Entitats.RestaurantClasses
{
    public class FavoritsUsuari
    {
        public int id { get; set; }
        public int usuariid { get; set; }
        public int restaurantid { get; set; }

    }
}
