using Microsoft.EntityFrameworkCore;
using Peliculas.API.Contextos;

namespace Peliculas.API
{
    public static class ServiciosDeExtension
    {
        public static void AgregaContexto(this IServiceCollection services, IConfiguration configuration)
        {
            string cadenaDeConexion = configuration.GetConnectionString("defaultConnection");
            // Registrar el contexto
            services.AddDbContext<PeliculasDbContext>(opt =>
            {
                opt.UseSqlServer(cadenaDeConexion, r =>
                {
                    // configuro donde se creara la carpeta de migraciones
                    r.MigrationsAssembly(typeof(PeliculasDbContext).Assembly.FullName);
                    r.UseNetTopologySuite();
                });

                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });      
        }
    }
}
