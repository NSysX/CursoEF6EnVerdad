namespace Peliculas.API.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual List<PeliculaActor> PeliculaActores { get; set; }
    }
}
