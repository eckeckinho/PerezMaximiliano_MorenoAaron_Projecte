using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitats.ContacteClasses
{
    public class MissatgesUsuari
    {
        public int id { get; set; }
        public string assumpte { get; set; }
        public string missatge { get; set; }
        public DateTime? dataMissatge { get; set; }
        public int restaurantId { get; set; }
        public int usuariId { get; set; }
    }

    public class MissatgesView
    {
        public int id { get; set; }
        public string correu { get; set; }
        public string telefon { get; set; }
        public string nom { get; set; }
        public string cognoms { get; set; }
        public string assumpte { get; set; }
        public string missatge { get; set; }
        public DateTime? dataMissatge { get; set; }
        public int restaurantId { get; set; }
    }
}
