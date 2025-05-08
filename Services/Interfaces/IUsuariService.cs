using Entitats.AuthClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUsuariService
    {
        List<Usuari> GetUsuaris();
    }
}
