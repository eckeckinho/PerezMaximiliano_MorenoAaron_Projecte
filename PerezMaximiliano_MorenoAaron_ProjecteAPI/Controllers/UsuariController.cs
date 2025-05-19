using Data;
using Entitats.AuthClasses;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariController : ControllerBase
    {
        private readonly DBContext _context;

        public UsuariController(DBContext context)
        {
            _context = context;
        }

        [HttpPut("UpdateUsuari")]
        public async Task<IActionResult> UpdateUsuari([FromBody] Usuari updUsuari)
        {
            try
            {
                var usuari = await _context.Usuaris.FirstOrDefaultAsync(x => x.id == updUsuari.id);

                if (usuari != null)
                {
                    _context.Entry(usuari).CurrentValues.SetValues(updUsuari);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("CanviarContrasenyaUsuari")]
        public async Task<IActionResult> CanviarContrasenyaUsuari([FromBody] ContrasenyaRequest contraRequest)
        {
            try
            {
                var usuari = await _context.Usuaris.FirstOrDefaultAsync(x => x.id == contraRequest.idUsuari);

                if (usuari != null)
                {
                    usuari.contrasenya = BCrypt.Net.BCrypt.HashPassword(contraRequest.contrasenya);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost("ComprovarContrasenya")]
        public async Task<IActionResult> ComprovarContrasenya([FromBody] ContrasenyaRequest contraRequest)
        {
            try
            {
                var usuari = await _context.Usuaris.FirstOrDefaultAsync(x => x.id == contraRequest.idUsuari);

                if (usuari != null && BCrypt.Net.BCrypt.Verify(contraRequest.contrasenya, usuari.contrasenya))
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetUsuariPerId")]
        public async Task<IActionResult> GetUsuariPerId([FromQuery] int id)
        {
            try
            {
                var usuari = await _context.Usuaris.FirstOrDefaultAsync(x => x.id == id);

                if (usuari != null)
                {
                    return Ok(usuari);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllUsuaris")]
        public async Task<IActionResult> GetAllUsuaris()
        {
            try
            {
                var usuaris = await _context.Usuaris.ToListAsync();

                if (usuaris != null)
                {
                    return Ok(usuaris);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
