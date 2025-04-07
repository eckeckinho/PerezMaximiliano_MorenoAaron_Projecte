using Entitats.ReservaClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IReservaService
    {
        List<Reserva> GetReservesRestaurant(int idEstat);
    }
}
