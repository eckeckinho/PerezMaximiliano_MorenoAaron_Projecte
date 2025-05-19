using Entitats.PlatClasses;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ITipusService
    {
        List<TipusCuina> GetTipusCuines();
        List<TipusPreu> GetTipusPreus();
        List<TipusEstat> GetTipusEstats();
        List<TipusPlat> GetTipusPlats();
    }
}
