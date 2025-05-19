using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entitats.RessenyaClasses;

namespace Data.Mapping.RessenyaMap
{
    public class RessenyaMap : IEntityTypeConfiguration<Ressenya>
    {
        public void Configure(EntityTypeBuilder<Ressenya> builder)
        {
            builder.ToTable("Ressenya").HasKey(x => x.id);
        }
    }
}
