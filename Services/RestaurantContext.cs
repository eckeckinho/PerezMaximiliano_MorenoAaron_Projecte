using Entitats.RestaurantClasses;
using Services.Interfaces;

namespace Services
{
    public class RestaurantContext : IRestaurantContext
    {
        public Restaurant restaurantActual { get; set; }
    }
}
