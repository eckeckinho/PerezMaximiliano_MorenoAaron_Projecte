using Entitats.PlatClasses;
using Entitats.TaulaClasses;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IPlatService
    {
        List<Plat> GetPlats(int tipusPlatId);
        int GetCountPlatsByTipus(int tipusId);
        bool DeletePlats(List<Plat> platsSeleccionats);
        bool AddPlat(Plat platSeleccionat);
        bool UpdatePlat(Plat platSeleccionat);
    }
}
