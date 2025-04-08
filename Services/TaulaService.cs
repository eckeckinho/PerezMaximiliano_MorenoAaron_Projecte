using Data;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TaulaService : ITaulaService
    {
        private readonly DBContext _context;
        private readonly Restaurant _restaurantActual;

        public TaulaService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public bool DeleteTaules(List<Taula> taulesSeleccionades)
        {
            if (taulesSeleccionades == null || taulesSeleccionades.Count == 0) return false;

            foreach (Taula taula in taulesSeleccionades)
            {
                _context.Taules.Remove(taula);
            }

            int changes = _context.SaveChanges();

            if (changes > 0) return true;
            return false;
        }

        public int GetAforamentActual()
        {
            var taulesRestaurantAssignades = _context.Taules.Where(x => x.restaurantId == _restaurantActual.id)
            .Where(x=> (bool)x.asignada)    
            .ToList();
            
            return taulesRestaurantAssignades.Sum(x=> x.numComensals);
        }

        public int GetAforamentMaxim()
        {
            var taulesRestaurant = _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).ToList();
            
            return taulesRestaurant.Sum(x=> x.numComensals);
        }

        public List<Taula> GetTaules()
        {
            return _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).OrderBy(x => x.numComensals).ToList();
        }
    }
}
