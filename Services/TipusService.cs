using Data;
using Entitats.PlatClasses;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class TipusService : ITipusService
    {
        private readonly DBContext _context;

        public TipusService(DBContext context)
        {
            _context = context;
        }

        public List<TipusCuina> GetTipusCuines()
        {
            return _context.TipusCuinas.ToList();
        }

        public List<TipusPreu> GetTipusPreus()
        {
            return _context.TipusPreus.ToList();
        }

        public List<TipusEstat> GetTipusEstats()
        {
            return _context.TipusEstats.ToList();
        }

        public List<TipusPlat> GetTipusPlats()
        {
            return _context.TipusPlats.ToList();
        }

        public TipusPlat GetTipusPlatById(int tipusPlatId)
        {
            return _context.TipusPlats.Where(tp => tp.id == tipusPlatId).FirstOrDefault();
        }
    }
}
