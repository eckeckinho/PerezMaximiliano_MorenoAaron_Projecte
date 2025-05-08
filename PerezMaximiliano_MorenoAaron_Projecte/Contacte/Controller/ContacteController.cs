using Entitats.ContacteClasses;
using Entitats.ReservaClasses;
using Entitats.TaulaClasses;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        ObrirMissatgeForm fo;
        private readonly IContacteService _contacteService;

        public ContacteController(IContacteService contacteService)
        {
            _contacteService = contacteService;
        }

        public void Inicialitzar()
        {
            if (fo == null)
            {
                fo = new ObrirMissatgeForm();
                SetListeners();
                LoadData();
            }
        }

        private void SetListeners()
        {
            fm.buttonContacte_obrir.Click += Button_obrir_Click;
            fm.dateTimePickerContacte_desde.ValueChanged += DateTimePicker_desde_ValueChanged;
            fm.dateTimePickerContacte_hasta.ValueChanged += DateTimePicker_hasta_ValueChanged;
            fm.textBoxContacte_filtre.TextChanged += TextBox_filtre_TextChanged;
            fm.dataGridViewContacte_missatges.CellFormatting += DataGridViewContacte_missatges_CellFormatting; 
        }

        private void DataGridViewContacte_missatges_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (fm.dataGridViewContacte_missatges.Columns[e.ColumnIndex].Name == "llegit")
            {
                bool llegit = Convert.ToBoolean(e.Value);

                DataGridViewRow row = fm.dataGridViewContacte_missatges.Rows[e.RowIndex];
                if (llegit)
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
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
            if (fm.dataGridViewContacte_missatges.SelectedRows.Count > 0)
            {
                var missatgeSeleccionat = fm.dataGridViewContacte_missatges.SelectedRows[0].DataBoundItem as MissatgesView;

                if (missatgeSeleccionat != null)
                {
                    fo.Text = $"Autor: {missatgeSeleccionat.correu} ({missatgeSeleccionat.nom} {missatgeSeleccionat.cognoms}) - Data: {missatgeSeleccionat.dataMissatge:dd/MM/yyyy HH:mm} - Telèfon: {missatgeSeleccionat.telefon}";
                    fo.multiLineContacte_missatge.Text = missatgeSeleccionat.missatge;
                    _contacteService.MarcarMissatgeLlegit(missatgeSeleccionat);
                    fo.ShowDialog();
                    LoadDataDgvMissatges();
                }
            }
        }

        private void LoadData()
        {      
            LoadDataDgvMissatges();
            fm.dataGridViewContacte_missatges.Columns["id"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["missatge"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["restaurantId"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["nom"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["cognoms"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["telefon"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["dataMissatge"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
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
