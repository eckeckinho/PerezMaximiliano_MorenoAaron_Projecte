using Microsoft.Extensions.DependencyInjection;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Data;

namespace Services
{
    public static class InjectarDependencies
    {
        // Configuració de la connexió a la base de dades i injecció de dependències
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=MorenoAaron_PerezMaximiliano_ProjecteFinal;Trusted_Connection=True;TrustServerCertificate=True;";

            services.AddDbContext<DBContext>(options =>options.UseSqlServer(connectionString));

            services.AddScoped<IRestaurantContext, RestaurantContext>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITipusService, TipusService>();
            services.AddScoped<IReservaService, ReservaService>();
            services.AddScoped<ITaulaService, TaulaService>();
            services.AddScoped<IContacteService, ContacteService>();
            services.AddScoped<IHorariService, HorariService>();
            services.AddScoped<IConfiguracioService, ConfiguracioService>();
            services.AddScoped<IUsuariService, UsuariService>();

            return services;
        }
    }
}
