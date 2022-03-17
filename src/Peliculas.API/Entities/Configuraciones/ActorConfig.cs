using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Peliculas.API.Entities.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Actor").HasComment("Catalogo de Actores");

            builder.HasIndex(x => x.Nombre, "Ix_ActorNomDup").IsUnique();

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del Actor");

            builder.Property(x => x.Biografia)
                .HasComment("Biografia de Actor");

            builder.Property(x => x.FechaNacimiento)
                .HasColumnType("date")
                .HasComment("Fecha de Nacimiento del Actor");
        }
    }
}
