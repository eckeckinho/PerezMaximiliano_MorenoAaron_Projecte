using Data;
using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;
using System;
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

        public Task<string> LoginRestaurantAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginUsuariAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RegistreRestaurantAsync(Restaurant newRestaurant)
        {
            string text = "hola";
            return text;
        }

        public Task<string> RegistreUsuariAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
