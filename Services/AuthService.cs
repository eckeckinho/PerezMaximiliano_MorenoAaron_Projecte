using BCrypt.Net;
using Data;
using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services
{
    public class AuthService : IAuthService
    {
        private readonly DBContext _context;
        public AuthService()
        {
        }

        public AuthService(DBContext context)
        {
            _context = context;
        }

        public async Task<(bool, Restaurant)> LoginRestaurantAsync(string usuariRestaurant, string password)
        {
            try
            {
                var restaurant = await _context.Restaurants.Where(x => x.nomCompte == usuariRestaurant).FirstOrDefaultAsync();

                if (restaurant != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, restaurant.contrasenyaCompte))
                    {
                        return (true, restaurant);
                    }
                    else
                    {
                        return (false, null);
                    }
                }
                else
                {
                    return (false, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al loguear restaurant. " + ex.Message, ex);
            }
        }


        public Task<string> LoginUsuariAsync(string email, string password)
        {
            throw new NotImplementedException();
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

        public Task<string> RegistreUsuariAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
