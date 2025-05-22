using Data;
using Entitats.PlatClasses;
using Entitats.RestaurantClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PlatService : IPlatService
    {
        private readonly DBContext _context;
        private readonly Restaurant _restaurantActual;

        public PlatService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public List<Plat> GetPlats(int tipusPlatId)
        {
            var plats = _context.Plats.Where(p => p.restaurantid == _restaurantActual.id);

            if (tipusPlatId != -1) plats = plats.Where(p => p.tipusPlatId == tipusPlatId);

            return plats.ToList();
        }

        public int GetCountPlatsByTipus(int tipusId)
        {
            return _context.Plats.Count(p => p.tipusPlatId == tipusId && p.restaurantid == _restaurantActual.id);
        }


        public bool AddPlat(Plat newPlat)
        {
            try
            {
                newPlat.restaurantid = _restaurantActual.id;
                _context.Plats.Add(newPlat);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al afegir plat. " + ex.Message, ex);
            }
        }

        public bool UpdatePlat(Plat platSeleccionat)
        {
            try
            {
                var plat = _context.Plats.Where(x => x.id == platSeleccionat.id && x.restaurantid == _restaurantActual.id).FirstOrDefault();

                if (plat == null) return false;

                plat.nom = platSeleccionat.nom;
                plat.descripcio = platSeleccionat.descripcio;
                plat.preu = platSeleccionat.preu;
                plat.tipusPlatId = platSeleccionat.tipusPlatId;
                plat.restaurantid = _restaurantActual.id;

                _context.Plats.Update(plat);
                int changes = _context.SaveChanges();

                if (changes > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar plat. " + ex.Message, ex);
            }
        }

        public bool DeletePlats(List<Plat> platsSeleccionats)
        {
            if (platsSeleccionats == null || platsSeleccionats.Count == 0) return false;

            foreach (Plat plat in platsSeleccionats)
            {
                _context.Plats.Remove(plat);
            }

            int changes = _context.SaveChanges();

            if (changes > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
