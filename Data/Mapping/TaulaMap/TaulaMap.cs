using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entitats.TaulaClasses;

namespace Data.Mapping.TaulaMap
{
    public class TaulaMap : IEntityTypeConfiguration<Taula>
    {
        public void Configure(EntityTypeBuilder<Taula> builder)
        {
            builder.ToTable("Taula").HasKey(x => x.id);
        }
    }
}
