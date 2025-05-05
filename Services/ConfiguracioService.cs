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

        public Task<bool> ActualitzarRestaurantConfig(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CanviarContrasenyaRestaurant(string novaContrasenya)
        {
            var restaurant = await _context.Restaurants.Where(x => x.nomCompte == _restaurantActual.nomCompte).FirstOrDefaultAsync();

            if (restaurant != null)
            {
                _restaurantActual.contrasenyaCompte = BCrypt.Net.BCrypt.HashPassword(novaContrasenya);
                _context.Restaurants.Update(_restaurantActual); 
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }   

        public Restaurant GetRestaurantConfig()
        {
            return _restaurantActual;
        }

        public async Task<bool> RegistreRestaurantAsync(Restaurant newRestaurant)
        {
            try
            {
                var restaurant = await _context.Restaurants.Where(x => x.nomCompte == newRestaurant.nomCompte).FirstOrDefaultAsync();

                if (restaurant == null)
                {
                    _context.Restaurants.Add(newRestaurant);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar restaurant. " + ex.Message, ex);
            }
        }
    }
}

