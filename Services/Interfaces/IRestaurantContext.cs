using Entitats.RestaurantClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IRestaurantContext
    {
        Restaurant restaurantActual { get; set; }
    }
}
