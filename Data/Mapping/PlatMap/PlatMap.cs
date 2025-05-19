using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entitats.PlatClasses;

namespace Data.Mapping.PlatMap
{
    public class PlatMap : IEntityTypeConfiguration<Plat>
    {
        public void Configure(EntityTypeBuilder<Plat> builder)
        {
            builder.ToTable("Plat").HasKey(u => u.id);
        }
    }
}
