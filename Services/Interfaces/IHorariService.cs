using Entitats.HorariClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IHorariService
    {
        bool SetHoraris(List<Horari> horaris);
        List<Horari> GetHorarisDia(DateTime data);
        List<Horari> GetHorarisDia(int dia);

    }
}
