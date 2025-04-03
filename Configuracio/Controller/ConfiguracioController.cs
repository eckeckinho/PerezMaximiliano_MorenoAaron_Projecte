using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuracio.Controller
{
    public class ConfiguracioController
    {
        ConfiguracioForm f;
        public ConfiguracioController() 
        {
            f = new ConfiguracioForm();
            LoadData();
        }

        private void LoadData()
        {
            f.ShowDialog();
        }
    }
}
