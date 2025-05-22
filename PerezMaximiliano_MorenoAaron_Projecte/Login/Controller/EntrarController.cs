using Configuracio.Controller;
using Contacte.Controller;
using Entitats.RestaurantClasses;
using MenuPlats.Controller;
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
        Image imatgeRestaurant;
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
            f.button_imatgeRestaurant.Click += Button_imatgeRestaurant_Click;
            f.button_registrar.Click += Button_registrar_Click;
            f.materialCheckboxEntrar_veureContrasenya.CheckedChanged += CheckboxEntrar_veureContrasenya_CheckedChanged;
            f.materialCheckboxRegistrar_veureContrasenya.CheckedChanged += CheckboxRegistrar_veureContrasenya_CheckedChanged;
        }

        private void SetListenersMenu()
        {
            fm.materialTabControl.SelectedIndexChanged += MaterialTabControl1_SelectedIndexChanged;
            fm.buttonMain_tancarSessio.Click += ButtonMain_tancarSessio_Click;
        }

        // Reiniciar app en caso de cerrar sesión
        private void ButtonMain_tancarSessio_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        // Controla los tabs para que al hacer click se instancie el controlador correspondiente
        private void MaterialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = fm.materialTabControl.SelectedIndex;
            string tabName = fm.materialTabControl.TabPages[selectedIndex].Name;

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
                case "tabPagePlats":
                    var platsController = _serviceProvider.GetRequiredService<PlatsController>();
                    platsController.SetForm(fm);
                    platsController.Inicialitzar();
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
                // Setteamos el restaurante el cual ha realizado login correctamente para poderlo usar en todos los controladores de la aplicacion
                var contextRest = _serviceProvider.GetRequiredService<IRestaurantContext>();
                contextRest.restaurantActual = restaurant;

                // Instanciamos el controlador de la primera vista
                var reservesController = _serviceProvider.GetRequiredService<ReservesController>();
                reservesController.SetForm(fm);
                reservesController.Inicialitzar();

                // Gestionar los forms correspondientes
                f.Hide();
                fm.Text = $"Benvingut, {restaurant.nomCompte}!";
                SetListenersMenu();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuari o contrasenya incorrectes.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Registrar restaurant
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
                    if (!int.TryParse(f.textBox_aforament.Text, out int aforament))
                    {
                        MessageBox.Show("El camp 'Aforament' ha de ser un número enter.", "Valor no vàlid.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (f.textBox_usuariRegis.Text.Contains(" "))
                    {
                        MessageBox.Show("El nom d'usuari no pot contenir espais.", "Usuari no vàlid.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    byte[] logoByteArray = null;
                    if (logo != null)
                    {
                        logoByteArray = ImageToByteArray(logo);
                    } else
                    {
                        MessageBox.Show("Afegeix un logotip pel teu restaurant.", "Logo necessari.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    byte[] imatgeRestaurantByteArray = null;
                    if (imatgeRestaurant != null)
                    {
                        imatgeRestaurantByteArray = ImageToByteArray(imatgeRestaurant);
                    } else
                    {
                        MessageBox.Show("Afegeix una imatge del teu restaurant.", "Imatge del restaurant necessària.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                        Restaurant newRestaurant = new Restaurant
                        {
                            nomCompte = f.textBox_usuariRegis.Text,
                            // Hashear la contrasenya
                            contrasenyaCompte = BCrypt.Net.BCrypt.HashPassword(f.textbox_contrasenyaRegis.Text),
                            nomRestaurant = f.textbox_contrasenyaRegis.Text,
                            pais = f.textBox_pais.Text,
                            ciutat = f.textBox_poblacio.Text,
                            codiPostal = f.textBox_codipostal.Text,
                            carrer = f.textBox_carrer.Text,
                            telefon = f.textBox_telefon.Text,
                            correu = f.textBox_correu.Text,
                            aforament = aforament,
                            tipusCuinaId = ((TipusCuina)f.comboBox_tipuscuina.SelectedItem).id,
                            tipusPreuId = ((TipusPreu)f.comboBox_tipuspreu.SelectedItem).id,
                            valoraciomedia = 0,
                            descripcio = f.textBox_descripcio.Text,
                            paginaWeb = f.textBox_paginaweb.Text,
                            logo = logoByteArray,
                            imatgeRestaurant = imatgeRestaurantByteArray
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
                        f.pictureBox_logo.Image = null;
                        f.pictureBox_imatgeRestaurant.Image = null;
                        LoadData();

                        MessageBox.Show("Restaurant registrat amb èxit, ja pots iniciar sessió.", "Registre completat.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Aquest nom d'usuari o correu electrònic ja està en ús, prova un altre.", "Identitat existent.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Completi tots els camps requerits.", "Camps incomplerts.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar restaurant." + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Mostrar contrassenya de la vista registrar
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

        // Mostrar contrassenya de la vista login
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

        // Insertar logo del restaurant
        private void Button_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arxius d'imatge|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Seleccioni el logo del restaurant";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                logo = Image.FromFile(openFileDialog.FileName);

                Image logoAjustat = AjustarImatge(logo, 150, 150);
                f.pictureBox_logo.Image = logoAjustat;
            }
        }

        // Insertar imatge del restaurant
        private void Button_imatgeRestaurant_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arxius d'imatge|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Seleccioni la imatge del restaurant";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imatgeRestaurant = Image.FromFile(openFileDialog.FileName);

                Image imatgeRestaurantAjustada = AjustarImatge(imatgeRestaurant, 500, 300);
                f.pictureBox_imatgeRestaurant.Image = imatgeRestaurantAjustada;
            }
        }

        private Image AjustarImatge(Image original, int maxWidth, int maxHeight)
        {
            // Calcular tamaño escalado manteniendo proporciones
            double ratioX = (double)maxWidth / original.Width;
            double ratioY = (double)maxHeight / original.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(original.Width * ratio);
            int newHeight = (int)(original.Height * ratio);

            // Crear imagen final del tamaño deseado
            Bitmap finalImage = new Bitmap(maxWidth, maxHeight);
            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.Transparent);

                // Calcular posición centrada
                int posX = (maxWidth - newWidth) / 2;
                int posY = (maxHeight - newHeight) / 2;

                // Dibujar imagen escalada en el centro
                g.DrawImage(original, posX, posY, newWidth, newHeight);
            }

            return finalImage;
        }

        // Convertir imatge a byte array
        private byte[] ImageToByteArray(Image imatge)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imatge.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
