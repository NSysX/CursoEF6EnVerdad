namespace Peliculas.API.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string PosterURL { get; set; }

        public virtual List<Genero> Generos { get; set; }
        public virtual List<SalaCine> SalaCines { get; set; }
    }
}
