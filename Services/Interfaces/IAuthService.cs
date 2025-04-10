using Entitats.AuthClasses;
using Entitats.RestaurantClasses;
using System.Threading.Tasks;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces
{
    public interface IAuthService
    {
        Task<(bool, Restaurant)> LoginRestaurantAsync(string usuariRestaurant, string password);
        Task<bool> RegistreRestaurantAsync(Restaurant newRestaurant);
    }
}
