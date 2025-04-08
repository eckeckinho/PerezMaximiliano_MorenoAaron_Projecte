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
        List<Reserva> GetReservesRestaurant(int idEstat, DateTime desde, DateTime hasta);
        bool FinalitzarReserves(List<Reserva> reservesSeleccionades);
        bool CancelarReserves(List<Reserva> reservesSeleccionades);
    }
}
