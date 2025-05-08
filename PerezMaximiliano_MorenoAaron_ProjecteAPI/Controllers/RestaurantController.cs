using Data;
using Entitats.ContacteClasses;
using Entitats.RestaurantClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public async Task<IActionResult> GetRestaurants(string ubicacio, string nomRestaurant)
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            if (String.IsNullOrEmpty(ubicacio) && String.IsNullOrEmpty(nomRestaurant))
            {
                restaurants = await _context.Restaurants.ToListAsync();
            } else if (!String.IsNullOrEmpty(ubicacio) || !String.IsNullOrEmpty(nomRestaurant))
            {
                if (!String.IsNullOrEmpty(ubicacio))
                {
                    restaurants = await _context.Restaurants
                        .Where(r => r.ciutat.ToLower().Equals(ubicacio.ToLower()))
                        .ToListAsync();
                }
                if (!String.IsNullOrEmpty(nomRestaurant))
                {
                    restaurants = await _context.Restaurants
                        .Where(r => r.nomRestaurant.ToLower().Contains(nomRestaurant.ToLower()))
                        .ToListAsync();
                }
            } else
            {
                restaurants = await _context.Restaurants
                    .Where(r => r.ciutat.ToLower().Equals(ubicacio.ToLower()) && r.nomRestaurant.ToLower().Contains(nomRestaurant.ToLower()))
                    .ToListAsync();
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
                } else
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
