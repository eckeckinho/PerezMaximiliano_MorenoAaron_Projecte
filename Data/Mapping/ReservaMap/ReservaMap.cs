using Entitats.ReservaClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Mapping.ReservaMap
{
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva").HasKey(x => x.id);
        }
    }
}
