using Entitats.RestaurantClasses;

namespace Services.Interfaces
{
    public interface IRestaurantContext
    {
        Restaurant restaurantActual { get; set; }
    }
}
