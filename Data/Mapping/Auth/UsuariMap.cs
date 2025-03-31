using Entitats.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings.Auth
{
    public class UsuariMap : IEntityTypeConfiguration<Usuari>
    {
        public void Configure(EntityTypeBuilder<Usuari> builder)
        {
            builder.ToTable("Usuari").HasKey(u => u.id);
        }
    }
} 