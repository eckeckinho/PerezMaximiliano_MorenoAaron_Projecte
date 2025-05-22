using Data;
using Entitats.AuthClasses;
using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UsuariService : IUsuariService
    {
        private readonly DBContext _context;
        private readonly Restaurant _restaurantActual;

        public UsuariService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public List<Usuari> GetUsuaris()
        {
            return _context.Usuaris.OrderBy(u => u.correu).ToList();
        }

        public List<Usuari> GetUsuarisAmbReserva()
        {
            var idTaulesRestaurant = _context.Taules.Where(t => t.restaurantId == _restaurantActual.id).Select(t => t.id).ToList();

            var usuarisAmbReserva = _context.Reservas.Where(r => idTaulesRestaurant.Contains(r.taulaid)).Select(r => r.usuariId).Distinct().ToList();

            return _context.Usuaris.Where(u => usuarisAmbReserva.Contains(u.id)).OrderBy(u => u.nom).ThenBy(u => u.cognoms).ToList();
        }
    }
}
