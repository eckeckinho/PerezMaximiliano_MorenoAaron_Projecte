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

        public List<Reserva> GetReservesRestaurant(int idEstat)
        {
            // Implementar async en caso necesario (?). Devolver todas las reservas o solo las P segun lo seleccionado en combobox 'Totes' por ejemplo (?). Pensarlo.

            var idTaulesRestaurant = _context.Taules.Where(x => x.restaurantId == _restaurantActual.id).Select(x => x.id).ToList();

            if (idTaulesRestaurant.Count > 0)
            {
                var reservesRestaurant =  _context.Reservas.Where(x => idTaulesRestaurant.Contains(x.taulaid) && x.estatid == idEstat).OrderByDescending(x => x.id).ToList();

                return reservesRestaurant;
            }

            return new List<Reserva>();
        }
    }
}
