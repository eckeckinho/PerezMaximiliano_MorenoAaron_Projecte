using Entitats.AuthClasses;
using Entitats.ContacteClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings.AuthMap
{
    public class UsuariMap : IEntityTypeConfiguration<Usuari>
    {
        public void Configure(EntityTypeBuilder<Usuari> builder)
        {
            builder.ToTable("Usuari").HasKey(u => u.id);
        }
    }
} 