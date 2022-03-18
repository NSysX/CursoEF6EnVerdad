using Peliculas.API.Enums;

namespace Peliculas.API.Entities
{
    public class SalaCine
    {
        public int Id { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        public decimal Precio { get; set; }
        public int CineId { get; set; }

        public virtual Cine Cine { get; set; }
        public virtual List<Pelicula> Peliculas { get; set; }
    }
}
