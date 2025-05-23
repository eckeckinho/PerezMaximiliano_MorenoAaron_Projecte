﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entitats.RestaurantClasses;

namespace Data.Mapping.RestaurantMap
{
    public class TipusCuinaMap : IEntityTypeConfiguration<TipusCuina>
    {
        public void Configure(EntityTypeBuilder<TipusCuina> builder)
        {
            builder.ToTable("TipusCuina").HasKey(x => x.id);
        }
    }
}
