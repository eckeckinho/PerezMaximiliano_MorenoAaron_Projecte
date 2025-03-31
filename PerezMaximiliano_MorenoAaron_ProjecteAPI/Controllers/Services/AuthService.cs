using Data;
using Microsoft.EntityFrameworkCore;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;

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
        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _context.Usuaris.FirstOrDefaultAsync(u => u.correu == email);

            // Implementar logica de Login
            // ... 

            if (user == null)
            {

            }

            // Cambiar el return cuando se implemente la logica
            return user.correu;
        }
    }
}
