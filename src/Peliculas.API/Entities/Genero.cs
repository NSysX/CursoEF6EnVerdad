namespace Peliculas.API.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual List<Pelicula> Peliculas { get; set; }
    }
}
