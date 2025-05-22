using Data;
using Entitats.AuthClasses;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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
                if (newReserva == null) return false;

                newReserva.restaurantid = _restaurantActual.id; 

                _context.Reservas.Add(newReserva);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al afegir la reserva. " + ex.Message, ex);
            }
        }


        public bool CanviarEstatReserva(List<Reserva> reservesSeleccionades, int nouEstat)
        {
            if (reservesSeleccionades == null || reservesSeleccionades.Count == 0) return false;

            if (nouEstat == (int)EstatReserva.EnProces)
            {
                foreach (var reserva in reservesSeleccionades)
                {
                    if (HiHaSolapamentReserva(reserva))
                    {
                        // No se puede cambiar a EnProces porque hay solapamiento
                        return false;
                    }
                }
            }

            foreach (Reserva reserva in reservesSeleccionades)
            {
                reserva.estatid = nouEstat;
                _context.Reservas.Update(reserva);
            }

            int changes = _context.SaveChanges();

            return changes > 0;
        }


        public List<Reserva> GetReservesRestaurant(int idEstat, DateTime desde, DateTime hasta, Usuari usuari)
        {
            var idTaulesRestaurant = _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).Select(x => x.id).ToList();

            if (idTaulesRestaurant.Count == 0) return new List<Reserva>();

            var query = _context.Reservas
                .Where(x => idTaulesRestaurant.Contains(x.taulaid))
                .Where(x => x.estatid == idEstat)
                .Where(x => x.datareserva >= desde.Date && x.datareserva < hasta.Date.AddDays(1));

            if (usuari != null && usuari.id != -1) query = query.Where(x => x.usuariId == usuari.id);

            return query.OrderByDescending(x => x.id).ToList();
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

        public List<Reserva> GetReservesDia(DateTime dia)
        {
            var idTaulesRestaurant = _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).Select(x => x.id).ToList();

            if (idTaulesRestaurant.Count == 0) return new List<Reserva>();

            // Devuelve las reservas pendientes del restaurante filtrados por día
            var reservasDelDia = _context.Reservas.Where(x => idTaulesRestaurant.Contains(x.taulaid)).Where(x => x.datareserva.Date == dia.Date)
                .Where(x => x.estatid == (int)EstatReserva.EnProces).OrderBy(x => x.datareserva).ToList();

            return reservasDelDia;
        }

        public Taula GetTaulaDisponible(int? numComensals, DateTime data, TimeSpan? novaHora, int novaDurada)
        {
            // Coger las mesas del rest por numero de comensales
            var taules = _context.Taules.Where(t => t.numComensals == numComensals && t.restaurantId == _restaurantActual.id).ToList();

            // Coger las reservas del dia pendientes
            var reservesDelDia = _context.Reservas.Where(r => r.datareserva.Date == data.Date && (r.estatid == (int)EstatReserva.EnProces)).ToList();

            foreach (var taula in taules)
            {
                // Comprobar si hay alguna mesa libre para esa hora
                bool solapada = reservesDelDia.Any(r => r.taulaid == taula.id && SolapaAmbReservaExistente(novaHora, novaDurada, r.hora, r.durada));

                // Devuelve la primera mesa disponible que no esté ocupada en el rango de horas
                if (!solapada)
                {
                    return taula;
                }
            }

            return null; 
        }

        private bool SolapaAmbReservaExistente(TimeSpan? novaHora, int novaDuracio, TimeSpan? horaExistente, int duracioExistente)
        {
            if (!novaHora.HasValue || !horaExistente.HasValue) return false;

            TimeSpan fiNova = novaHora.Value.Add(TimeSpan.FromMinutes(novaDuracio)); // Calcular la hora de fin de la reserva nueva
            TimeSpan fiExistente = horaExistente.Value.Add(TimeSpan.FromMinutes(duracioExistente)); // Calcular la hora de fin de la reserva existente 

            // Comprobar si la nueva reserva empieza antes de que termine la reserva existente, y si la reserva existente empieza antes de que termine la nueva reserva

            if (novaHora.Value < fiExistente && horaExistente.Value < fiNova)
            {
                return true; // Si ambas coinciden (solapadas)
            }
            else
            {
                return false;
            }
        }

        private bool HiHaSolapamentReserva(Reserva reserva)
        {
            var reservesEnProces = _context.Reservas
                .Where(r => r.estatid == (int)EstatReserva.EnProces
                            && r.taulaid == reserva.taulaid
                            && r.datareserva == reserva.datareserva
                            && r.id != reserva.id)
                .ToList();

            foreach (var rExist in reservesEnProces)
            {
                if (SolapaAmbReservaExistente(reserva.hora, reserva.durada, rExist.hora, rExist.durada))
                {
                    return true; // Hay solapamiento
                }
            }

            return false; // No hay solapamiento
        }


        public bool ActualitzarReserva(Reserva reserva)
        {
            try
            {
                if (reserva == null) return false;

                var reservaExistente = _context.Reservas.Find(reserva.id);

                if (reservaExistente == null) return false;

                reservaExistente.datareserva = reserva.datareserva;
                reservaExistente.numcomensals = reserva.numcomensals;
                reservaExistente.taulaid = reserva.taulaid;
                reservaExistente.durada = reserva.durada;
                reservaExistente.hora = reserva.hora;
                reservaExistente.usuariId = reserva.usuariId;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualitzar la reserva. " + ex.Message, ex);
            }
        }

        public int GetCountReservesByEstatUsuari(int estatId, int usuariId, DateTime desde, DateTime hasta)
        {
            var idTaulesRestaurant = _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).Select(x => x.id);

            var reserves = _context.Reservas.Where(r => idTaulesRestaurant.Contains(r.taulaid)).Where(r => r.estatid == estatId).Where(r => r.datareserva >= desde.Date && r.datareserva < hasta.Date.AddDays(1));

            if (usuariId != -1) reserves = reserves.Where(r => r.usuariId == usuariId);

            return reserves.Count();
        }
    }
}
