using Entitats.RestaurantClasses;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces
{
    public interface IAuthService
    {
        (bool, Restaurant) LoginRestaurant(string usuariRestaurant, string password);
        bool RegistreRestaurant(Restaurant newRestaurant);
    }
}
