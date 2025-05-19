using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entitats.HorariClasses;

namespace Data.Mapping.HorariExcepcionsMap
{
    public class HorariExcepcionsMap : IEntityTypeConfiguration<HorariExcepcions>
    {
        public void Configure(EntityTypeBuilder<HorariExcepcions> builder)
        {
            builder.ToTable("HorariExcepcions").HasKey(u => u.id);
        }
    }
}
