using Data.Mapping.ContacteClasses;
using Data.Mapping.PlatMap;
using Data.Mapping.ReservaMap;
using Data.Mapping.RestaurantMap;
using Data.Mapping.TaulaMap;
using Data.Mappings.AuthMap;
using Entitats.AuthClasses;
using Entitats.ContacteClasses;
using Entitats.PlatClasses;
using Entitats.ReservaClasses;
using Entitats.RestaurantClasses;
using Entitats.TaulaClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Usuari> Usuaris { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<TipusCuina> TipusCuinas { get; set; }
        public DbSet<TipusPreu> TipusPreus { get; set; }
        public DbSet<Plat> Plats { get; set; }
        public DbSet<TipusPlat> TipusPlats { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipusEstat> TipusEstats { get; set; }
        public DbSet<Taula> Taules { get; set; }
        public DbSet<MissatgesUsuari> MissatgesUsuaris { get; set; }
        public DbSet<MissatgesView> MissatgesView { get; set; }
        public DbSet<FavoritsUsuari> FavoritsUsuaris { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariMap());
            modelBuilder.ApplyConfiguration(new RestaurantMap());
            modelBuilder.ApplyConfiguration(new TipusCuinaMap());
            modelBuilder.ApplyConfiguration(new TipusPreuMap());
            modelBuilder.ApplyConfiguration(new PlatMap());
            modelBuilder.ApplyConfiguration(new TipusPlatMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());
            modelBuilder.ApplyConfiguration(new TipusEstatMap());
            modelBuilder.ApplyConfiguration(new TaulaMap());
            modelBuilder.ApplyConfiguration(new MissatgesUsuariMap());
            modelBuilder.ApplyConfiguration(new MissatgesViewMap());
            modelBuilder.ApplyConfiguration(new FavoritsUsuariMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
