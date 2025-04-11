using Data;
using Entitats.AuthClasses;
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
                        return Unauthorized("Contrasenya incorrecta");
                    }
                }
                else
                {
                    return NotFound("Usuari no trobat");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al loguear usuari. " + ex.Message, ex);
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
                    return Ok("Registrat correctament.");
                }
                else
                {
                    return Conflict("L'usuari ja existeix.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar usuari. " + ex.Message, ex);
            }
        }
    }
}
