using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entitats.RestaurantClasses;

namespace Data.Mapping.RestaurantMap
{
    public class RestaurantMap : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurant").HasKey(u => u.id);
        }
    }
}
