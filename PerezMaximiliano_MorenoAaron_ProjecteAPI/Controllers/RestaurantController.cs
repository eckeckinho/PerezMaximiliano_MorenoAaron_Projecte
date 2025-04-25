using Data;
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
    }
}
