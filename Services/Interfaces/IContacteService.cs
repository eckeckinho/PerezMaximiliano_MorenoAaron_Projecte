using Entitats.AuthClasses;
using Entitats.ContacteClasses;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IContacteService
    {
        List<MissatgesView> GetMissatgesUsuariRestaurant(string filtre, DateTime desde, DateTime hasta, string correuUsuari, bool tots);
        List<Usuari> GetUsuarisAmbMissatges();
        (int llegits, int noLlegits) ComptarMissatgesLlegitsINoLlegits(string filtre, DateTime desde, DateTime hasta, string correuUsuari, bool tots);
        void MarcarMissatgeLlegit(MissatgesView missatgeSeleccionat);

    }
}
