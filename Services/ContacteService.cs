using Data;
using Entitats.ContacteClasses;
using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
                .AsNoTracking()  // Al ser una vista uso AsNoTracking para que coja los datos mas recientes y no los del caché, sino no actualiza las rows de la vista.
                .Where(x => x.restaurantId == _restaurantActual.id)
                .Where(x => x.dataMissatge >= desde.Date && x.dataMissatge < hasta.Date.AddDays(1));


            if (!string.IsNullOrEmpty(filtre))
            {
                missatges = missatges.Where(x =>
                    (x.correu.ToLower().Trim().Contains(filtre)) ||
                    (x.assumpte.ToLower().Trim().Contains(filtre))
                );
            }

            return missatges.ToList();
        }

        public void MarcarMissatgeLlegit(MissatgesView missatgeSeleccionat)
        {
            try
            {
                var missatge = _context.MissatgesUsuaris.FirstOrDefault(x => x.id == missatgeSeleccionat.id && x.restaurantId == _restaurantActual.id);

                if (missatge != null)
                {
                    missatge.llegit = true;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al marcar el missatge com a llegit. " + ex.Message, ex);
            }
        }
    }
}
