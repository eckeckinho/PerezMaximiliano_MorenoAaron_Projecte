using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IAuthService _authService;

        public AuthController(DBContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Usuaris.ToListAsync();
            return Ok(users);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            await _authService.LoginAsync(email, password);
            return Ok();
        }
    }
}
