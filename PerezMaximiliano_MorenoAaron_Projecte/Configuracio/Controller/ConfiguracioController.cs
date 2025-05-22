using Entitats.RestaurantClasses;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services.Interfaces;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Taules.View;

namespace Configuracio.Controller
{
    public class ConfiguracioController
    {
        private MenuForm fm;
        NovaContrasenyaForm fn;
        Image logo;
        Image imatgeRestaurant;
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

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }

        private void SetListeners()
        {
            fm.buttonConfiguracio_editar.Click += Button_editar_click;
            fm.buttonConfiguracio_newContrasenya.Click += Button_newContrasenya_click;
            fn.materialCheckboxConfiguracio_veureContrasenyaNova.CheckedChanged += MaterialCheckbox_veureContrasenyaNova_CheckedChanged;
            fn.materialCheckboxConfiguracio_veureContrasenyaRepetir.CheckedChanged += MaterialCheckbox_veureContrasenyaRepetir_CheckedChanged;
            fn.buttonConfiguracio_canviarContrasenya.Click += ButtonConfiguracio_canviarContrasenya_Click;
            fm.buttonConfiguracio_logo.Click += ButtonConfiguracio_logo_Click;
            fm.buttonConfiguracio_imatgeRestaurant.Click += ButtonConfiguracio_imatgeRestaurant_Click;
        }

