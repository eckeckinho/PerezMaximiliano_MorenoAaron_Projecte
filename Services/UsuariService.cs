using Data;
using Entitats.AuthClasses;
using Entitats.RestaurantClasses;
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
            // Obtener los IDs de las taules que pertenecen al restaurant actual
            var idTaulesDelRestaurant = _context.Taules .Where(t => t.restaurantId == _restaurantActual.id).Select(t => t.id).ToList();

            // Obtener los IDs de usuaris que han hecho una reserva en alguna de esas taules
            var idsUsuarisAmbReserva = _context.Reservas.Where(r => idTaulesDelRestaurant.Contains(r.taulaid)).Select(r => r.usuariId).Distinct().ToList();

            // Devolver la lista de usuaris ordenada por nom y cognoms
            var usuarisAmbReserva = _context.Usuaris.Where(u => idsUsuarisAmbReserva.Contains(u.id)).OrderBy(u => u.nom).ThenBy(u => u.cognoms).ToList();

            return usuarisAmbReserva;
        }
    }
}
