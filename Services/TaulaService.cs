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
                var reservesAssociades = _context.Reservas.Where(r => r.taulaid == taula.id).ToList();
                if (reservesAssociades.Any())
                {
                    _context.Reservas.RemoveRange(reservesAssociades);
                }

                _context.Taules.Remove(taula);
            }

            int changes = _context.SaveChanges();

            return changes > 0;
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

        public List<Taula> GetTaulesDisponibles()
        {
            return _context.Taules.Where(x => x.restaurantId == _restaurantActual.id && x.asignada == false).OrderBy(x => x.numComensals).ToList();
        }

        public bool AddTaula(int comensalsTaula)
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
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al afegir taula. " + ex.Message, ex);
            }
        }

        public bool UpdateTaula(Taula taulaSeleccionada)
        {
            if (taulaSeleccionada == null) return false;

            _context.Taules.Update(taulaSeleccionada);

            int changes = _context.SaveChanges();

            if (changes > 0) return true;
            return false;
        }
    }
}
