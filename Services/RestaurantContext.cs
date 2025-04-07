using Entitats.RestaurantClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class RestaurantContext : IRestaurantContext
    {
        public Restaurant restaurantActual { get; set; }
    }
}
