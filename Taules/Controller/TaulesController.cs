using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taules.Controller
{
    public class TaulesController
    {
        TaulesForm f;
        public TaulesController()
        {
            f = new TaulesForm();
            LoadData();
        }

        private void LoadData()
        {
            f.ShowDialog();
        }
    }
}
