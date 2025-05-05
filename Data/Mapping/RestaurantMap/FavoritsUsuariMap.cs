using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping.RestaurantMap
{
    public class FavoritsUsuariMap : IEntityTypeConfiguration<FavoritsUsuari>
    {
        public void Configure(EntityTypeBuilder<FavoritsUsuari> builder)
        {
            builder.ToTable("FavoritsUsuari").HasKey(u => u.id);
        }
    }
}
