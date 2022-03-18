using NetTopologySuite.Geometries;

namespace Peliculas.API.Entities
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }

        public virtual CineOferta CineOferta { get; set; } // tiene solo una oferta
        public virtual List<SalaCine> SalaCines { get; set; } // tiene varias salas

    }
}
