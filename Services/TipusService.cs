using Data;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TipusService : ITipusService
    {
        private readonly DBContext _context;

        public TipusService(DBContext context)
        {
            _context = context;
        }

        public async Task<List<TipusCuina>> GetTipusCuines()
        {
            return await _context.TipusCuinas.ToListAsync();
        }

        public async Task<List<TipusPreu>> GetTipusPreus()
        {
            return await _context.TipusPreus.ToListAsync();
        }

        public async Task<List<TipusEstat>> GetTipusEstats()
        {
            return await _context.TipusEstats.ToListAsync();
        }
    }
}
