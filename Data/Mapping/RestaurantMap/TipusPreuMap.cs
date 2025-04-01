using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entitats.RestaurantClasses;

namespace Data.Mapping.RestaurantMap
{
    public class TipusPreuMap : IEntityTypeConfiguration<TipusPreu>
    {
        public void Configure(EntityTypeBuilder<TipusPreu> builder)
        {
            builder.ToTable("TipusPreu").HasKey(x => x.id);
        }
    }
}
