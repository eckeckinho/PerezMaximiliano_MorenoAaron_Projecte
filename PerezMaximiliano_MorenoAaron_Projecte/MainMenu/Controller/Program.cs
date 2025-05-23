﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Services;
using Reserves.Controller;
using Contacte.Controller;
using Configuracio.Controller;
using Taules.Controller;
using MenuPlats.Controller;

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

            // Aquí se agregan los servicios necesarios para la aplicación, como el contexto de base de datos, servicios y controladores.

            services.AddProjectServices();

            // Registra los controladores para que puedan ser inyectados en otros lugares.

            services.AddScoped<EntrarController>();
            services.AddScoped<ReservesController>();
            services.AddScoped<TaulesController>();
            services.AddScoped<HorariController>();
            services.AddScoped<ContacteController>();
            services.AddScoped<ConfiguracioController>();
            services.AddScoped<PlatsController>();

            // Construye el proveedor de servicios a partir de la colección de servicios. (es responsable de crear instancias de los servicios y controladores)

            using (var serviceProvider = services.BuildServiceProvider())
            {
                // Solicita el servicio de EntrarController (Obtiene la instancia de EntrarController correctamente).

                serviceProvider.GetRequiredService<EntrarController>();
            }

            Application.Run();
        }
    }
}
