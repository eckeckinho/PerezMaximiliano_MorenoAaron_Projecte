﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitats.AuthClasses
{
    public class Usuari
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string cognoms { get; set; }
        public string correu { get; set; }
        public string contrasenya { get; set; }
        public string pais { get; set; }
        public string telefon { get; set; }

        public override string ToString()
        {
            return $"{nom} {cognoms}";
        }
    }

    public class LoginReq
    {
        public string correu { get; set; }
        public string contrasenya { get; set; }
    }

    public class ContrasenyaRequest
    {
        public int idUsuari { get; set; }
        public string contrasenya { get; set; }
    }
}
