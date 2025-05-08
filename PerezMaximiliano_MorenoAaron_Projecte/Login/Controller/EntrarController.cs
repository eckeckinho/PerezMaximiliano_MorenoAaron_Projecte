using Configuracio.Controller;
using Contacte.Controller;
using Entitats.RestaurantClasses;
using Microsoft.Extensions.DependencyInjection;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;
using Reserves.Controller;
using Services.Interfaces;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Taules.Controller;

namespace PerezMaximiliano_MorenoAaron_Projecte
{
    public class EntrarController
    {
        IniciarSessioForm f;
        MenuForm fm;
        Image logo;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        private readonly ITipusService _tipusService;

        public EntrarController(IAuthService authService, ITipusService tipusService, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _authService = authService;
            _tipusService = tipusService;
            f = new IniciarSessioForm();
            fm = new MenuForm();

            SetListeners();
            LoadData();
            f.ShowDialog();
        }

        private void LoadData()
        {
            f.comboBox_tipuscuina.DataSource = _tipusService.GetTipusCuines();
            f.comboBox_tipuscuina.DisplayMember = "descripcio";
            f.comboBox_tipuspreu.DataSource = _tipusService.GetTipusPreus();
            f.comboBox_tipuspreu.DisplayMember = "descripcio";
        }

        private void SetListeners()
        {
            f.button_entrar.Click += Button_entrar_Click;
            f.button_logo.Click += Button_logo_Click;
            f.button_registrar.Click += Button_registrar_Click;
            f.materialCheckboxEntrar_veureContrasenya.CheckedChanged += CheckboxEntrar_veureContrasenya_CheckedChanged;
            f.materialCheckboxRegistrar_veureContrasenya.CheckedChanged += CheckboxRegistrar_veureContrasenya_CheckedChanged;
        }

        private void CheckboxRegistrar_veureContrasenya_CheckedChanged(object sender, EventArgs e)
        {
            
            if (f.materialCheckboxRegistrar_veureContrasenya.Checked)
            {
                f.textbox_contrasenyaRegis.PasswordChar = '\0';
            }
            else
            {
                f.textbox_contrasenyaRegis.PasswordChar = '●';
            }
        }

        private void CheckboxEntrar_veureContrasenya_CheckedChanged(object sender, EventArgs e)
        {
            if (f.materialCheckboxEntrar_veureContrasenya.Checked)
            {
                f.textBox_contrasenyaEntrar.PasswordChar = '\0';
            }
            else
            {
                f.textBox_contrasenyaEntrar.PasswordChar = '●';
            }
        }

        private void SetListenersMenu()
        {
            fm.materialTabControl1.SelectedIndexChanged += MaterialTabControl1_SelectedIndexChanged;
            fm.buttonMain_tancarSessio.Click += ButtonMain_tancarSessio_Click;
        }

        private void ButtonMain_tancarSessio_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void MaterialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = fm.materialTabControl1.SelectedIndex;
            string tabName = fm.materialTabControl1.TabPages[selectedIndex].Name;

            switch (tabName)
            {
                case "tabPageTaules":
                    var taulesController = _serviceProvider.GetRequiredService<TaulesController>();
                    taulesController.SetForm(fm);
                    taulesController.Inicialitzar();
                    break;
                case "tabPageHorari":
                    var horariController = _serviceProvider.GetRequiredService<HorariController>();
                    horariController.SetForm(fm);
                    horariController.Inicialitzar();
                    break;
                case "tabPageContacte":
                    var contacteController = _serviceProvider.GetRequiredService<ContacteController>();
                    contacteController.SetForm(fm);
                    contacteController.Inicialitzar();
                    break;
                case "tabPageConfiguracio":
                    var configuracioController = _serviceProvider.GetRequiredService<ConfiguracioController>();
                    configuracioController.SetForm(fm);
                    configuracioController.Inicialitzar();
                    break;
            }
        }

