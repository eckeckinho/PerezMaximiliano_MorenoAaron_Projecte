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

namespace Taules.Controller
{
    public class TaulesController
    {
        private MenuForm fm;
        AfegirTaulaForm fa;
        private readonly ITaulaService _taulaService;

        public TaulesController(ITaulaService taulaService)
        {
            _taulaService = taulaService;
        }

        public void Inicialitzar()
        {
            if (fa == null)
            {
                fa = new AfegirTaulaForm();
                SetListeners();
                LoadData();
            }
        }

        private void SetListeners()
        {
            fm.buttonTaula_afegir.Click += Button_afegir_Click;
            fm.buttonTaula_editar.Click += Button_editar_Click;
            fm.buttonTaula_eliminar.Click += Button_eliminar_Click;
            fm.dataGridViewTaula_taules.SelectionChanged += DataGridView_taules_SelectionChanged;

            fa.buttonTaula_afegir_editar.Click += Button_afegir_editar_taula_Click;
        }

        private void DataGridView_taules_SelectionChanged(object sender, EventArgs e)
        {
            if (fm.dataGridViewTaula_taules.SelectedRows.Count == 1)
            {
                fm.buttonTaula_editar.Enabled = true;
                fm.buttonTaula_eliminar.Enabled = true;
            }
            else if (fm.dataGridViewTaula_taules.SelectedRows.Count > 1)
            {
                fm.buttonTaula_editar.Enabled = false;
                fm.buttonTaula_eliminar.Enabled = true;
            }
            else
            {
                fm.buttonTaula_editar.Enabled = false;
                fm.buttonTaula_eliminar.Enabled = false;
            }
        }

        private async void Button_afegir_editar_taula_Click(object sender, EventArgs e)
        {
            var comensalsTaula = (int)fa.numericUpDownTaula_numcomensals.Value;

            if (fa.buttonTaula_afegir_editar.Text.Equals("AFEGIR"))
            {

                var response = await _taulaService.AddTaulaAsync(comensalsTaula);

                if (response)
                {
                    MessageBox.Show("Taula afegida correctament.", "Afegir taula", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    fa.Close();
                }
                else
                {
                    MessageBox.Show("No s'ha pogut afegir la taula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var taulaSeleccionada = fm.dataGridViewTaula_taules.SelectedRows[0].DataBoundItem as Taula;

                taulaSeleccionada.numComensals = comensalsTaula;

                bool response = await _taulaService.UpdateTaulaAsync(taulaSeleccionada);

                if (response)
                {
                    MessageBox.Show("Taula editada.", "Edicio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    fa.Close();
                }
                else
                {
                    MessageBox.Show("No es possible editar la taula seleccionada.", "Edicio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Button_eliminar_Click(object sender, EventArgs e)
        {
            if (fm.dataGridViewTaula_taules.SelectedRows.Count > 0)
            {
                List<Taula> taulesSeleccionades = new List<Taula>();

                foreach (DataGridViewRow row in fm.dataGridViewTaula_taules.SelectedRows)
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
            if (fa.buttonTaula_afegir_editar.Text.Equals("AFEGIR"))
            {
                fa.buttonTaula_afegir_editar.Text = "EDITAR";
            }
            var taulaSeleccionada = fm.dataGridViewTaula_taules.SelectedRows[0].DataBoundItem as Taula;

            fa.numericUpDownTaula_numcomensals.Value = taulaSeleccionada.numComensals;

            fa.ShowDialog();
        }

        private void Button_afegir_Click(object sender, EventArgs e)
        {
            if (fa.buttonTaula_afegir_editar.Text.Equals("EDITAR"))
            {
                fa.buttonTaula_afegir_editar.Text = "AFEGIR";
            }

            fa.ShowDialog();
        }

        private void LoadData()
        {
            fm.dataGridViewTaula_taules.DataSource = _taulaService.GetTaules();
            fm.textBoxTaula_aforamentActual.Text = _taulaService.GetAforamentActual().ToString();
            fm.textBoxTaula_aforamentMaxim.Text = _taulaService.GetAforamentMaxim().ToString();
        }

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }
    }
}
