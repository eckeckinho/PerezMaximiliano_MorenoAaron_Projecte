using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Services;
using Reserves.Controller;
using Taules.Controller;
using Contacte.Controller;
using Configuracio.Controller;
using Horari.Controller;
using Services.Interfaces;

namespace PerezMaximiliano_MorenoAaron_Projecte
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crea una nueva colección de servicios. Esto es el contenedor de dependencias.

            var services = new ServiceCollection();

            // Aquí se agregan los servicios necesarios para la aplicación,
            // como el contexto de base de datos, servicios y controladores.

            services.AddProjectServices();

            // Registra los controladores para que puedan ser inyectados en otros lugares.
            // Estos son los controladores que gestionan la lógica de la UI.

            services.AddScoped<EntrarController>();
            services.AddScoped<RegistrarController>();
            services.AddScoped<ReservesController>();
            services.AddScoped<TaulesController>();
            services.AddScoped<ContacteController>();
            services.AddScoped<ConfiguracioController>();
            services.AddScoped<HorariController>();

            // Construye el proveedor de servicios a partir de la colección de servicios.
            // El proveedor de servicios es responsable de crear instancias de los servicios y controladores.

            using (var serviceProvider = services.BuildServiceProvider())
            {
                // Solicita el servicio de EntrarController, que es el controlador principal de la vista de "entrar" en la aplicación.
                // Aquí se usa GetRequiredService para asegurarse de que se obtenga la instancia de EntrarController correctamente.

                serviceProvider.GetRequiredService<EntrarController>();
            }

            Application.Run();
        }
    }
}
