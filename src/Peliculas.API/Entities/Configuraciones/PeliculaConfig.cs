using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Peliculas.API.Entities.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Pelicula").HasComment("Catalogo de Peliculas");

            builder.HasIndex(x => x.Titulo, "Ix_PelTituloDup").IsUnique();

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Titulo de la Pelicula");

            builder.Property(x => x.EnCartelera)
                .HasComment("Si esta en Cartelera");

            builder.Property(x => x.FechaEstreno)
                .HasColumnType("date")
                .HasComment("Fecha de Estreno");

            builder.Property(x => x.PosterURL)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("URL de la imagen del Poster");

        }
    }
}
