using Data;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddTaulaAsync(int comensalsTaula)
        {
            try
            {
                Taula newTaula = new Taula()
                {
                    numComensals = comensalsTaula,
                    asignada = false,
                    restaurantId = _restaurantActual.id
                };

                _context.Taules.Add(newTaula);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al afegir taula. " + ex.Message, ex);
            }
        }

        public async Task<bool> UpdateTaulaAsync(Taula taulaSeleccionada)
        {
            if (taulaSeleccionada == null) return false;

            _context.Taules.Update(taulaSeleccionada);

            int changes = await _context.SaveChangesAsync();

            if (changes > 0) return true;
            return false;
        }
    }
}
