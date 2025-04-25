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
using Taules.View;

namespace Taules.Controller
{
    public class TaulesControllerr
    {
        //TaulesForm f;
        //AfegirTaulaForm fa;
        //private readonly ITaulaService _taulaService;

        //public TaulesController(ITaulaService taulaService)
        //{
        //    _taulaService = taulaService;
        //}

        //public void ShowForm()
        //{
        //    f = new TaulesForm();
        //    fa = new AfegirTaulaForm();
        //    SetListeners();
        //    LoadData();

        //    f.Show();
        //}

        //private void SetListeners()
        //{
        //    f.button_afegir.Click += Button_afegir_Click;
        //    f.button_editar.Click += Button_editar_Click;
        //    f.button_eliminar.Click += Button_eliminar_Click;
        //    fa.button_afegir_editar_taula.Click += Button_afegir_editar_taula_Click;
        //    f.dataGridView_taules.SelectionChanged += DataGridView_taules_SelectionChanged;
        //}

        //private void DataGridView_taules_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (f.dataGridView_taules.SelectedRows.Count == 1)
        //    {
        //        f.button_editar.Enabled = true;
        //    }
        //    else if (f.dataGridView_taules.SelectedRows.Count >= 1)
        //    {
        //        f.button_eliminar.Enabled = true;
        //        f.button_editar.Enabled = false;
        //    }
        //    else
        //    {
        //        f.button_editar.Enabled = false;
        //        f.button_eliminar.Enabled = false;
        //    }
        //}

        //private async void Button_afegir_editar_taula_Click(object sender, EventArgs e)
        //{
        //    var comensalsTaula = (int)fa.numericUpDown_numcomensals.Value;

        //    if (fa.button_afegir_editar_taula.Text.Equals("AFEGIR"))
        //    {

        //        var response = await _taulaService.AddTaulaAsync(comensalsTaula);

        //        if (response)
        //        {
        //            MessageBox.Show("Taula afegida correctament.", "Afegir taula", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadData();
        //            fa.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No s'ha pogut afegir la taula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    } else {
        //        var taulaSeleccionada = f.dataGridView_taules.SelectedRows[0].DataBoundItem as Taula;

        //        taulaSeleccionada.numComensals = comensalsTaula;

        //        bool response = await _taulaService.UpdateTaulaAsync(taulaSeleccionada);

        //        if (response)
        //        {
        //            MessageBox.Show("Taula editada.", "Edicio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadData();
        //            fa.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No es possible editar la taula seleccionada.", "Edicio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //}

        //private void Button_eliminar_Click(object sender, EventArgs e)
        //{
        //    if (f.dataGridView_taules.SelectedRows.Count > 0)
        //    {
        //        List<Taula> taulesSeleccionades = new List<Taula>();

        //        foreach (DataGridViewRow row in f.dataGridView_taules.SelectedRows)
        //        {
        //            var taula = row.DataBoundItem as Taula;

        //            if (taula != null)
        //            {
        //                taulesSeleccionades.Add(taula);
        //            }
        //        }

        //        bool resultatDelete = _taulaService.DeleteTaules(taulesSeleccionades);

        //        if (resultatDelete)
        //        {
        //            MessageBox.Show("Taules eliminades.", "Eliminacio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadData();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No es possible eliminar les taules seleccionades.", "Eliminacio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No hi ha taules seleccionades.");
        //    }
        //}

        //private void Button_editar_Click(object sender, EventArgs e)
        //{
        //    if (fa.button_afegir_editar_taula.Text.Equals("AFEGIR"))
        //    {
        //        fa.button_afegir_editar_taula.Text = "EDITAR";
        //    }
        //    var taulaSeleccionada = f.dataGridView_taules.SelectedRows[0].DataBoundItem as Taula;

        //    fa.numericUpDown_numcomensals.Value = taulaSeleccionada.numComensals;

        //    fa.ShowDialog();
        //}

        //private void Button_afegir_Click(object sender, EventArgs e)
        //{
        //    if (fa.button_afegir_editar_taula.Text.Equals("EDITAR"))
        //    {
        //        fa.button_afegir_editar_taula.Text = "AFEGIR";
        //    }

        //    fa.ShowDialog();
        //}

        //private async void LoadData()
        //{
        //    f.dataGridView_taules.DataSource = _taulaService.GetTaules();
        //    f.textBox_aforamentActual.Text = _taulaService.GetAforamentActual().ToString();
        //    f.textBox_aforamentMaxim.Text = _taulaService.GetAforamentMaxim().ToString();
        //}
    }
}
