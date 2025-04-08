using Entitats.ReservaClasses;
using Entitats.TaulaClasses;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taules.Controller
{
    public class TaulesController
    {
        TaulesForm f;
        private readonly ITaulaService _taulaService;

        public TaulesController(ITaulaService taulaService)
        {
            _taulaService = taulaService;
        }

        public void ShowForm()
        {
            f = new TaulesForm();
            SetListeners();
            LoadData();

            f.Show();
        }

        private void SetListeners()
        {
            f.button_afegir.Click += Button_afegir_Click;
            f.button_editar.Click += Button_editar_Click;
            f.button_eliminar.Click += Button_eliminar_Click;
        }

        private void Button_eliminar_Click(object sender, EventArgs e)
        {
            if (f.dataGridView_taules.SelectedRows.Count > 0)
            {
                List<Taula> taulesSeleccionades = new List<Taula>();

                foreach (DataGridViewRow row in f.dataGridView_taules.SelectedRows)
                {
                    var taula = row.DataBoundItem as Taula;

                    if (taula != null)
                    {
                        taulesSeleccionades.Add(taula);
                    }
                }

                bool resultatDelete = _taulaService.DeleteTaules(taulesSeleccionades);

                if (resultatDelete)
                {
                    MessageBox.Show("Taules eliminades.", "Eliminacio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("No es possible eliminar les taules seleccionades.", "Eliminacio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hi ha taules seleccionades.");
            }
        }

        private void Button_editar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_afegir_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void LoadData()
        {
            f.dataGridView_taules.DataSource = _taulaService.GetTaules();
            f.textBox_aforamentActual.Text = _taulaService.GetAforamentActual().ToString();
            f.textBox_aforamentMaxim.Text = _taulaService.GetAforamentMaxim().ToString();
        }
    }
}
