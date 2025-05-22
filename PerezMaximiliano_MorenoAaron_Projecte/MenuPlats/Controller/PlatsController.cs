using Entitats.PlatClasses;
using PerezMaximiliano_MorenoAaron_Projecte.MenuPlats.View;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MenuPlats.Controller
{
    public class PlatsController
    {
        private MenuForm fm;
        private AfegirPlatForm fp;
        private readonly ITipusService _tipusService;
        private readonly IPlatService _platService;

        public PlatsController(ITipusService tipusService, IPlatService platService)
        {
            _tipusService = tipusService;
            _platService = platService;
        }

        public void Inicialitzar()
        {
            if (fp == null)
            {
                fp = new AfegirPlatForm();
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
            fm.buttonMenu_afegir.Click += ButtonMenu_afegir_Click;
            fm.buttonMenu_editar.Click += ButtonMenu_editar_Click;
            fm.buttonMenu_eliminar.Click += ButtonMenu_eliminar_Click;
            fm.dataGridViewMenu_plats.SelectionChanged += DataGridViewMenu_plats_SelectionChanged;
            fm.comboBoxMenu_tipusPlats.SelectedIndexChanged += ComboBoxMenu_tipusPlats_SelectedIndexChanged;

            fp.buttonAfegirPlat_afegir_editar.Click += ButtonAfegirPlat_afegir_editar_Click;
            fp.numericUpDownAfegirPlats_preu.KeyPress += NumericUpDownAfegirPlats_preu_KeyPress; ;
        }

        private void LoadData()
        {
            // Obtener los tipos de plato
            var tipusPlatsOriginal = _tipusService.GetTipusPlats();

            // Crear lista con contador por tipo
            var tipusPlats = tipusPlatsOriginal.Select(t => new TipusPlatCombo
            {
                id = t.id,
                descripcio = t.descripcio,
                quantitat = _platService.GetCountPlatsByTipus(t.id)
            }).ToList();

            // Calcular total para "Tots"
            int total = tipusPlats.Sum(t => t.quantitat);
            tipusPlats.Insert(0, new TipusPlatCombo
            {
                id = -1,
                descripcio = "Tots",
                quantitat = total
            });

            // ComboBox de filtro
            fm.comboBoxMenu_tipusPlats.DisplayMember = "ToString";
            fm.comboBoxMenu_tipusPlats.DataSource = tipusPlats;

            // ComboBox para añadir plato (sin contador)
            fp.comboBoxAfegirPlats_tipusPlats.DisplayMember = "descripcio";
            fp.comboBoxAfegirPlats_tipusPlats.DataSource = tipusPlatsOriginal;

            LoadDgvPlats();

            // Ocultar columnas no necesarias
            fm.dataGridViewMenu_plats.Columns["id"].Visible = false;
            fm.dataGridViewMenu_plats.Columns["restaurantid"].Visible = false;
            fm.dataGridViewMenu_plats.Columns["tipusPlatId"].Visible = false;
        }

        // Cargar datagrid de platos
        private void LoadDgvPlats()
        {
            var tipusSeleccionat = fm.comboBoxMenu_tipusPlats.SelectedItem as TipusPlatCombo;

            int tipusId;
            if (tipusSeleccionat != null) tipusId = tipusSeleccionat.id;
            else tipusId = -1;

            fm.dataGridViewMenu_plats.DataSource = _platService.GetPlats(tipusId);
        }


        // Al seleccionar tipo de plato cargar el datagrid
        private void ComboBoxMenu_tipusPlats_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvPlats();
        }

        // Añadir o editar plato según el botón pulsado previamente
        private void ButtonAfegirPlat_afegir_editar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fp.textBoxAfegirPlat_nomPlat.Text) || String.IsNullOrEmpty(fp.textBoxAfegirPlat_descripcio.Text))
            {
                MessageBox.Show("Has d'omplir tots els camps.", "Camps buits.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fp.numericUpDownAfegirPlats_preu.Value.ToString().Contains(","))
            {
                MessageBox.Show("Has d'utilitzar un punt com a separador en el preu.", "Format incorrecte.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (fp.buttonAfegirPlat_afegir_editar.Text.Equals("AFEGIR"))
            {
                Plat newPlat = new Plat
                {
                    restaurantid = 0,
                    tipusPlatId = ((TipusPlat)fp.comboBoxAfegirPlats_tipusPlats.SelectedItem).id,
                    nom = fp.textBoxAfegirPlat_nomPlat.Text,
                    descripcio = fp.textBoxAfegirPlat_descripcio.Text,
                    preu = fp.numericUpDownAfegirPlats_preu.Value
                };

                var response = _platService.AddPlat(newPlat);

                if (response)
                {
                    MessageBox.Show("Plat afegit correctament.", "Afegir plat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvPlats();
                    fp.Close();
                }
                else
                {
                    MessageBox.Show("No s'ha pogut afegir el plat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var platSeleccionat = fm.dataGridViewMenu_plats.SelectedRows[0].DataBoundItem as Plat;

                platSeleccionat.nom = fp.textBoxAfegirPlat_nomPlat.Text;
                platSeleccionat.descripcio = fp.textBoxAfegirPlat_descripcio.Text;
                platSeleccionat.preu = fp.numericUpDownAfegirPlats_preu.Value;
                platSeleccionat.tipusPlatId = ((TipusPlat)fp.comboBoxAfegirPlats_tipusPlats.SelectedItem).id;

                bool response = _platService.UpdatePlat(platSeleccionat);

                if (response)
                {
                    MessageBox.Show("Plat editat.", "Edicio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvPlats();
                    fp.Close();
                }
                else
                {
                    MessageBox.Show("No es possible editar el plat seleccionat.", "Edicio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Activar o desactivar botones segun las filas del datagrid seleccionados
        private void DataGridViewMenu_plats_SelectionChanged(object sender, EventArgs e)
        {
            if (fm.dataGridViewMenu_plats.SelectedRows.Count == 1)
            {
                fm.buttonMenu_editar.Enabled = true;
                fm.buttonMenu_eliminar.Enabled = true;
            }
            else if (fm.dataGridViewMenu_plats.SelectedRows.Count > 1)
            {
                fm.buttonMenu_editar.Enabled = false;
                fm.buttonMenu_eliminar.Enabled = true;
            }
            else
            {
                fm.buttonMenu_editar.Enabled = false;
                fm.buttonMenu_eliminar.Enabled = false;
            }
        }

        private void ButtonMenu_eliminar_Click(object sender, EventArgs e)
        {
            if (fm.dataGridViewMenu_plats.SelectedRows.Count > 0)
            {
                List<Plat> platsSeleccionts = new List<Plat>();

                foreach (DataGridViewRow row in fm.dataGridViewMenu_plats.SelectedRows)
                {
                    var plat = row.DataBoundItem as Plat;

                    if (plat != null)
                    {
                        platsSeleccionts.Add(plat);
                    }
                }

                bool resultatDelete = _platService.DeletePlats(platsSeleccionts);

                if (resultatDelete)
                {
                    MessageBox.Show("Plats eliminats.", "Eliminacio exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgvPlats();
                }
                else
                {
                    MessageBox.Show("No es possible eliminar els plats seleccionats.", "Eliminacio denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hi ha plats seleccionats.");
            }
        }

        // Decidir si el metodo será para editar o añadir un plato (en este caso editar)
        private void ButtonMenu_editar_Click(object sender, EventArgs e)
        {
            if (fp.buttonAfegirPlat_afegir_editar.Text.Equals("AFEGIR"))
            {
                fp.buttonAfegirPlat_afegir_editar.Text = "EDITAR";
                fp.Text = "Editar plat";
            }
            var platSeleccionat = fm.dataGridViewMenu_plats.SelectedRows[0].DataBoundItem as Plat;

            fp.comboBoxAfegirPlats_tipusPlats.SelectedItem = _tipusService.GetTipusPlatById(platSeleccionat.tipusPlatId); 

            fp.textBoxAfegirPlat_nomPlat.Text = platSeleccionat.nom;
            fp.textBoxAfegirPlat_descripcio.Text = platSeleccionat.descripcio;
            fp.numericUpDownAfegirPlats_preu.Value = platSeleccionat.preu;

            fp.ShowDialog();
        }

        // Decidir si el metodo será para editar o añadir un plato (en este caso añadir)
        private void ButtonMenu_afegir_Click(object sender, EventArgs e)
        {
            if (fp.buttonAfegirPlat_afegir_editar.Text.Equals("EDITAR"))
            {
                fp.buttonAfegirPlat_afegir_editar.Text = "AFEGIR";
                fp.Text = "Afegir plat";
            }

            fp.textBoxAfegirPlat_nomPlat.Clear();
            fp.textBoxAfegirPlat_descripcio.Clear();
            fp.comboBoxAfegirPlats_tipusPlats.SelectedIndex = 0;
            fp.numericUpDownAfegirPlats_preu.Value = 0.99M;

            fp.ShowDialog();
        }

        private void NumericUpDownAfegirPlats_preu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true; // No permite escribir la coma como separador de los decimales en el precio
            }
        }
    }
}
