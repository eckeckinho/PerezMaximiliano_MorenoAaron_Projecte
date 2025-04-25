using Entitats.ReservaClasses;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IReservaService
    {
        Task<List<Reserva>> GetReservesRestaurantAsync(int idEstat, DateTime desde, DateTime hasta);
        List<Reserva> GetReservesRestaurant(int idEstat, DateTime desde, DateTime hasta);
        bool FinalitzarReserves(List<Reserva> reservesSeleccionades);
        bool CancelarReserves(List<Reserva> reservesSeleccionades);
    }
}
