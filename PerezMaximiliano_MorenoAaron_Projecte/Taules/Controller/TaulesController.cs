using Entitats.TaulaClasses;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            }
            LoadData();
        }
        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }

        private void SetListeners()
        {
            fm.buttonTaula_afegir.Click += Button_afegir_Click;
            fm.buttonTaula_editar.Click += Button_editar_Click;
            fm.buttonTaula_eliminar.Click += Button_eliminar_Click;
            fm.dataGridViewTaula_taules.SelectionChanged += DataGridView_taules_SelectionChanged;
            fm.comboBoxTaula_comensals.SelectedIndexChanged += ComboBoxTaula_comensals_SelectedIndexChanged;

            fa.buttonTaula_afegir_editar.Click += Button_afegir_editar_taula_Click;
        }

        private void ComboBoxTaula_comensals_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comensalsSeleccionats = fm.comboBoxTaula_comensals.SelectedItem as CapacitatTaulaCombo;

            if (comensalsSeleccionats == null) return;

            var taules = _taulaService.GetTaules();

            if (comensalsSeleccionats.capacitat != -1)taules = taules.Where(t => t.numComensals == comensalsSeleccionats.capacitat).ToList();

            fm.dataGridViewTaula_taules.DataSource = taules;
        }

        private void LoadData()
        {
            fm.dataGridViewTaula_taules.DataSource = _taulaService.GetTaules();
            fm.textBoxTaula_aforamentActual.Text = _taulaService.GetAforamentActual().ToString();
            fm.textBoxTaula_aforamentMaxim.Text = _taulaService.GetAforamentMaxim().ToString();
            fm.dataGridViewTaula_taules.Columns["id"].Visible = false;
            fm.dataGridViewTaula_taules.Columns["restaurantId"].Visible = false;
            fm.comboBoxTaula_comensals.DataSource = _taulaService.GetCapacitatsCombo();
            fm.comboBoxTaula_comensals.DisplayMember = "ToString";
        }

        // Añadir o editar mesa según el botón pulsado previamente
        private void Button_afegir_editar_taula_Click(object sender, EventArgs e)
        {
            var comensalsTaula = (int)fa.numericUpDownTaula_numcomensals.Value;

            if (fa.buttonTaula_afegir_editar.Text.Equals("AFEGIR"))
            {

                var response = _taulaService.AddTaula(comensalsTaula);

                if (response)
                {
                    MessageBox.Show("Taula afegida correctament.", "Afegit completat.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    fa.Close();
                }
                else
                {
                    MessageBox.Show("No s'ha pogut afegir la taula.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                var taulaSeleccionada = fm.dataGridViewTaula_taules.SelectedRows[0].DataBoundItem as Taula;

                taulaSeleccionada.numComensals = comensalsTaula;

                bool response = _taulaService.UpdateTaula(taulaSeleccionada);

                if (response)
                {
                    MessageBox.Show("Taules modificades correctament.", "Modificació completada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    fa.Close();
                }
                else
                {
                    MessageBox.Show("No s'han pogut editar le taules.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Eliminar taula seleccionada
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
                    MessageBox.Show("Taules eliminades correctament.", "Eliminació completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("No s'han pogut eliminar le taules.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hi ha taules seleccionades.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Decidir si el metodo será para editar o añadir una mesa (en este caso editar)
        private void Button_editar_Click(object sender, EventArgs e)
        {
            if (fa.buttonTaula_afegir_editar.Text.Equals("AFEGIR"))
            {
                fa.buttonTaula_afegir_editar.Text = "EDITAR";
                fa.Text = "Editar taula";
            }
            var taulaSeleccionada = fm.dataGridViewTaula_taules.SelectedRows[0].DataBoundItem as Taula;

            fa.numericUpDownTaula_numcomensals.Value = taulaSeleccionada.numComensals;

            fa.ShowDialog();
        }

        // Decidir si el metodo será para editar o añadir una mesa (en este caso añadir)
        private void Button_afegir_Click(object sender, EventArgs e)
        {
            if (fa.buttonTaula_afegir_editar.Text.Equals("EDITAR"))
            {
                fa.buttonTaula_afegir_editar.Text = "AFEGIR";
                fa.Text = "Afegir taula";
            }

            fa.numericUpDownTaula_numcomensals.Value = 1;

            fa.ShowDialog();
        }

        // Activar o desactivar botones segun las filas del datagrid seleccionados
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
    }
}
