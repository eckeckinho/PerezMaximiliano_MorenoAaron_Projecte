using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitats.Auth
{
    public class Usuari
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string cognoms { get; set; }
        public string correu { get; set; }
        public string contrasenya { get; set; }
        public string pais { get; set; }
        public string? telefon { get; set; }
    }
}
