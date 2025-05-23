using Entitats.AuthClasses;
using Entitats.ReservaClasses;
using Entitats.TaulaClasses;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IReservaService
    {
        List<Reserva> GetReservesRestaurant(int idEstat, DateTime desde, DateTime hasta, Usuari usuari);
        List<Reserva> GetReservesDia(DateTime dia);
        Taula GetTaulaDisponible(int? numComensals, DateTime data, TimeSpan? novaHora, int durada, int? reservaid);
        Usuari GetUsuariReserva(int usuariId);
        int GetCountReservesByEstatUsuari(int estatId, int usuariId, DateTime desde, DateTime hasta);
        bool CanviarEstatReserva(List<Reserva> reservesSeleccionades, int nouEstat);
        bool AfegirReserva(Reserva newReserva);
        bool ActualitzarReserva(Reserva reserva);
    }
}
