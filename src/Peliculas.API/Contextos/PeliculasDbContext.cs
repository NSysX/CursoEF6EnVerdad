using Microsoft.EntityFrameworkCore;
using Peliculas.API.Entities;
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


        // para configurar el api fluent
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // para poder poner el api fluent en archivos separados
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
