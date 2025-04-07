using BCrypt.Net;
using Entitats.RestaurantClasses;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;
using Reserves;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerezMaximiliano_MorenoAaron_Projecte
{
    public class RegistrarController
    {
        RegistrarRestaurantForm f;
        Image logo;
        private readonly IAuthService _authService;
        private readonly ITipusService _tipusService;
        public RegistrarController(IAuthService authService, ITipusService tipusService)
        {
            _authService = authService;
            _tipusService = tipusService;
        }

        public void ShowForm()
        {
            f = new RegistrarRestaurantForm();
            SetListeners();
            LoadData();
            f.ShowDialog();
        }

        private async void LoadData()
        {
            f.comboBox_tipuscuina.DataSource = await _tipusService.GetTipusCuines(); 
            f.comboBox_tipuscuina.DisplayMember = "descripcio";
            f.comboBox_tipuspreu.DataSource = await _tipusService.GetTipusPreus(); 
            f.comboBox_tipuspreu.DisplayMember = "descripcio";
        }


        private void SetListeners()
        {
            f.button_logo.Click += Button_logo_Click;
            f.button_registrar.Click += Button_registrar_Click;
        }

        private async void Button_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(f.textBox_usuari.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_contrasenya.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_nom.Text) &&
                !string.IsNullOrWhiteSpace(f.textBox_provincia.Text) &&
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
                        nomCompte = f.textBox_usuari.Text,
                        contrasenyaCompte = BCrypt.Net.BCrypt.HashPassword(f.textBox_contrasenya.Text),
                        nomRestaurant = f.textBox_nom.Text,
                        pais = f.textBox_provincia.Text,
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

                    bool resultatRegistre = await _authService.RegistreRestaurantAsync(newRestaurant);

                    if (resultatRegistre)
                    {
                        f.textBox_usuari.Clear();
                        f.textBox_contrasenya.Clear();
                        f.textBox_nom.Clear();
                        f.textBox_provincia.Clear();
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
                    } else
                    {
                        MessageBox.Show("Ja existeix aquest nom d'usuari, prova un altre.", "Nom existent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Completi tots els camps requerits.", "Camps incomplerts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex)
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

                if (logo.Width == 150 && logo.Height == 150)
                {
                    f.pictureBox_logo.Image = logo;
                }
                else
                {
                    MessageBox.Show("El logo ha de ser exactament 150x150 pixels.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        //public string HashPassword(string password)
        //{
        //    return BCrypt.HashPassword(password);
        //}
    }
}
