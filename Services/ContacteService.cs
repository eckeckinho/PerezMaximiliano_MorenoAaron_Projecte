using Data;
using Entitats.AuthClasses;
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

        public List<MissatgesView> GetMissatgesUsuariRestaurant(string filtre, DateTime desde, DateTime hasta, string correuUsuari, bool tots)
        {
            filtre = filtre?.Trim().ToLower();

            var missatges = _context.MissatgesView
                .AsNoTracking()
                .Where(x => x.restaurantId == _restaurantActual.id)
                .Where(x => x.dataMissatge >= desde.Date && x.dataMissatge < hasta.Date.AddDays(1));

            if (!string.IsNullOrEmpty(correuUsuari) && correuUsuari != "Tots")
                missatges = missatges.Where(x => x.correu.ToLower() == correuUsuari.ToLower());

            if (!string.IsNullOrEmpty(filtre))
                missatges = missatges.Where(x => x.assumpte.ToLower().Trim().Contains(filtre));

            if (!tots)
                missatges = missatges.Where(x => !x.llegit);

            return missatges.OrderByDescending(x => x.dataMissatge).ToList();
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

        public List<Usuari> GetUsuarisAmbMissatges()
        {
            var usuaris = _context.Usuaris.ToList();

            var missatges = _context.MissatgesUsuaris.Where(m => m.restaurantId == _restaurantActual.id).ToList();

            var usuariIdsAmbMissatges = missatges.Select(m => m.usuariId).Distinct();

            var usuarisAmbMissatges = usuaris.Where(u => usuariIdsAmbMissatges.Contains(u.id)).ToList();

            return usuarisAmbMissatges;
        }

        public (int llegits, int noLlegits) ComptarMissatgesLlegitsINoLlegits(string filtre, DateTime desde, DateTime hasta, string correuUsuari, bool tots)
        {
            filtre = filtre?.Trim().ToLower();

            var missatges = _context.MissatgesView
                .AsNoTracking()
                .Where(x => x.restaurantId == _restaurantActual.id)
                .Where(x => x.dataMissatge >= desde.Date && x.dataMissatge < hasta.Date.AddDays(1));

            if (!string.IsNullOrEmpty(correuUsuari) && correuUsuari != "Tots") missatges = missatges.Where(x => x.correu.ToLower() == correuUsuari.ToLower());

            if (!string.IsNullOrEmpty(filtre)) missatges = missatges.Where(x => x.assumpte.ToLower().Trim().Contains(filtre));

            if (!tots) missatges = missatges.Where(x => !x.llegit);

            var llistaMissatges = missatges.ToList();

            int llegits = llistaMissatges.Count(m => m.llegit);
            int noLlegits = llistaMissatges.Count(m => !m.llegit);

            return (llegits, noLlegits);
        }
    }
}