        private void Button_entrar_Click(object sender, EventArgs e)
        {
            var nomUsuariRest = f.textBox_usuariEntrar.Text;
            var pswdUsuariRest = f.textBox_contrasenyaEntrar.Text;

            var (resultatLogin, restaurant) = _authService.LoginRestaurant(nomUsuariRest, pswdUsuariRest);

            if (resultatLogin)
            {
                // Setteamos el restaurante el cual ha realizado login correctamente para poderlo usar en todos los controllers de la aplicacion
                var contextRest = _serviceProvider.GetRequiredService<IRestaurantContext>();
                contextRest.restaurantActual = restaurant;

                var reservesController = _serviceProvider.GetRequiredService<ReservesController>();
                reservesController.SetForm(fm);
                reservesController.Inicialitzar();

                f.Hide();
                fm.Text = $"Benvingut, {restaurant.nomCompte}!";
                SetListenersMenu();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuari o contrasenya incorrectes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_registrar_Click(object sender, EventArgs e)
        {
            try
             {
                if (!string.IsNullOrWhiteSpace(f.textBox_usuariRegis.Text) &&
                !string.IsNullOrWhiteSpace(f.textbox_contrasenyaRegis.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_nom.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_pais.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_poblacio.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_codipostal.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_carrer.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_telefon.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_correu.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_aforament.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_descripcio.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_paginaweb.Text) &&
                f.comboBox_tipuscuina.SelectedItem != null &&
                f.comboBox_tipuspreu.SelectedItem != null)
                {

                    byte[] logoByteArray = logo != null ? ImageToByteArray(logo) : null;

                    Restaurant newRestaurant = new Restaurant
                    {
                        nomCompte = f.textBox_usuariRegis.Text,
                        contrasenyaCompte = BCrypt.Net.BCrypt.HashPassword(f.textbox_contrasenyaRegis.Text),
                        nomRestaurant = f.textbox_contrasenyaRegis.Text,
                        pais = f.textBox_pais.Text,
                        ciutat = f.textBox_poblacio.Text,
                        codiPostal = f.textBox_codipostal.Text,
                        carrer = f.textBox_carrer.Text,
                        telefon = f.textBox_telefon.Text,
                        correu = f.textBox_correu.Text,
                        aforament = int.Parse(f.textBox_aforament.Text),
                        tipusCuinaId = ((TipusCuina)f.comboBox_tipuscuina.SelectedItem).id,
                        tipusPreuId = ((TipusPreu)f.comboBox_tipuspreu.SelectedItem).id,
                        valoraciomedia = 0,
                        descripcio = f.textBox_descripcio.Text,
                        paginaWeb = f.textBox_paginaweb.Text,
                        logo = logoByteArray
                    };

                    bool resultatRegistre = _authService.RegistreRestaurant(newRestaurant);

                    if (resultatRegistre)
                    {
                        f.textBox_usuariRegis.Clear();
                        f.textbox_contrasenyaRegis.Clear();
                        f.textBox_nom.Clear();
                        f.textBox_pais.Clear();
                        f.textBox_poblacio.Clear();
                        f.textBox_codipostal.Clear();
                        f.textBox_carrer.Clear();
                        f.textBox_telefon.Clear();
                        f.textBox_correu.Clear();
                        f.textBox_aforament.Clear();
                        f.textBox_descripcio.Clear();
                        f.textBox_paginaweb.Clear();
                        f.comboBox_tipuscuina.SelectedItem = null;
                        f.comboBox_tipuspreu.SelectedItem = null;
                        f.pictureBox_logo.Image = null;

                        MessageBox.Show("Restaurant registrat amb exit, ja pots iniciar sessio.", "Registre exitos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ja existeix aquest nom d'usuari, prova un altre.", "Nom existent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Completi tots els camps requerits.", "Camps incomplerts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar restaurant." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arxius d'imatge|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Seleccioni el logo del restaurant";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                logo = Image.FromFile(openFileDialog.FileName);

                if (logo.Width <= 150 && logo.Height <= 150)
                {
                    f.pictureBox_logo.Image = logo;
                }
                else
                {
                    MessageBox.Show("El logo ha de tenir un màxim de 150x150 píxels.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private byte[] ImageToByteArray(Image logo)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                logo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
