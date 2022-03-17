using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Peliculas.API.Entities.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Genero").HasComment("Catalogo de Generos");

            builder.HasIndex(x => x.Nombre, "Ix_GeneroNomDupl").IsUnique();

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del Genero");

        }
    }
}
