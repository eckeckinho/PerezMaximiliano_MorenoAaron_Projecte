using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using System;

namespace Services.Interfaces
{
    public interface IConfiguracioService
    {
        Restaurant GetRestaurantConfig();
        bool CanviarContrasenyaRestaurant(String novaContrasenya);
        bool UpdateRestaurant(Restaurant updateRestaurant);
    }
}
