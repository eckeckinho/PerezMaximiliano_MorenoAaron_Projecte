using Entitats.AuthClasses;
using Entitats.RestaurantClasses;
using System.Threading.Tasks;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces
{
    public interface IAuthService
    {
        (bool, Restaurant) LoginRestaurant(string usuariRestaurant, string password);
        bool RegistreRestaurant(Restaurant newRestaurant);
    }
}
