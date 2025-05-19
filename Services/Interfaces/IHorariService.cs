using Entitats.HorariClasses;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IHorariService
    {
        List<Horari> GetHorarisDia(DateTime data);
        List<Horari> GetHorarisDia(int dia);
        List<int> GetDiesAmbHorari();
        List<HorariExcepcions> GetHorariExcepcions();
        bool SetHoraris(List<Horari> horaris);
        bool AddHorariExcepcions(HorariExcepcions horariExcepcions);
        bool DeleteHorariExcepcions(HorariExcepcions horariExcepcions);
    }
}
