using Microsoft.EntityFrameworkCore;
using Peliculas.API.Entities;
using Peliculas.API.Entities.Seeding;
using System.Reflection;

namespace Peliculas.API.Contextos
{
    public class PeliculasDbContext : DbContext
    {
        public PeliculasDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Cine> Cine { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<CineOferta> CineOferta { get; set; }
        public DbSet<SalaCine> SalaCine { get; set; }
        public DbSet<PeliculaActor> PeliculaActor { get; set; }

        // para configurar el api fluent
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // para poder poner el api fluent en archivos separados
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingModuleConsulta.seed(modelBuilder);

        }
    }
}
