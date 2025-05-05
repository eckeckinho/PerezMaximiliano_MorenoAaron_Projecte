using Data;
using Entitats.AuthClasses;
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
        //private readonly IRestaurantContext _restContext;
        private readonly Restaurant _restaurantActual;

        public ReservaService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            //_restContext = restContext;
            _restaurantActual = restContext.restaurantActual;
        }

        public bool CanviarEstatReserva(List<Reserva> reservesSeleccionades, int nouEstat)
        {
            if (reservesSeleccionades == null || reservesSeleccionades.Count == 0) return false;

            foreach (Reserva reserva in reservesSeleccionades)
            {
                reserva.estatid = nouEstat;

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
            var idTaulesRestaurant = _context.Taules
                .Where(x => x.restaurantId == _restaurantActual.id)
                .Select(x => x.id)
                .ToList();

            if (idTaulesRestaurant.Count == 0)
                return new List<Reserva>();

            var reservasRestaurante = _context.Reservas
                .Where(x => idTaulesRestaurant.Contains(x.taulaid))
                .Where(x => x.estatid == idEstat)
                .Where(x => x.datareserva >= desde.Date && x.datareserva < hasta.Date.AddDays(1))
                .OrderByDescending(x => x.id)
                .ToList();

            return reservasRestaurante;
        }

        public async Task<List<Reserva>> GetReservesRestaurantAsync(int idEstat, DateTime desde, DateTime hasta)
        {
            var idTaulesRestaurant = await _context.Taules
                .Where(x => x.restaurantId == _restaurantActual.id)
                .Select(x => x.id)
                .ToListAsync();

            if (idTaulesRestaurant.Count == 0)
                return new List<Reserva>();

            var reservasRestaurante = await _context.Reservas
                .Where(x => idTaulesRestaurant.Contains(x.taulaid))
                .Where(x => x.estatid == idEstat)
                .Where(x => x.datareserva >= desde.Date && x.datareserva <= hasta.Date)
                .OrderByDescending(x => x.id)
                .ToListAsync();

            return reservasRestaurante;
        }

        public Usuari GetUsuariReserva(int usuariId)
        {
            try
            {
                var usuari = _context.Usuaris.Where(x => x.id == usuariId).FirstOrDefault();

                if (usuari == null)
                {
                    return null;
                }
                else
                {
                    return usuari;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al trobar l'usuari. " + ex.Message, ex);
            }
        }
    }
}
