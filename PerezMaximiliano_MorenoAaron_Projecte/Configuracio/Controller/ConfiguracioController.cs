using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taules.View;

namespace Configuracio.Controller
{
    public class ConfiguracioController
    {
        private MenuForm fm;
        NovaContrasenyaForm fn;
        private readonly IConfiguracioService _configuracioService;
        private readonly ITipusService _tipusService;

        public ConfiguracioController(IConfiguracioService configuracioService, ITipusService tipusService)
        {
            _configuracioService = configuracioService;
            _tipusService = tipusService;
        }

        public void Inicialitzar()
        {
            if (fn == null)
            {
                fn = new NovaContrasenyaForm();
                SetListeners();
                LoadData();
            }
        }

        private void SetListeners()
        {
            fm.buttonConfiguracio_editar.Click += Button_editar_click;
            fm.buttonConfiguracio_newContrasenya.Click += Button_newContrasenya_click;
            fn.materialCheckboxConfiguracio_veureContrasenyaNova.CheckedChanged += MaterialCheckbox_veureContrasenyaNova_CheckedChanged;
            fn.materialCheckboxConfiguracio_veureContrasenyaRepetir.CheckedChanged += MaterialCheckbox_veureContrasenyaRepetir_CheckedChanged;
            fn.buttonConfiguracio_canviarContrasenya.Click += ButtonConfiguracio_canviarContrasenya_Click;
        }

        private void ButtonConfiguracio_canviarContrasenya_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fn.textBoxConfiguracio_novaContrasenya.Text) && !string.IsNullOrEmpty(fn.textBoxConfiguracio_repetirContrasenya.Text))
            {
                if (fn.textBoxConfiguracio_novaContrasenya.Text.Equals(fn.textBoxConfiguracio_repetirContrasenya.Text))
                {
                    var respostaCanviContrasenya = _configuracioService.CanviarContrasenyaRestaurant(fn.textBoxConfiguracio_novaContrasenya.Text);

                    if (respostaCanviContrasenya != null)
                    {
                        MessageBox.Show("Contrasenya canviada correctament.", "Contrasenya canviada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fn.textBoxConfiguracio_repetirContrasenya.Text = "";
                        fn.textBoxConfiguracio_novaContrasenya.Text = "";
                        fn.Close();
                    } else
                    {
                        MessageBox.Show("Error canviant la contrasenya.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("Les contrasenyes no coincideixen.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Insereix una contrasenya nova.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaterialCheckbox_veureContrasenyaRepetir_CheckedChanged(object sender, EventArgs e)
        {
            if (fn.materialCheckboxConfiguracio_veureContrasenyaRepetir.Checked)
            {
                fn.textBoxConfiguracio_repetirContrasenya.PasswordChar = '\0';
            }
            else
            {
                fn.textBoxConfiguracio_repetirContrasenya.PasswordChar = '●';
            }
        }

        private void MaterialCheckbox_veureContrasenyaNova_CheckedChanged(object sender, EventArgs e)
        {
            if (fn.materialCheckboxConfiguracio_veureContrasenyaNova.Checked)
            {
                fn.textBoxConfiguracio_novaContrasenya.PasswordChar = '\0';
            }
            else
            {
                fn.textBoxConfiguracio_novaContrasenya.PasswordChar = '●';
            }
        }

        private void Button_newContrasenya_click(object sender, EventArgs e)
        {
            fn.ShowDialog();
        }

        private void Button_editar_click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void LoadData()
        {
            Restaurant restaurant = _configuracioService.GetRestaurantConfig();

            fm.comboBoxConfiguracio_tipuscuina.DataSource = await _tipusService.GetTipusCuines();
            fm.comboBoxConfiguracio_tipuscuina.DisplayMember = "descripcio";
            fm.comboBoxConfiguracio_tipuscuina.ValueMember = "id";
            fm.comboBoxConfiguracio_tipuspreu.DataSource = await _tipusService.GetTipusPreus();
            fm.comboBoxConfiguracio_tipuspreu.DisplayMember = "descripcio";
            fm.comboBoxConfiguracio_tipuspreu.ValueMember = "id";

            if (restaurant != null)
            {
                SetRestaurantData(restaurant);
            }
            else
            {
                MessageBox.Show("No s'ha pogut carregar la configuració del restaurant.");
            }     
        }

        private void SetRestaurantData(Restaurant restaurant)
        {
            fm.textBoxConfiguracio_usuari.Text = restaurant.nomCompte;
            fm.comboBoxConfiguracio_tipuscuina.SelectedValue = restaurant.tipusCuinaId;
            fm.comboBoxConfiguracio_tipuspreu.SelectedValue = restaurant.tipusPreuId;
            fm.textBoxConfiguracio_nom.Text = restaurant.nomRestaurant;
            fm.textBoxConfiguracio_descripcio.Text = restaurant.descripcio;
            fm.textBoxConfiguracio_pais.Text = restaurant.pais;
            fm.textBoxConfiguracio_poblacio.Text = restaurant.ciutat;
            fm.textBoxConfiguracio_carrer.Text = restaurant.carrer;
            fm.textBoxConfiguracio_codipostal.Text = restaurant.codiPostal;
            fm.textBoxConfiguracio_telefon.Text = restaurant.telefon;
            fm.textBoxConfiguracio_correu.Text = restaurant.correu;
            fm.textBoxConfiguracio_paginaweb.Text = restaurant.paginaWeb;
            fm.textBoxConfiguracio_aforament.Text = restaurant.aforament.ToString();
            fm.pictureBoxConfiguracio_logo.Image = ByteArrayToImage(restaurant.logo);
        }

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }

        private Image ByteArrayToImage(byte[] logo)
        {
            if (logo != null && logo.Length > 0)
            {
                using (var ms = new MemoryStream(logo))
                {
                    return Image.FromStream(ms);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
