using Entitats.ReservaClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reserves.Controller
{
    public class ReservessController
    {
        //ReservesForm f;
        //private readonly IReservaService _reservaService;
        //private readonly ITipusService _tipusService;

        //public ReservesController(IReservaService reservaService, ITipusService tipusService) 
        //{ 
        //    _reservaService = reservaService;
        //    _tipusService = tipusService;
        //}

        //public void ShowForm()
        //{
        //    f = new ReservesForm();
        //    SetListeners();
        //    LoadData();

        //    f.Show();
        //}

        //private void SetListeners()
        //{
        //    f.button_finalitzar.Click += Button_finalitzar_Click;
        //    f.button_cancelar.Click += Button_cancelar_Click;
        //    f.button_afegir.Click += Button_afegir_Click;
        //    f.comboBox_estatreserva.SelectedIndexChanged += ComboBox_estatreserva_SelectedIndexChanged;
        //    f.dateTimePicker_diareserva_desde.ValueChanged += DateTimePicker_diareserva_desde_ValueChanged;
        //    f.dateTimePicker_diareserva_hasta.ValueChanged += DateTimePicker_diareserva_hasta_ValueChanged;
        //    f.dataGridView_reserves.SelectionChanged += DataGridView_reserves_SelectionChanged;
        //}

        //private void Button_cancelar_Click(object sender, EventArgs e)
        //{
        //    if (f.dataGridView_reserves.SelectedRows.Count > 0)
        //    {
        //        List<Reserva> reservasSeleccionadas = new List<Reserva>();

        //        foreach (DataGridViewRow row in f.dataGridView_reserves.SelectedRows)
        //        {
        //            var reserva = row.DataBoundItem as Reserva;

        //            if (reserva != null)
        //            {
        //                reservasSeleccionadas.Add(reserva);
        //            }
        //        }

        //        bool resultatCancelacio = _reservaService.CancelarReserves(reservasSeleccionadas);

        //        if (resultatCancelacio)
        //        {
        //            MessageBox.Show("Reserves cancelades.", "Cancelacio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadDgvReservas();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No es possible cancelar les reserves seleccionades.", "Cancelacio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No hi ha reserves seleccionades.");
        //    }
        //}

        //private void DataGridView_reserves_SelectionChanged(object sender, EventArgs e)
        //{
        //    ActivarBotonGuardar();
        //}

        //private void DateTimePicker_diareserva_hasta_ValueChanged(object sender, EventArgs e)
        //{
        //    LoadDgvReservas();
        //}

        //private void DateTimePicker_diareserva_desde_ValueChanged(object sender, EventArgs e)
        //{
        //    LoadDgvReservas();
        //}

        //private void ComboBox_estatreserva_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadDgvReservas();
        //    ActivarBotonGuardar();
        //}

        //private void Button_afegir_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void Button_finalitzar_Click(object sender, EventArgs e)
        //{
        //    if (f.dataGridView_reserves.SelectedRows.Count > 0)
        //    {
        //        List<Reserva> reservasSeleccionadas = new List<Reserva>();

        //        foreach (DataGridViewRow row in f.dataGridView_reserves.SelectedRows)
        //        {
        //            var reserva = row.DataBoundItem as Reserva;

        //            if (reserva != null)
        //            {
        //                reservasSeleccionadas.Add(reserva);
        //            }
        //        }

        //        bool resultatFinalitzacio = _reservaService.FinalitzarReserves(reservasSeleccionadas);

        //        if (resultatFinalitzacio)
        //        {
        //            MessageBox.Show("Reserves finalitzades.", "Finalitzacio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadDgvReservas();
        //        } else
        //        {
        //            MessageBox.Show("No es possible finalitzar les reserves seleccionades.", "Finalitzacio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No hi ha reserves seleccionades.");
        //    }
        //}

        //private async void LoadData()
        //{
        //    f.comboBox_estatreserva.DataSource = await _tipusService.GetTipusEstats();
        //    f.comboBox_estatreserva.DisplayMember = "descripcio";

        //    LoadDgvReservas();
        //}

        //private void LoadDgvReservas()
        //{
        //    // Implementar async en caso necesario (?)

        //    var estatReserva = f.comboBox_estatreserva.SelectedItem as TipusEstat;
        //    var dataReservaDesde = f.dateTimePicker_diareserva_desde.Value;
        //    var dataReservaHasta = f.dateTimePicker_diareserva_hasta.Value;
            
        //    f.dataGridView_reserves.DataSource = _reservaService.GetReservesRestaurant(estatReserva.id, dataReservaDesde, dataReservaHasta);
        //}

        //private void ActivarBotonGuardar()
        //{
        //    var estatReserva = f.comboBox_estatreserva.SelectedItem as TipusEstat;

        //    if (f.dataGridView_reserves.SelectedRows.Count > 0 && estatReserva.descripcio.Trim().ToUpper().Equals("P"))
        //    {
        //        f.button_finalitzar.Enabled = true;
        //    }
        //    else
        //    {
        //        f.button_finalitzar.Enabled = false;
        //    }
        //}
    }
}
