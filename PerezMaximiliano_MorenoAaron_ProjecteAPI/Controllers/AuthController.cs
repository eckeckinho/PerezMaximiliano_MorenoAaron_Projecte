using Data;
using Entitats.AuthClasses;
using Entitats.ContacteClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DBContext _context;

        public AuthController(DBContext context) 
        {
            _context = context;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Usuaris.ToListAsync();
            return Ok(users);
        }

        [HttpPost("LoginUsuari")]
        public async Task<IActionResult> LoginUsuari([FromBody] LoginReq loginRequest)
        {
            try
            {
                var usuari = await _context.Usuaris.Where(x => x.correu == loginRequest.correu).FirstOrDefaultAsync();

                if (usuari != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(loginRequest.contrasenya, usuari.contrasenya))
                    {
                        return Ok(usuari);

                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpPost("RegistreUsuari")]
        public async Task<IActionResult> RegistreUsuari([FromBody] Usuari newUsuari)
        {
            try
            {
                var usuari = await _context.Usuaris.Where(x => x.correu == newUsuari.correu).FirstOrDefaultAsync();

                if (usuari == null)
                {
                    newUsuari.contrasenya = BCrypt.Net.BCrypt.HashPassword(newUsuari.contrasenya);
                    _context.Usuaris.Add(newUsuari);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
