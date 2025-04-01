using Data.Mapping.RestaurantMap;
using Data.Mappings.AuthMap;
using Entitats.AuthClasses;
using Entitats.RestaurantClasses;
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
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Usuari> Usuaris { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<TipusCuina> TipusCuinas { get; set; }
        public DbSet<TipusPreu> TipusPreus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariMap());
            modelBuilder.ApplyConfiguration(new RestaurantMap());
            modelBuilder.ApplyConfiguration(new TipusCuinaMap());
            modelBuilder.ApplyConfiguration(new TipusPreuMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
