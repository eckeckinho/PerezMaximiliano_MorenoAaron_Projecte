using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITaulaService
    {
        List<Taula> GetTaules();
        int GetAforamentActual();
        int GetAforamentMaxim();
        bool DeleteTaules(List<Taula> taulesSeleccionades);
    }
}
