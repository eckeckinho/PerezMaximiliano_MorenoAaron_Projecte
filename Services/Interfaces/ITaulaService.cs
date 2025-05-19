using Entitats.HorariClasses;
using Entitats.TaulaClasses;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ITaulaService
    {
        List<Taula> GetTaules();
        List<int> GetCapacitatsDisponibles();
        List<Taula> GetTaulesDisponibles(DateTime data, Horari franja);
        int? GetAforamentActual();
        int GetAforamentMaxim();
        bool DeleteTaules(List<Taula> taulesSeleccionades);
        bool AddTaula(int comensalsTaula);
        bool UpdateTaula(Taula taulaSeleccionada);
    }
}
