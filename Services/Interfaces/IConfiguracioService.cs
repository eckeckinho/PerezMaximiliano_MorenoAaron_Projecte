using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IConfiguracioService
    {
        Restaurant GetRestaurantConfig();
        Task<bool> CanviarContrasenyaRestaurant(String novaContrasenya);
        Task<bool> ActualitzarRestaurantConfig(Restaurant restaurant);
    }
}
