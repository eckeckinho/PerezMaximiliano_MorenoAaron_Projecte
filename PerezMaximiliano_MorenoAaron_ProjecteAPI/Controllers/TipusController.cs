using Data;
using Entitats.PlatClasses;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipusController : Controller
    {
        private readonly DBContext _context;

        public TipusController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("GetTipusCuines")]
        public async Task<List<TipusCuina>> GetTipusCuines()
        {
            return await _context.TipusCuinas.ToListAsync();
        }

        [HttpGet("GetTipusPreus")]
        public async Task<List<TipusPreu>> GetTipusPreus()
        {
            return await _context.TipusPreus.ToListAsync();
        }

        [HttpGet("GetTipusEstats")]
        public async Task<List<TipusEstat>> GetTipusEstats()
        {
            return await _context.TipusEstats.ToListAsync();
        }

        [HttpGet("GetTipusPlats")]
        public async Task<List<TipusPlat>> GetTipusPlats()
        {
            return await _context.TipusPlats.ToListAsync();
        }
    }
}
