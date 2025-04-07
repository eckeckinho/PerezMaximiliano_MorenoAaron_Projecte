using Entitats.ReservaClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserves.Controller
{
    public class ReservesController
    {
        ReservesForm f;
        private readonly IReservaService _reservaService;
        private readonly ITipusService _tipusService;

        public ReservesController(IReservaService reservaService, ITipusService tipusService) 
        { 
            _reservaService = reservaService;
            _tipusService = tipusService;
        }

        public void ShowForm()
        {
            f = new ReservesForm();
            SetListeners();
            LoadData();

            f.Show();
        }

        private void SetListeners()
        {
            f.button_guardar.Click += Button_guardar_Click;
            f.button_afegir.Click += Button_afegir_Click;
            f.comboBox_estatreserva.SelectedIndexChanged += ComboBox_estatreserva_SelectedIndexChanged; ;
        }

        private void ComboBox_estatreserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvReservas();
        }

        private void Button_afegir_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_guardar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void LoadData()
        {
            f.comboBox_estatreserva.DataSource = await _tipusService.GetTipusEstats();
            f.comboBox_estatreserva.DisplayMember = "descripcio";

            LoadDgvReservas();
        }

        private void LoadDgvReservas()
        {
            // Implementar async en caso necesario (?)

            var estatReserva = f.comboBox_estatreserva.SelectedItem as TipusEstat;
            if (estatReserva != null)
            {
                f.dataGridView_taules.DataSource = _reservaService.GetReservesRestaurant(estatReserva.id);
            }
        }
    }
}