        private void LoadData()
        {
            Restaurant restaurant = _configuracioService.GetRestaurantConfig();

            fm.comboBoxConfiguracio_tipuscuina.DataSource = _tipusService.GetTipusCuines();
            fm.comboBoxConfiguracio_tipuscuina.DisplayMember = "descripcio";
            fm.comboBoxConfiguracio_tipuscuina.ValueMember = "id";
            fm.comboBoxConfiguracio_tipuspreu.DataSource = _tipusService.GetTipusPreus();
            fm.comboBoxConfiguracio_tipuspreu.DisplayMember = "descripcio";
            fm.comboBoxConfiguracio_tipuspreu.ValueMember = "id";

            if (restaurant != null)
            {
                SetRestaurantData(restaurant);
            }
            else
            {
                MessageBox.Show("No s'ha pogut carregar la configuració del restaurant.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Carregar la configuració del restaurant
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
            fm.pictureBoxConfiguracio_logo.Image = AjustarImatge(ByteArrayToImage(restaurant.logo), 150, 150);
            fm.pictureBoxConfiguracio_imatgeRestaurant.Image = AjustarImatge(ByteArrayToImage(restaurant.imatgeRestaurant), 500, 300);
        }

        // Actualitzar la configuració del restaurant
        private void Button_editar_click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_usuari.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_nom.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_pais.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_poblacio.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_codipostal.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_carrer.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_telefon.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_correu.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_aforament.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_descripcio.Text) &&
                 !string.IsNullOrWhiteSpace(fm.textBoxConfiguracio_paginaweb.Text))
                {
                    if (!int.TryParse(fm.textBoxConfiguracio_aforament.Text, out int aforament))
                    {
                        MessageBox.Show("El camp 'Aforament' ha de ser un número enter.", "Valor no vàlid.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (fm.textBoxConfiguracio_usuari.Text.Contains(" "))
                    {
                        MessageBox.Show("El nom d'usuari no pot contenir espais.", "Usuari no vàlid.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    byte[] logoByteArray = null;
                    if (logo != null)
                    {
                        logoByteArray = ImageToByteArray(logo);
                    }
                    else if (fm.pictureBoxConfiguracio_logo.Image != null)
                    {
                        logoByteArray = ImageToByteArray(fm.pictureBoxConfiguracio_logo.Image);
                    }
                    else
                    {
                        MessageBox.Show("Afegeix un logotip pel teu restaurant.", "Logo necessari.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    byte[] imatgeRestaurantByteArray = null;
                    if (imatgeRestaurant != null)
                    {
                        imatgeRestaurantByteArray = ImageToByteArray(imatgeRestaurant);
                    }
                    else if (fm.pictureBoxConfiguracio_imatgeRestaurant.Image != null)
                    {
                        imatgeRestaurantByteArray = ImageToByteArray(fm.pictureBoxConfiguracio_imatgeRestaurant.Image);
                    }
                    else
                    {
                        MessageBox.Show("Afegeix una imatge del teu restaurant.", "Imatge del restaurant necessària.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    Restaurant updateRestaurant = new Restaurant
                    {
                        nomCompte = fm.textBoxConfiguracio_usuari.Text,
                        nomRestaurant = fm.textBoxConfiguracio_nom.Text,
                        pais = fm.textBoxConfiguracio_pais.Text,
                        ciutat = fm.textBoxConfiguracio_poblacio.Text,
                        codiPostal = fm.textBoxConfiguracio_codipostal.Text,
                        carrer = fm.textBoxConfiguracio_carrer.Text,
                        telefon = fm.textBoxConfiguracio_telefon.Text,
                        correu = fm.textBoxConfiguracio_correu.Text,
                        aforament = aforament,
                        tipusCuinaId = ((TipusCuina)fm.comboBoxConfiguracio_tipuscuina.SelectedItem).id,
                        tipusPreuId = ((TipusPreu)fm.comboBoxConfiguracio_tipuspreu.SelectedItem).id,
                        descripcio = fm.textBoxConfiguracio_descripcio.Text,
                        paginaWeb = fm.textBoxConfiguracio_paginaweb.Text,
                        logo = logoByteArray,
                        imatgeRestaurant = imatgeRestaurantByteArray
                    };

                    bool resultatUpdate = _configuracioService.UpdateRestaurant(updateRestaurant);

                    if (resultatUpdate)
                    {
                        MessageBox.Show("Restaurant modificat amb èxit.", "Modificació realitzada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Aquest nom d'usuari ja està en ús, prova un altre.", "Nom d'usuari existent.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Completi tots els camps requerits.", "Camps incomplerts.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el restaurant." + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Abrir el formulari de canvi de contrasenya
        private void Button_newContrasenya_click(object sender, EventArgs e)
        {
            fn.ShowDialog();
        }

        // Canviar la contrasenya del restaurant
        private void ButtonConfiguracio_canviarContrasenya_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fn.textBoxConfiguracio_novaContrasenya.Text) && !string.IsNullOrEmpty(fn.textBoxConfiguracio_repetirContrasenya.Text))
            {
                if (fn.textBoxConfiguracio_novaContrasenya.Text.Equals(fn.textBoxConfiguracio_repetirContrasenya.Text))
                {
                    var respostaCanviContrasenya = _configuracioService.CanviarContrasenyaRestaurant(fn.textBoxConfiguracio_novaContrasenya.Text);

                    if (respostaCanviContrasenya)
                    {
                        MessageBox.Show("Contrasenya canviada correctament.", "Contrasenya canviada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fn.textBoxConfiguracio_repetirContrasenya.Text = "";
                        fn.textBoxConfiguracio_novaContrasenya.Text = "";
                        fn.Close();
                    } else
                    {
                        MessageBox.Show("Error canviant la contrasenya.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else
                {
                    MessageBox.Show("Les contrasenyes no coincideixen.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else
            {
                MessageBox.Show("Insereix una contrasenya nova.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Mostrar / ocultar la contrasenya del textbox de la password nova o repetida
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

        // Seleccionar el logo del restaurant
        private void ButtonConfiguracio_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arxius d'imatge|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Seleccioni el logo del restaurant";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                logo = Image.FromFile(openFileDialog.FileName);

                Image logoAjustat = AjustarImatge(logo, 150, 150);
                fm.pictureBoxConfiguracio_logo.Image = logoAjustat;
            }
        }

        private void ButtonConfiguracio_imatgeRestaurant_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arxius d'imatge|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Seleccioni la imatge del restaurant";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imatgeRestaurant = Image.FromFile(openFileDialog.FileName);

                Image imatgeRestaurantAjustada = AjustarImatge(imatgeRestaurant, 500, 300);
                fm.pictureBoxConfiguracio_imatgeRestaurant.Image = imatgeRestaurantAjustada;
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


        // Convertir imatge a byte array i viceversa
        private Image ByteArrayToImage(byte[] imatge)
        {
            if (imatge != null && imatge.Length > 0)
            {
                using (var ms = new MemoryStream(imatge))
                {
                    return Image.FromStream(ms);
                }
            }
            else
            {
                return null;
            }
        }

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
