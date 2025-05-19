using Entitats.ContacteClasses;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IContacteService
    {
        List<MissatgesView> GetMissatgesUsuariRestaurant(string filtre, DateTime desde, DateTime hasta);
        void MarcarMissatgeLlegit(MissatgesView missatgeSeleccionat);
    }
}
