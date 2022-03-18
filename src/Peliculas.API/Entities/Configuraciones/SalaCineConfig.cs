using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peliculas.API.Enums;

namespace Peliculas.API.Entities.Configuraciones
{
    public class SalaCineConfig : IEntityTypeConfiguration<SalaCine>
    {
        public void Configure(EntityTypeBuilder<SalaCine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("SalaCine").HasComment("Salas de cine");

            builder.HasIndex(x => new { x.Id, x.CineId }, "Ix_SalaCineNoDup").IsUnique();

            builder.Property(x => x.Precio)
                    .HasPrecision(9, 2)
                    .HasComment("El precio de la sala del cine");

            builder.Property(x => x.CineId)
                .IsRequired()
                .HasComment("El id Consecutivo de la tabla cine");

            builder.Property(x => x.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones);
        }
    }
}
