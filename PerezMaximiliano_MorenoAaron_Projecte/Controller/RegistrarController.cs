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
        
                
            r.ShowDialog();
        
        }    

    }
}
