using NetTopologySuite.Geometries;

namespace Peliculas.API.Entities
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public Point Ubicacion { get; set; }
    }
}
