using Data;
using Entitats.RestaurantClasses;
using Services.Interfaces;
using System;
using System.Linq;

namespace Services
{
    public class ConfiguracioService : IConfiguracioService
    {
        private readonly DBContext _context;
        private readonly Restaurant _restaurantActual;

        public ConfiguracioService(DBContext context, IRestaurantContext restContext)
        {
            _context = context;
            _restaurantActual = restContext.restaurantActual;
        }

        public bool CanviarContrasenyaRestaurant(string novaContrasenya)
        {
            var restaurant = _context.Restaurants.Where(x => x.nomCompte == _restaurantActual.nomCompte).FirstOrDefault();

            if (restaurant != null)
            {
                _restaurantActual.contrasenyaCompte = BCrypt.Net.BCrypt.HashPassword(novaContrasenya);
                _context.Restaurants.Update(_restaurantActual); 
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }   

        public Restaurant GetRestaurantConfig()
        {
            return _restaurantActual;
        }

        public bool UpdateRestaurant(Restaurant updateRestaurant)
        {
            try
            {
                var restaurantAct = _context.Restaurants.Where(x => x.nomCompte == _restaurantActual.nomCompte).FirstOrDefault();

                var nomUsat = _context.Restaurants.Any(x => x.nomCompte.Equals(updateRestaurant.nomCompte) && x.id != restaurantAct.id);

                if (nomUsat) return false;

                restaurantAct.nomCompte = updateRestaurant.nomCompte;
                restaurantAct.nomRestaurant = updateRestaurant.nomRestaurant;
                restaurantAct.pais = updateRestaurant.pais;
                restaurantAct.ciutat = updateRestaurant.ciutat;
                restaurantAct.codiPostal = updateRestaurant.codiPostal;
                restaurantAct.carrer = updateRestaurant.carrer;
                restaurantAct.telefon = updateRestaurant.telefon;
                restaurantAct.correu = updateRestaurant.correu;
                restaurantAct.aforament = updateRestaurant.aforament;
                restaurantAct.tipusCuinaId = updateRestaurant.tipusCuinaId;
                restaurantAct.tipusPreuId = updateRestaurant.tipusPreuId;
                restaurantAct.descripcio = updateRestaurant.descripcio;
                restaurantAct.descripcio = updateRestaurant.descripcio;
                restaurantAct.paginaWeb = updateRestaurant.paginaWeb;
                restaurantAct.logo = updateRestaurant.logo;
                restaurantAct.imatgeRestaurant = updateRestaurant.imatgeRestaurant;

                _context.Restaurants.Update(restaurantAct);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualitzar el restaurant. " + ex.Message, ex);
            }
        }
    }
}

