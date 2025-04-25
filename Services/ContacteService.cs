using Data;
using Entitats.ContacteClasses;
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
    public class ContacteService : IContacteService
    {
        private readonly DBContext _context;
        private readonly Restaurant _restaurantActual;

        public ContacteService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public List<MissatgesView> GetMissatgesUsuariRestaurant(string filtre, DateTime desde, DateTime hasta)
        {
            filtre = filtre?.Trim().ToLower();

            var missatges = _context.MissatgesView
                .Where(x => x.restaurantId == _restaurantActual.id)
                .Where(x => x.dataMissatge >= desde.Date && x.dataMissatge < hasta.Date.AddDays(1));

            if (!string.IsNullOrEmpty(filtre))
            {
                missatges = missatges.Where(x =>
                    (x.correu.ToLower().Trim().Contains(filtre)) ||
                    (x.assumpte.ToLower().Trim().Contains(filtre)) ||
                    (x.missatge.ToLower().Trim().Contains(filtre))
                );
            }

            return missatges.ToList();
        }
    }
}
