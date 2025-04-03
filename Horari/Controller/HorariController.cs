using Horari.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horari.Controller
{
    public class HorariController
    {
        HorariForm f;
        public HorariController() 
        { 
            f = new HorariForm();
            LoadData();
        }

        private void LoadData()
        {
            f.ShowDialog();
        }
    }
}
