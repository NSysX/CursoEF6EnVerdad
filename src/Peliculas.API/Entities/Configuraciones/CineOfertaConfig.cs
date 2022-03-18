using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Peliculas.API.Entities.Configuraciones
{
    public class CineOfertaConfig : IEntityTypeConfiguration<CineOferta>
    {
        public void Configure(EntityTypeBuilder<CineOferta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("CineOferta").HasComment("Catalogo de ofertas por cine");

            builder.HasIndex(x => x.CineId, "Ix_CineOfertaCinDup").IsUnique();

            builder.Property(x => x.FechaInicio)
                .IsRequired()
                .HasColumnType("date");
            
            builder.Property(x => x.FechaFin)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.PorcentajeDescuento)
                .HasPrecision(5, 2);
        }
    }
}
