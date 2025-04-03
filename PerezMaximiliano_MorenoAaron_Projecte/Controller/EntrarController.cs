using Configuracio.Controller;
using Contacte.Controller;
using Entitats.RestaurantClasses;
using Horari.Controller;
using Microsoft.Extensions.DependencyInjection;
using PerezMaximiliano_MorenoAaron_Projecte;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;
using Reserves.Controller;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taules.Controller;

namespace PerezMaximiliano_MorenoAaron_Projecte
{
    public class EntrarController
    {
        IniciarSessioForm f1;
        MenuForm fm;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        private readonly ITipusService _tipusService;

        public EntrarController(IAuthService authService, ITipusService tipusService, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _authService = authService;
            _tipusService = tipusService;
            f1 = new IniciarSessioForm();
            fm = new MenuForm();

            SetListeners();
            f1.ShowDialog();
        }

        private void SetListeners()
        {
            f1.button_entrar.Click += Button_entrar_Click;
            f1.button_regisrest.Click += Button_regisrest_Click;
        }

        private void SetListenersMenu()
        {
            fm.button_reserves.Click += Button_reserves_Click;
            fm.button_taules.Click += Button_taules_Click;
            fm.button_contacte.Click += Button_contacte_Click;
            fm.button_configuracio.Click += Button_configuracio_Click;
            fm.button_horari.Click += Button_horari_Click;
        }

        private void Button_horari_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<HorariController>();

        }

        private void Button_configuracio_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<ConfiguracioController>();

        }

        private void Button_contacte_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<ContacteController>();

        }

        private void Button_taules_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<TaulesController>();

        }

        private void Button_reserves_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<ReservesController>();

        }

        private void Button_regisrest_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<RegistrarController>();
        }

        private async void Button_entrar_Click(object sender, EventArgs e)
        {
            var nomUsuariRest = f1.textBox_usuari.Text;
            var pswdUsuariRest = f1.textBox_contrasenya.Text;

            var (resultatLogin, restaurant) = await _authService.LoginRestaurantAsync(nomUsuariRest, pswdUsuariRest);

            if (resultatLogin)
            {
                f1.Hide();
                MessageBox.Show($"Benvingut, {restaurant.nomCompte}!", "Login realitzat amb exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetListenersMenu();
                LoadDataMenu(restaurant);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuari o contrasenya incorrectes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataMenu(Restaurant restaurant)
        {
            fm.label_nomrestaurant.Text = restaurant.nomRestaurant;

            if (restaurant.logo != null && restaurant.logo.Length > 0)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream(restaurant.logo))
                    {
                        fm.pictureBox_logo.Image = System.Drawing.Image.FromStream(ms);  
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al carregar l'imagte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                fm.pictureBox_logo.Image = null; 
            }
        }

    }
}
