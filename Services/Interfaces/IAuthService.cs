using Entitats.AuthClasses;
using Entitats.RestaurantClasses;
using System.Threading.Tasks;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginUsuariAsync(string email, string password);
        Task<bool> RegistreUsuariAsync(Usuari newUsuari);
        Task<(bool, Restaurant)> LoginRestaurantAsync(string usuariRestaurant, string password);
        Task<bool> RegistreRestaurantAsync(Restaurant newRestaurant);
    }
}
