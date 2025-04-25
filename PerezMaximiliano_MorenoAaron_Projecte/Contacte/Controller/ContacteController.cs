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
    public class ContacteController
    {
        private MenuForm fm;
        private readonly IContacteService _contacteService;

        public ContacteController(IContacteService contacteService)
        {
            _contacteService = contacteService;
        }

        public void Inicialitzar()
        {   
            SetListeners();
            LoadData();
        }

        private void SetListeners()
        {
            fm.buttonContacte_obrir.Click += Button_obrir_Click;
            fm.dateTimePickerContacte_desde.ValueChanged += DateTimePicker_desde_ValueChanged;
            fm.dateTimePickerContacte_hasta.ValueChanged += DateTimePicker_hasta_ValueChanged;
            fm.textBoxContacte_filtre.TextChanged += TextBox_filtre_TextChanged;
            //fm.dataGridViewContacte_missatges.SelectionChanged += DataGridView_missatges_SelectionChanged;
        }

        private void TextBox_filtre_TextChanged(object sender, EventArgs e)
        {
            LoadDataDgvMissatges();
        }

        private void DateTimePicker_hasta_ValueChanged(object sender, EventArgs e)
        {
            LoadDataDgvMissatges();
        }

        private void DateTimePicker_desde_ValueChanged(object sender, EventArgs e)
        {
            LoadDataDgvMissatges();
        }

        private void Button_obrir_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadData()
        {
            LoadDataDgvMissatges();
        }


        private void LoadDataDgvMissatges()
        {
            var filtre = fm.textBoxContacte_filtre.Text;
            var desde = fm.dateTimePickerContacte_desde.Value;
            var hasta = fm.dateTimePickerContacte_hasta.Value;
            fm.dataGridViewContacte_missatges.DataSource = _contacteService.GetMissatgesUsuariRestaurant(filtre, desde, hasta);
        }

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }
    }
}
