using Data;
using Entitats.RessenyaClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RessenyaController : Controller
    {
        private readonly DBContext _context;

        public RessenyaController(DBContext context)
        {
            _context = context;
        }

        [HttpPost("AddRessenya")]
        public async Task<IActionResult> AddRessenya([FromBody] Ressenya ressenya)
        {
            try
            {
                _context.Ressenyas.Add(ressenya);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetRessenyaUsuari")]
        public async Task<IActionResult> GetRessenyaUsuari([FromQuery] int usuariid)
        {
            try
            {
                var ressenyesUsuari = await _context.Ressenyas.Where(x=>x.usuariid == usuariid).ToListAsync();

                return Ok(ressenyesUsuari);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetRessenyaRestaurant")]
        public async Task<IActionResult> GetRessenyaRestaurant([FromQuery] int restaurantid)
        {
            try
            {
                var ressenyesRestaurant = await _context.Ressenyas.Where(x=> x.restaurantid == restaurantid).ToListAsync();

                return Ok(ressenyesRestaurant);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
