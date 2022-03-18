using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Peliculas.API.Entities.Configuraciones
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Cine").HasComment("Catalogo de Cines");

            builder.HasIndex(x => x.Nombre, "Ix_CineNomDup").IsUnique();

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del Cine");
        }
    }
}
