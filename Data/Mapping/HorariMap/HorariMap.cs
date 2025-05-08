using Entitats.PlatClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entitats.HorariClasses;

namespace Data.Mapping.HorariMap
{
    public class HorariMap : IEntityTypeConfiguration<Horari>
    {
        public void Configure(EntityTypeBuilder<Horari> builder)
        {
            builder.ToTable("Horari").HasKey(u => u.id);
        }
    }
}
