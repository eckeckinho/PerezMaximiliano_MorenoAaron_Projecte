using Entitats.AuthClasses;
using Entitats.ContacteClasses;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services.Interfaces;
using System;
using System.Drawing;
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
            LoadDataDgvMissatges();
        }

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }

        private void SetListeners()
        {
            fm.buttonContacte_obrir.Click += Button_obrir_Click;
            fm.dateTimePickerContacte_desde.ValueChanged += DateTimePicker_desde_ValueChanged;
            fm.dateTimePickerContacte_hasta.ValueChanged += DateTimePicker_hasta_ValueChanged;
            fm.textBoxContacte_filtre.TextChanged += TextBox_filtre_TextChanged;
            fm.dataGridViewContacte_missatges.CellFormatting += DataGridViewContacte_missatges_CellFormatting;
            fm.comboBoxContacte_usuari.SelectedIndexChanged += ComboBoxContacte_usuari_SelectedIndexChanged; 
            fm.checkBoxContacte_veureLlegits.CheckedChanged += CheckBoxContacte_veureLlegits_CheckedChanged;
            fm.dataGridViewContacte_missatges.SelectionChanged += DataGridViewContacte_missatges_SelectionChanged;
        }

        private void DataGridViewContacte_missatges_SelectionChanged(object sender, EventArgs e)
        {
            if (fm.dataGridViewContacte_missatges.SelectedRows.Count > 0)
            {
                fm.buttonContacte_obrir.Enabled = true;
            }
            else
            {
                fm.buttonContacte_obrir.Enabled = false;
            }
        }

        private void ComboBoxContacte_usuari_SelectedIndexChanged(object sender, EventArgs e)
        {
            var usuariSeleccionat = fm.comboBoxContacte_usuari.SelectedItem as Usuari;

            string correu;
            if (usuariSeleccionat != null) correu = usuariSeleccionat.correu;
            else correu = "Tots";

            var filtre = fm.textBoxContacte_filtre.Text;
            var desde = fm.dateTimePickerContacte_desde.Value;
            var hasta = fm.dateTimePickerContacte_hasta.Value;

            LoadDataDgvMissatges(correu, filtre, desde, hasta);
        }

        private void LoadDataDgvMissatges(string correuUsuari, string filtre, DateTime desde, DateTime hasta)
        {
            bool tots = true;

            if (fm.checkBoxContacte_veureLlegits.Checked) tots = false;

            var missatges = _contacteService.GetMissatgesUsuariRestaurant(filtre, desde, hasta, correuUsuari, tots);
            fm.dataGridViewContacte_missatges.DataSource = missatges;

            var (llegits, noLlegits) = _contacteService.ComptarMissatgesLlegitsINoLlegits(filtre, desde, hasta, correuUsuari, tots);
            fm.textBoxContacte_llegits.Text = llegits.ToString();
            fm.textBoxContacte_noLlegits.Text = noLlegits.ToString();
        }


        private void LoadDataDgvMissatges()
        {
            var usuariSeleccionat = fm.comboBoxContacte_usuari.SelectedItem as Usuari;
            string correu = usuariSeleccionat?.correu ?? "Tots";

            var filtre = fm.textBoxContacte_filtre.Text;
            var desde = fm.dateTimePickerContacte_desde.Value;
            var hasta = fm.dateTimePickerContacte_hasta.Value;

            LoadDataDgvMissatges(correu, filtre, desde, hasta);
        }

        private void LoadData()
        {
            var usuaris = _contacteService.GetUsuarisAmbMissatges();

            var usuariTots = new Usuari
            {
                id = -1,
                correu = "Tots",
            };
            usuaris.Insert(0, usuariTots);

            fm.comboBoxContacte_usuari.DataSource = usuaris;
            fm.comboBoxContacte_usuari.DisplayMember = "correu";

            LoadDataDgvMissatges("Tots", fm.textBoxContacte_filtre.Text, fm.dateTimePickerContacte_desde.Value, fm.dateTimePickerContacte_hasta.Value);

            fm.dataGridViewContacte_missatges.Columns["id"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["missatge"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["restaurantId"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["nom"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["cognoms"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["telefon"].Visible = false;
            fm.dataGridViewContacte_missatges.Columns["dataMissatge"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }


        // Obrir missatge amb la informació del missatge al text del form
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

        // Pintar fila de gris si el missatge està llegit
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

        // Controlar bien los cambios de fecha y cargar los mensajes al cambiarlos
        private void DateTimePicker_desde_ValueChanged(object sender, EventArgs e)
        {
            if (fm.dateTimePickerContacte_desde.Value > fm.dateTimePickerContacte_hasta.Value)
            {
                fm.dateTimePickerContacte_desde.Value = fm.dateTimePickerContacte_hasta.Value;
                MessageBox.Show("La data 'Des de' no pot ser posterior a la data 'Fins a'.", "Data invàlida.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadDataDgvMissatges();
        }

        private void DateTimePicker_hasta_ValueChanged(object sender, EventArgs e)
        {
            if (fm.dateTimePickerContacte_hasta.Value < fm.dateTimePickerContacte_desde.Value)
            {
                fm.dateTimePickerContacte_hasta.Value = fm.dateTimePickerContacte_desde.Value;
                MessageBox.Show("La data 'Fins a' no pot ser anterior a la data 'Des de'.", "Data invàlida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadDataDgvMissatges();
        }

        private void CheckBoxContacte_veureLlegits_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataDgvMissatges();
        }
    }
}
