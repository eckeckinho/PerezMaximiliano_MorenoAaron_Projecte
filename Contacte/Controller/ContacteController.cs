using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacte.Controller
{
    public class ContacteController
    {
        ContacteForm f;
        public ContacteController() 
        {
            f = new ContacteForm();
            LoadData();
        }

        private void LoadData()
        {
            f.ShowDialog();
        }
    }
}
