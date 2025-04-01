using Data;
using Entitats.Auth;
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
        private readonly IConfiguration _configuration;

        public AuthService(DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Task<string> LoginRestaurantAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginUsuariAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegistreRestaurantAsync(Restaurant newRestaurant)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegistreUsuariAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
