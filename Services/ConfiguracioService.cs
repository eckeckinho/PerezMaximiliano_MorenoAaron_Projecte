using Data;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConfiguracioService : IConfiguracioService
    {
        private readonly DBContext _context;
        private readonly Restaurant _restaurantActual;

        public ConfiguracioService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public Restaurant GetRestaurantConfig()
        {
            return _restaurantActual;
        }
    }
}
