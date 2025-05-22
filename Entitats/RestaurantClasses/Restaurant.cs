using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entitats.RestaurantClasses
{
    public class Restaurant
    {
        public int id { get; set; }
        public string nomCompte { get; set; }
        public string nomRestaurant { get; set; }
        public string descripcio { get; set; }
        public string pais { get; set; }
        public string ciutat { get; set; }
        public string codiPostal { get; set; }
        public string carrer { get; set; }
        public string telefon { get; set; }
        public string correu { get; set; }
        public string paginaWeb { get; set; }
        public byte[] logo { get; set; }
        public byte[] imatgeRestaurant { get; set; }
        public int aforament { get; set; }
        public decimal? valoraciomedia { get; set; }
        public int tipusCuinaId { get; set; }
        public int tipusPreuId { get; set; }
        public string contrasenyaCompte { get; set; }
    }
}
