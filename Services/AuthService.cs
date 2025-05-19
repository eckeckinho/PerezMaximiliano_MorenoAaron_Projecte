using Data;
using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;
using Services.Interfaces;
using System;
using System.Linq;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services
{
    public class AuthService : IAuthService
    {
        private readonly DBContext _context;

        public AuthService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
        }

        public (bool, Restaurant) LoginRestaurant(string usuariRestaurant, string password)
        {
            try
            {
                var restaurant = _context.Restaurants.Where(x => x.nomCompte == usuariRestaurant).FirstOrDefault();

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

        public bool RegistreRestaurant(Restaurant newRestaurant)
        {
            try
            {
                var restaurant = _context.Restaurants.Where(x => x.nomCompte == newRestaurant.nomCompte).FirstOrDefaultAsync();

                if (restaurant == null)
                {
                    _context.Restaurants.Add(newRestaurant);
                    _context.SaveChanges();
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
