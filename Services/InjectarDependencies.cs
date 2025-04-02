using Microsoft.Extensions.DependencyInjection;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces;
using PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Services
{
    public static class InjectarDependencies
    {
        public static IServiceCollection AddProjectServicesRegistre(this IServiceCollection services)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=MorenoAaron_PerezMaximiliano_ProjecteFinal;Trusted_Connection=True;TrustServerCertificate=True;";

            services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITipusService, TipusService>();

            return services;
        }
    }
}
