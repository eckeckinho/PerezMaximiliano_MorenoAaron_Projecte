using Data;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReservaService : IReservaService
    {
        private readonly DBContext _context;
        private readonly Restaurant _restaurantActual;

        public ReservaService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public bool CancelarReserves(List<Reserva> reservesSeleccionades)
        {
            if (reservesSeleccionades == null || reservesSeleccionades.Count == 0) return false;

            foreach (Reserva reserva in reservesSeleccionades)
            {
                reserva.estatid = 6;

                var taulaAssignada = _context.Taules.Where(x => x.id == reserva.taulaid).FirstOrDefault();

                if (taulaAssignada != null && taulaAssignada.asignada != null && taulaAssignada.asignada == true)
                {
                    taulaAssignada.asignada = false;
                }

                _context.Taules.Update(taulaAssignada);
                _context.Reservas.Update(reserva);
            }

            int changes = _context.SaveChanges();

            if (changes > 0) return true;
            return false;
        }

        public bool FinalitzarReserves(List<Reserva> reservesSeleccionades)
        {
            if (reservesSeleccionades == null || reservesSeleccionades.Count == 0) return false;

            foreach (Reserva reserva in reservesSeleccionades)
            {
                reserva.estatid = 5;

                var taulaAssignada = _context.Taules.Where(x => x.id == reserva.taulaid).FirstOrDefault();

                if (taulaAssignada != null && taulaAssignada.asignada != null && taulaAssignada.asignada == true)
                {
                    taulaAssignada.asignada = false;
                }

                _context.Taules.Update(taulaAssignada);
                _context.Reservas.Update(reserva);
            }

            int changes = _context.SaveChanges();

            if (changes > 0) return true;
            return false;
        }

        public List<Reserva> GetReservesRestaurant(int idEstat, DateTime desde, DateTime hasta)
        {
            // Obtener IDs de las mesas del restaurante actual
            var idTaulesRestaurant = _context.Taules
                .Where(x => x.restaurantId == _restaurantActual.id)
                .Select(x => x.id)
                .ToList();

            if (idTaulesRestaurant.Count == 0) return new List<Reserva>();  // Devuelve una lista vacía si no hay mesas

            // Construir la consulta paso a paso y aplicar los filtros

            var reservasRestaurante = _context.Reservas
                .Where(x => idTaulesRestaurant.Contains(x.taulaid))
                .Where(x => x.estatid == idEstat)
                .Where(x => x.datareserva >= desde.Date && x.datareserva <= hasta.Date)
                .OrderByDescending(x => x.id)
                .ToList();

            return reservasRestaurante;
        }

    }
}
