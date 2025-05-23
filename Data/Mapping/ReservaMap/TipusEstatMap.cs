﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entitats.ReservaClasses;

namespace Data.Mapping.ReservaMap
{
    public class TipusEstatMap : IEntityTypeConfiguration<TipusEstat>
    {
        public void Configure(EntityTypeBuilder<TipusEstat> builder)
        {
            builder.ToTable("TipusEstat").HasKey(x => x.id);
        }
    }
}
