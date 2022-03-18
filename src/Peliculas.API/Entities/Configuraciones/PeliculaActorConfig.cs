using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Peliculas.API.Entities.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(x => new { x.PeliculaId, x.ActorId });

            builder.ToTable("PeliculaActor").HasComment("Relacion entre las tablas Pelicula y Actor");

            builder.Property(x => x.Personaje)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del personale");

            builder.Property(x => x.Orden)
                .HasComment("El orden de importancia del persionaje");
        }
    }
}
