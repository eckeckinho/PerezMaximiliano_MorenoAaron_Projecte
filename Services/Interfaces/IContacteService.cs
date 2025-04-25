using Entitats.ContacteClasses;
using Entitats.ReservaClasses;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IContacteService
    {
        List<MissatgesView> GetMissatgesUsuariRestaurant(string filtre, DateTime desde, DateTime hasta);
    }
}
