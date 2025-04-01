using PerezMaximiliano_MorenoAaron_Projecte;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerezMaximiliano_MorenoAaron_Projecte
{
    public class EntrarController
    {
        IniciarSessioForm f1 = new IniciarSessioForm();

        public EntrarController() {

            SetListeners();
            f1.ShowDialog();
        
        }

        private void SetListeners()
        {
            f1.button_entrar.Click += Button_entrar_Click;
            f1.button_regisrest.Click += Button_regisrest_Click;
        }

        private void Button_regisrest_Click(object sender, EventArgs e)
        {
            RegistrarController r = new RegistrarController();
        }

        private void Button_entrar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
