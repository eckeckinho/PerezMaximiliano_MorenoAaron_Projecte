using Entitats.RestaurantClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITipusService
    {
        Task<List<TipusCuina>> GetTipusCuines();
        Task<List<TipusPreu>> GetTipusPreus();
    }
}
