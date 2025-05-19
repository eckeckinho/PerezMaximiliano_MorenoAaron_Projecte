using Entitats.AuthClasses;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUsuariService
    {
        List<Usuari> GetUsuaris();
    }
}
