using Data;
using Entitats.HorariClasses;
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
                var horarisExistents = _context.Horaris
                    .Where(h => h.restaurantid == restaurantId)
                    .ToList();

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
                var horaris = _context.Horaris
                    .Where(h => h.restaurantid == _restaurantActual.id && h.dia == dia)
                    .ToList();

                return horaris;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los horarios. " + ex.Message, ex);
            }
        }

        public List<Horari> GetHorarisDia(DateTime data)
        {
            try
            {
                int diaSetmana = ((int)data.DayOfWeek + 6) % 7 + 1;

                // Recoger las franjas horarias del restaurante para el día específico
                var horaris = _context.Horaris
                    .Where(h => h.restaurantid == _restaurantActual.id && h.dia == diaSetmana)
                    .ToList();

                return horaris;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los horarios. " + ex.Message, ex);
            }
        }
    }
}
