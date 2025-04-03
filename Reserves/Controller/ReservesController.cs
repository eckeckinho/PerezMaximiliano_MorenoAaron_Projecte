using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserves.Controller
{
    public class ReservesController
    {
        ReservesForm f;
        public ReservesController() 
        { 
            f = new ReservesForm();
            LoadData();
        }

        private void LoadData()
        {
            f.ShowDialog();
        }
    }
}
