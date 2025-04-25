using Entitats.ReservaClasses;
using Entitats.TaulaClasses;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taules.View;

namespace Contacte.Controller
{
    public class HorariController
    {
        private MenuForm fm;
        private readonly IHorariService _horariService;

        public HorariController(IHorariService horariService)
        {
            _horariService = horariService;
        }

        public void Inicialitzar()
        {
            SetListeners();
            LoadData();
        }

        private void SetListeners()
        {

        }

        private void LoadData()
        {
        }

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }
    }
}
