using Entitats.RestaurantClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping.RestaurantMap
{
    public class TipusPlatMap : IEntityTypeConfiguration<TipusPlat>
    {
        public void Configure(EntityTypeBuilder<TipusPlat> builder)
        {
            builder.ToTable("TipusPlat").HasKey(x => x.id);
        }
    }
}
