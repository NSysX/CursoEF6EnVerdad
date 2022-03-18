namespace Peliculas.API.Entities
{
    public class CineOferta
    {
        public int Id { get; set; }
        public int CineId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PorcentajeDescuento { get; set; }
    }
}
