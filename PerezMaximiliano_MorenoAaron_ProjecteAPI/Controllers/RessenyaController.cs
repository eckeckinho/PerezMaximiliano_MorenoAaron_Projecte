using Data;
using Entitats.RessenyaClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                //Afegim ressenya
                _context.Ressenyas.Add(ressenya);

                var ressenyesRestaurant = await _context.Ressenyas.Where(x => x.restaurantid == ressenya.restaurantid).ToListAsync();

                // Calcular la mitjana de les valoracions i l'assignem al restaurant de la ressenya
                var valoracioRestaurant = ressenyesRestaurant.Sum(x => x.valoracio) / ressenyesRestaurant.Count;

                var restaurant = await _context.Restaurants.Where(x => x.id == ressenya.restaurantid).FirstOrDefaultAsync();

                restaurant.valoraciomedia = (decimal?)valoracioRestaurant;

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


        [HttpPut("ConfirmarRessenya")]
        public async Task<IActionResult> ConfirmarRessenya(int reservaId)
        {
            try
            {
                var reserva = await _context.Reservas.Where(x => x.id == reservaId).FirstOrDefaultAsync();

                if (reserva == null)
                {
                    return NotFound();
                }

                reserva.valorat = true;

                await _context.SaveChangesAsync();

                return Ok("Ressenya confirmada");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
