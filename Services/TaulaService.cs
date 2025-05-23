using Data;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

            // Primer eliminem les reserves relaconades a les taules seleccionades i finalment eliminem les taules
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

            if (changes > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int? GetAforamentActual()
        {
            var avui = DateTime.Today;
            var ara = DateTime.Now;

            var taules = _context.Taules.Where(t => t.restaurantId == _restaurantActual.id).ToList();
            var taulesIds = taules.Select(t => t.id).ToList();

            // Reserves d'avui pendents de cada taula del restaurant
            var reserves = _context.Reservas.Where(r => taulesIds.Contains(r.taulaid) && r.datareserva == avui && r.estatid == (int)EstatReserva.EnProces).ToList();

            // IDs de taules que tenen una reserva activa en aquest moment
            var taulesOcupadesIds = reserves
                .Where(r =>
                    r.hora.HasValue &&
                    ara >= avui.Add(r.hora.Value) &&
                    ara < avui.Add(r.hora.Value).AddMinutes(r.durada)
                )
                .Select(r => r.taulaid)
                .Distinct()
                .ToList();

            // Actualitzem l'estat 'ocupada' de totes les taules del restaurant
            foreach (var taula in taules)
            {
                // Si el ID de la taula está en la lista de ocupadas, marcamos la taula como ocupada
                if (taulesOcupadesIds.Contains(taula.id))
                {
                    taula.ocupada = true;
                }
                else
                {
                    taula.ocupada = false;
                }
            }

            _context.SaveChanges();

            var aforamentActual = reserves.Where(r =>
                r.hora.HasValue && // La reserva tiene hora asignada.
                ara >= avui.Add(r.hora.Value) && // La hora actual es igual o posterior a la hrora de inicio de la reserva.
                ara < avui.Add(r.hora.Value).AddMinutes(r.durada) // La hora actual es anterior a la hora final de la reserva 
            )
            .Sum(r => r.numcomensals);

            // Después de marcar las mesas ocupadas, devolvemos el aforo actual
            return aforamentActual;
        }

        public int GetAforamentMaxim()
        {
            return _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).Sum(x => x.numComensals);
        }

        public List<Taula> GetTaules()
        {
            return _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).OrderBy(x => x.numComensals).ToList();
        }

        public List<int> GetCapacitatsDisponibles()
        {
            // Obtenim les capacitats de les taules del restaurant actual (amb distinct per evitar duplicats en cas de que hi hagi més d'una taula amb la mateixa capacitat).
            return _context.Taules.Where(t => t.restaurantId == _restaurantActual.id).Select(t => t.numComensals).Distinct().OrderBy(c => c).ToList();
        }

        public bool AddTaula(int comensalsTaula)
        {
            try
            {
                Taula newTaula = new Taula()
                {
                    numComensals = comensalsTaula,
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
            try
            {
                if (taulaSeleccionada == null) return false;

                _context.Taules.Update(taulaSeleccionada);

                int changes = _context.SaveChanges();

                if (changes > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar taula. " + ex.Message, ex);
            }
        }

        public List<CapacitatTaulaCombo> GetCapacitatsCombo()
        {
            var capacitats = _context.Taules.Where(t => t.restaurantId == _restaurantActual.id).GroupBy(t => t.numComensals)
                .Select(g => new CapacitatTaulaCombo
                {
                    capacitat = g.Key,
                    quantitat = g.Count()
                }).OrderBy(c => c.capacitat).ToList();

            capacitats.Insert(0, new CapacitatTaulaCombo
            {
                capacitat = -1,
                quantitat = capacitats.Sum(c => c.quantitat)
            });

            return capacitats;
        }
    }
}
