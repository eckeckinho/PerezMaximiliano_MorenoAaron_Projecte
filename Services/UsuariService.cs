using Data;
using Entitats.AuthClasses;
using Entitats.RestaurantClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return _context.Usuaris.OrderBy(u => u.correu).ThenBy(u => u.nom).ToList();
        }
    }
}
