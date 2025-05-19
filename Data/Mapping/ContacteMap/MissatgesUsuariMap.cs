using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entitats.ContacteClasses;

namespace Data.Mapping.ContacteClasses
{
    public class MissatgesUsuariMap : IEntityTypeConfiguration<MissatgesUsuari>
    {
        public void Configure(EntityTypeBuilder<MissatgesUsuari> builder)
        {
            builder.ToTable("MissatgesUsuari").HasKey(u => u.id);
        }
    }
}
