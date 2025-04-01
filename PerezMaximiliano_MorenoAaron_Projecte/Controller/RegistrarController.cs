using Entitats.Auth;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerezMaximiliano_MorenoAaron_Projecte
{
    public class RegistrarController
    {
        RegistrarRestaurantForm f = new RegistrarRestaurantForm();
        Bitmap imgTemp;
        private readonly IAuthService _authService;

        public RegistrarController(IAuthService authService) 
        {
            _authService = authService;
            SetListeners();
            f.ShowDialog();
        }

        private void SetListeners()
        {
            f.button_logo.Click += Button_logo_Click;
            f.button_registrar.Click += Button_registrar_Click;
        }

        private void Button_registrar_Click(object sender, EventArgs e)
        {
            Restaurant newRestaurant = new Restaurant
            {
                nomCompte = f.textBox_usuari.Text,
                contrasenyaCompte = f.textBox_contrasenya.Text,
                nomRestaurant = f.textBox_nom.Text,
                pais = f.textBox_provincia.Text,
                ciutat = f.textBox_poblacio.Text,
                codiPostal = f.textBox_codipostal.Text,
                carrer = f.textBox_carrer.Text,
                telefon = f.textBox_telefon.Text,
                correu = f.textBox_correu.Text,
                aforament = int.Parse(f.textBox_aforament.Text),
                //tipusCuinaId = (f.comboBox_tipuscuina.SelectedItem as TipusCuina)?.Id, 
                //tipusPreuId = (f.comboBox_tipuspreu.SelectedItem as TipusPreu)?.Id
            };

             _authService.RegistreRestaurantAsync(newRestaurant);
        }

        private void Button_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Seleccione el logo del restaurante";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgTemp = new Bitmap(openFileDialog.FileName);

                if (imgTemp.Width == 150 && imgTemp.Height == 150)
                {
                    f.pictureBox_logo.Image = imgTemp; 
                }
                else
                {
                    MessageBox.Show("El logo debe tener exactamente 150x150 píxeles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void SetListeners()
        {
            r.button_logo.Click += Button_logo_Click;
        }

        private void Button_logo_Click(object sender, EventArgs e)
        {

        }
    }
}
