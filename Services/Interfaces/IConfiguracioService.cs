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
        bool CanviarContrasenyaRestaurant(String novaContrasenya);
        bool UpdateRestaurant(Restaurant updateRestaurant);
    }
}
