using Entitats.ReservaClasses;
using Entitats.TaulaClasses;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reserves.Controller
{
    public class ReservesController
    {
        private MenuForm fm;
        private readonly IReservaService _reservaService;
        private readonly ITipusService _tipusService;

        public ReservesController(IReservaService reservaService, ITipusService tipusService)
        {
            _reservaService = reservaService;
            _tipusService = tipusService;
        }

        public void Inicialitzar()
        {
            SetListeners();
            LoadData();
        }

        private void SetListeners()
        {
            fm.buttonReserva_finalitzar.Click += Button_finalitzar_Click;
            fm.buttonReserva_cancelar.Click += Button_cancelar_Click;
            fm.buttonReserva_enProces.Click += Button_enProces_Click;
            fm.button_afegir.Click += Button_afegir_Click;
            fm.comboBoxReserva_estat.SelectedIndexChanged += ComboBox_estatreserva_SelectedIndexChanged;
            fm.dateTimePickerReserva_desde.ValueChanged += DateTimePicker_diareserva_desde_ValueChanged;
            fm.dateTimePickerReserva_hasta.ValueChanged += DateTimePicker_diareserva_hasta_ValueChanged;
            fm.dataGridViewReserva_reserves.SelectionChanged += DataGridView_reserves_SelectionChanged;
        }

        private void Button_enProces_Click(object sender, EventArgs e)
        {
            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0)
            {
                List<Reserva> reservasSeleccionadas = new List<Reserva>();

                foreach (DataGridViewRow row in fm.dataGridViewReserva_reserves.SelectedRows)
                {
                    var reserva = row.DataBoundItem as Reserva;

                    if (reserva != null)
                    {
                        reservasSeleccionadas.Add(reserva);
                    }
                }

                //L'estat P té l'ID 4.
                var nouEstat = 4;
                bool resultatEnProces = _reservaService.CanviarEstatReserva(reservasSeleccionadas, nouEstat);

                if (resultatEnProces)
                {
                    MessageBox.Show("Reserves en proces.", "En proces exitos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvReservas();
                }
                else
                {
                    MessageBox.Show("No es possible possar en proces les reserves seleccionades.", "En proces denegat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hi ha reserves seleccionades.");
            }
        }

        private void Button_cancelar_Click(object sender, EventArgs e)
        {
            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0)
            {
                List<Reserva> reservasSeleccionadas = new List<Reserva>();

                foreach (DataGridViewRow row in fm.dataGridViewReserva_reserves.SelectedRows)
                {
                    var reserva = row.DataBoundItem as Reserva;

                    if (reserva != null)
                    {
                        reservasSeleccionadas.Add(reserva);
                    }
                }

                //L'estat C té l'ID 6.
                var nouEstat = 6;
                bool resultatCancelacio = _reservaService.CanviarEstatReserva(reservasSeleccionadas, nouEstat);

                if (resultatCancelacio)
                {
                    MessageBox.Show("Reserves cancelades.", "Cancelacio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvReservas();
                }
                else
                {
                    MessageBox.Show("No es possible cancelar les reserves seleccionades.", "Cancelacio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hi ha reserves seleccionades.");
            }
        }

        private void DataGridView_reserves_SelectionChanged(object sender, EventArgs e)
        {
            ActivarBotonGuardar();
            CargarDgvUsuari();
        }

        private void CargarDgvUsuari()
        {
            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0)
            {
                var reservaSeleccionada = fm.dataGridViewReserva_reserves.SelectedRows[0].DataBoundItem as Reserva;

                var usuariReserva = _reservaService.GetUsuariReserva(reservaSeleccionada.usuariId);
                fm.textBoxReserva_idUsuari.Text = usuariReserva.id.ToString();
                fm.textBoxReserva_correuUsuari.Text = usuariReserva.correu;
                fm.textBoxReserva_nomUsuari.Text = usuariReserva.nom;
                fm.textBoxReserva_cognomsUsuari.Text = usuariReserva.cognoms;
                fm.textBoxReserva_telefonUsuari.Text = usuariReserva.telefon;
            }
            else
            {
                fm.textBoxReserva_idUsuari.Text = "";
                fm.textBoxReserva_correuUsuari.Text = "";
                fm.textBoxReserva_nomUsuari.Text = "";
                fm.textBoxReserva_cognomsUsuari.Text = "";
                fm.textBoxReserva_telefonUsuari.Text = "";
            }
        }
            

        private void DateTimePicker_diareserva_hasta_ValueChanged(object sender, EventArgs e)
        {
            LoadDgvReservas();
        }

        private void DateTimePicker_diareserva_desde_ValueChanged(object sender, EventArgs e)
        {
            LoadDgvReservas();
        }

        private void ComboBox_estatreserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvReservas();
            ActivarBotonGuardar();
        }

        private void Button_afegir_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_finalitzar_Click(object sender, EventArgs e)
        {
            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0)
            {
                List<Reserva> reservasSeleccionadas = new List<Reserva>();

                foreach (DataGridViewRow row in fm.dataGridViewReserva_reserves.SelectedRows)
                {
                    var reserva = row.DataBoundItem as Reserva;

                    if (reserva != null)
                    {
                        reservasSeleccionadas.Add(reserva);
                    }
                }

                //L'estat F té l'ID 5.
                var nouEstat = 5;
                bool resultatFinalitzacio = _reservaService.CanviarEstatReserva(reservasSeleccionadas, nouEstat);

                if (resultatFinalitzacio)
                {
                    MessageBox.Show("Reserves finalitzades.", "Finalitzacio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvReservas();
                }
                else
                {
                    MessageBox.Show("No es possible finalitzar les reserves seleccionades.", "Finalitzacio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hi ha reserves seleccionades.");
            }
        }

        private async void LoadData()
        {
            fm.comboBoxReserva_estat.DataSource = await _tipusService.GetTipusEstats();
            fm.comboBoxReserva_estat.DisplayMember = "descripcio";

            fm.dataGridViewReserva_reserves.Columns["id"].Visible = false;
            fm.dataGridViewReserva_reserves.Columns["taulaId"].Visible = false;
            fm.dataGridViewReserva_reserves.Columns["usuariId"].Visible = false;
            fm.dataGridViewReserva_reserves.Columns["estatId"].Visible = false;

            LoadDgvReservas();
        }

        private void LoadDgvReservas()
        {
            try
            {
                var estatReserva = fm.comboBoxReserva_estat.SelectedItem as TipusEstat;
                var dataReservaDesde = fm.dateTimePickerReserva_desde.Value;
                var dataReservaHasta = fm.dateTimePickerReserva_hasta.Value;

                var reserves = _reservaService.GetReservesRestaurant(estatReserva.id, dataReservaDesde, dataReservaHasta);
                fm.dataGridViewReserva_reserves.DataSource = reserves;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error carregant reserves: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ActivarBotonGuardar()
        {
            var estatReserva = fm.comboBoxReserva_estat.SelectedItem as TipusEstat;

            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0 && estatReserva.descripcio.Trim().ToUpper().Equals("P"))
            {
                fm.buttonReserva_finalitzar.Enabled = true;
                fm.buttonReserva_cancelar.Enabled = true;
                fm.buttonReserva_enProces.Enabled = false;
            }
            else if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0 && estatReserva.descripcio.Trim().ToUpper().Equals("C"))
            {
                fm.buttonReserva_finalitzar.Enabled = true;
                fm.buttonReserva_cancelar.Enabled = false;
                fm.buttonReserva_enProces.Enabled = true;
            }
            else if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0 && estatReserva.descripcio.Trim().ToUpper().Equals("F"))
            {
                fm.buttonReserva_finalitzar.Enabled = false;
                fm.buttonReserva_cancelar.Enabled = true;
                fm.buttonReserva_enProces.Enabled = true;
            }
            else
            {
                fm.buttonReserva_finalitzar.Enabled = false;
                fm.buttonReserva_cancelar.Enabled = false;
                fm.buttonReserva_enProces.Enabled = false;
            }
        }

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }
    }
}
