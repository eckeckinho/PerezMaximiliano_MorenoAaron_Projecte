using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entitats.PlatClasses;

namespace Data.Mapping.PlatMap
{
    public class TipusPlatMap : IEntityTypeConfiguration<TipusPlat>
    {
        public void Configure(EntityTypeBuilder<TipusPlat> builder)
        {
            builder.ToTable("TipusPlat").HasKey(x => x.id);
        }
    }
}
