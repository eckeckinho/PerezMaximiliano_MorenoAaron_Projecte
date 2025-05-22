using Data;
using Entitats.RestaurantClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly DBContext _context;

        public RestaurantController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("GetRestaurants")]
        public async Task<IActionResult> GetRestaurants(string? ubicacio, string? nomRestaurant)
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            // Si no se proporciona ni ubicación ni nombre, devolver todos los restaurantes
            if (String.IsNullOrWhiteSpace(ubicacio) && String.IsNullOrWhiteSpace(nomRestaurant))
            {
                restaurants = await _context.Restaurants.ToListAsync();
            }
            // Si solo se proporciona uno de los dos filtros (ubicación o nombre)
            else if (String.IsNullOrWhiteSpace(ubicacio) || String.IsNullOrWhiteSpace(nomRestaurant))
            {
                // Si solo se proporciona la ubicación, filtrar por ciudad exacta 
                if (!String.IsNullOrWhiteSpace(ubicacio))
                {
                    restaurants = await _context.Restaurants.Where(r => r.ciutat.ToLower().Equals(ubicacio.ToLower())).ToListAsync();
                }

                // Si solo se proporciona el nombre, buscar coincidencias parciales 
                if (!String.IsNullOrWhiteSpace(nomRestaurant))
                {
                    restaurants = await _context.Restaurants.Where(r => r.nomRestaurant.ToLower().Contains(nomRestaurant.ToLower())).ToListAsync();
                }
            }
            // Si se proporcionan ambos filtros, buscar ubicación exacta y nombre parcial
            else
            {
                restaurants = await _context.Restaurants.Where(r => r.ciutat.ToLower().Equals(ubicacio.ToLower()) &&
                        r.nomRestaurant.ToLower().Contains(nomRestaurant.ToLower())).ToListAsync();
            }

            return Ok(restaurants);
        }

        [HttpGet("GetAllRestaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await _context.Restaurants.ToListAsync();

            return Ok(restaurants);
        }

        [HttpGet("GetRestaurantsFavorits")]
        public async Task<IActionResult> GetRestaurantsFavorits([FromQuery] int usuariId)
        {
            var restaurantsFavoritsUsuari = await _context.FavoritsUsuaris.Where(f => f.usuariid == usuariId).ToListAsync();

            return Ok(restaurantsFavoritsUsuari);
        }

        [HttpPost("AddRestaurantFavoritUsuari")]
        public async Task<IActionResult> AddRestaurantFavoritUsuari([FromBody] FavoritsUsuari restFavoritUsuari)
        {
            try
            {
                _context.FavoritsUsuaris.Add(restFavoritUsuari);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteRestaurantFavoritUsuari")]
        public async Task<IActionResult> DeleteRestaurantFavoritUsuari([FromQuery] int usuariId, [FromQuery] int restaurantId)
        {
            try
            {
                var restaurantFavoritUsuari = await _context.FavoritsUsuaris.Where(x => x.usuariid == usuariId && x.restaurantid == restaurantId).FirstOrDefaultAsync();

                if (restaurantFavoritUsuari != null)
                {
                    _context.FavoritsUsuaris.Remove(restaurantFavoritUsuari);
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
                {
                    return BadRequest();
                }
            }
        }

        [HttpGet("GetPlats")]
        public async Task<IActionResult> GetPlats(int restaurantId)
        {
            var plats = await _context.Plats.Where(x => x.restaurantid == restaurantId).ToListAsync();

            return Ok(plats);
        }

        [HttpGet("GetHorari")]
        public async Task<IActionResult> GetHorari(int restaurantId)
        {
            var horari = await _context.Horaris.Where(x => x.restaurantid == restaurantId).ToListAsync();

            return Ok(horari);
        }
    }
}
