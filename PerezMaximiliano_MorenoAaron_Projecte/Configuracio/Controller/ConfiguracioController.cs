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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Configuracio.Controller
{
    public class ConfiguracioController
    {
        private MenuForm fm;
        private readonly IConfiguracioService _configuracioService;
        private readonly ITipusService _tipusService;

        public ConfiguracioController(IConfiguracioService configuracioService, ITipusService tipusService)
        {
            _configuracioService = configuracioService;
            _tipusService = tipusService;
        }

        public void Inicialitzar()
        {
            SetListeners();
            LoadData();
        }

        private void SetListeners()
        {
            fm.buttonConfiguracio_editar.Click += Button_editar_click;
            fm.materialCheckboxConfiguracio_veureContrasenya.CheckedChanged += Checkbox_veureContrasenya_CheckedChanged;

        }

        private void Checkbox_veureContrasenya_CheckedChanged(object sender, EventArgs e)
        {
            if (fm.materialCheckboxConfiguracio_veureContrasenya.Checked)
            {
                fm.textBoxConfiguracio_contrasenya.PasswordChar = '\0'; 
            }
            else
            {
                fm.textBoxConfiguracio_contrasenya.PasswordChar = '●'; 
            }
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
            fm.textBoxConfiguracio_contrasenya.Text = restaurant.contrasenyaCompte;
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
