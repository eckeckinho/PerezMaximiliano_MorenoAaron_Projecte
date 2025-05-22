using Data;
using Entitats.HorariClasses;
using Entitats.RestaurantClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class HorariService : IHorariService
    {
        private readonly DBContext _context;
        private readonly Restaurant _restaurantActual;

        public HorariService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public bool SetHoraris(List<Horari> horarisSetmana)
        {
            try
            {
                int restaurantId = _restaurantActual.id;

                // Eliminar todos los horarios del restaurante
                var horarisExistents = _context.Horaris.Where(h => h.restaurantid == restaurantId).ToList();

                if (horarisExistents.Any())
                {
                    _context.Horaris.RemoveRange(horarisExistents);
                }

                // Asignar ID del restaurante a cada nuevo horario
                foreach (var h in horarisSetmana)
                {
                    h.restaurantid = restaurantId;
                }

                // Insertar los nuevos horarios
                _context.Horaris.AddRange(horarisSetmana);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al configurar tots els horaris. " + ex.Message, ex);
            }
        }

        public List<Horari> GetHorarisDia(int dia)
        {
            try
            {
                // Recoger las franjas horarias del restaurante para el día específico
                var horaris = _context.Horaris.Where(h => h.restaurantid == _restaurantActual.id && h.dia == dia).OrderBy(x=>x.hora_inici).ToList();

                return horaris;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al carregar els horaris. " + ex.Message, ex);
            }
        }

        public List<Horari> GetHorarisDia(DateTime data)
        {
            try
            {
                // Pasar el día de la semana a un número entre 1 y 7 (1 = Lunes, 7 = Domingo)
                int diaSetmana = ((int)data.DayOfWeek + 6) % 7 + 1;

                // Recoger las franjas horarias del restaurante para el día específico
                var horaris = _context.Horaris.Where(h => h.restaurantid == _restaurantActual.id && h.dia == diaSetmana).ToList();

                return horaris;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al carregar els horaris. " + ex.Message, ex);
            }
        }

        public bool AddHorariExcepcions(HorariExcepcions horariExcepcions)
        {
            try
            {
                horariExcepcions.restaurantid = _restaurantActual.id;
                var dataInici = horariExcepcions.data_inici.Date;
                var dataFinal = horariExcepcions.data_final.Date;

                // Buscar intervalos que se solapen
                var solapats = _context.HorarisExcepcions.Where(h => dataInici <= h.data_final.Date && dataFinal >= h.data_inici.Date).ToList();

                if (solapats.Any())
                {
                    // Eliminar los anteriores
                    _context.HorarisExcepcions.RemoveRange(solapats);
                }

                // Insertar el nuevo intervalo tal cual
                _context.HorarisExcepcions.Add(horariExcepcions);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al afegir/reemplaçar dies festius. " + ex.Message, ex);
            }
        }

        public List<int> GetDiesAmbHorari()
        {
            try
            {
                // Devuelve los dias de la semana (1-7) en los que hay franjas definidas para el restaurante en cuestion
                var dies = _context.Horaris.Where(h => h.restaurantid == _restaurantActual.id).Select(h => h.dia).Distinct().ToList();

                return dies;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtenir els dies amb horari definit. " + ex.Message, ex);
            }
        }

        public List<HorariExcepcions> GetHorariExcepcions()
        {
            try
            {
                // Devuelve las excepciones / festivos de horario del restaurante en cuestion (aunque tengan franja cuenta como no laborable ya que prevalece sobre las franjas).
                var excepcions = _context.HorarisExcepcions.Where(h => h.restaurantid == _restaurantActual.id).ToList();

                return excepcions;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtenir les excepcions d'horari. " + ex.Message, ex);
            }
        }

        public bool DeleteHorariExcepcions(HorariExcepcions horariExcepcions)
        {
            try
            {
                var dataInici = horariExcepcions.data_inici.Date;
                var dataFinal = horariExcepcions.data_final.Date;

                var excepcionsAEliminar = _context.HorarisExcepcions.Where(h => h.restaurantid == _restaurantActual.id && dataInici <= h.data_final.Date && dataFinal >= h.data_inici.Date)
                    .ToList();

                if (excepcionsAEliminar.Any())
                {
                    _context.HorarisExcepcions.RemoveRange(excepcionsAEliminar);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar excepcions d'horari. " + ex.Message, ex);
            }
        }
    }
}
