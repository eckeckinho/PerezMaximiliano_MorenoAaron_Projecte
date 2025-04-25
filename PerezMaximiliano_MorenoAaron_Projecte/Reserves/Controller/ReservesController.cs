using Entitats.ReservaClasses;
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
            fm.button_afegir.Click += Button_afegir_Click;
            fm.comboBoxReserva_estat.SelectedIndexChanged += ComboBox_estatreserva_SelectedIndexChanged;
            fm.dateTimePickerReserva_desde.ValueChanged += DateTimePicker_diareserva_desde_ValueChanged;
            fm.dateTimePickerReserva_hasta.ValueChanged += DateTimePicker_diareserva_hasta_ValueChanged;
            fm.dataGridViewReserva_reserves.SelectionChanged += DataGridView_reserves_SelectionChanged;
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

                bool resultatCancelacio = _reservaService.CancelarReserves(reservasSeleccionadas);

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

                bool resultatFinalitzacio = _reservaService.FinalitzarReserves(reservasSeleccionadas);

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
            }
            else
            {
                fm.buttonReserva_finalitzar.Enabled = false;
            }
        }

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }
    }
}
