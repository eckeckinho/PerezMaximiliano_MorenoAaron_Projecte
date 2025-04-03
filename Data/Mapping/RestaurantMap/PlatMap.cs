using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping.RestaurantMap
{
    public class PlatMap : IEntityTypeConfiguration<Plat>
    {
        public void Configure(EntityTypeBuilder<Plat> builder)
        {
            builder.ToTable("Plat").HasKey(u => u.id);
        }
    }
}
