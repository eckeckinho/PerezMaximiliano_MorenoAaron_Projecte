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
        private readonly Restaurant _restaurantActual;

        public ReservaService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public bool AfegirReserva(Reserva newReserva)
        {
            try
            {
                if (newReserva != null)
                {
                    AssignarTaula(newReserva.taulaid);
                    _context.Reservas.Add(newReserva);
                    _context.SaveChanges();

                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al afegir la reserva. " + ex.Message, ex);
            }
        }

        public bool CanviarEstatReserva(List<Reserva> reservesSeleccionades, int nouEstat)
        {
            if (reservesSeleccionades == null || reservesSeleccionades.Count == 0) return false;

            foreach (Reserva reserva in reservesSeleccionades)
            {
                switch (nouEstat)
                {
                    case 4: // En procés → mesa ocupada
                        AssignarTaula(reserva.taulaid);
                        break;
                    case 5: // Finalitzada → mesa libre
                    case 6: // Cancel·lada → mesa libre
                        AlliberarTaula(reserva.taulaid);
                        break;
                }

                reserva.estatid = nouEstat;
                _context.Reservas.Update(reserva);
            }

            int changes = _context.SaveChanges();

            return changes > 0;
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

        public bool UpdateEstatTaula(int taulaId)
        {
            try
            {
                var taula = _context.Taules.Where(x => x.id == taulaId).FirstOrDefault();
                if (taula != null && taula.asignada == true)
                {
                    taula.asignada = false;
                    _context.Taules.Update(taula);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualitzar l'estat de la taula. " + ex.Message, ex);
            }
        }

        public bool AssignarTaula(int taulaId)
        {
            try
            {
                var taula = _context.Taules.FirstOrDefault(x => x.id == taulaId);
                if (taula != null && taula.asignada == false)
                {
                    taula.asignada = true;
                    _context.Taules.Update(taula);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al assignar la taula. " + ex.Message, ex);
            }
        }

        public bool AlliberarTaula(int taulaId)
        {
            try
            {
                var taula = _context.Taules.FirstOrDefault(x => x.id == taulaId);
                if (taula != null && taula.asignada == true)
                {
                    taula.asignada = false;
                    _context.Taules.Update(taula);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al alliberar la taula. " + ex.Message, ex);
            }
        }
    }
}
