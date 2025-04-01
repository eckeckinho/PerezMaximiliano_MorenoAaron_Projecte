using PerezMaximiliano_MorenoAaron_Projecte.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerezMaximiliano_MorenoAaron_Projecte.Controller
{
    public class RegistrarController
    {

        RegistrarRestaurant r = new RegistrarRestaurant();
        public RegistrarController() {

            SetListeners();
            r.ShowDialog();
        
        }

        private void SetListeners()
        {
            r.button_logo.Click += Button_logo_Click;
        }

        private void Button_logo_Click(object sender, EventArgs e)
        {

        }
    }
}
