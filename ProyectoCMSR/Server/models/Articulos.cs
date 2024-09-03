using System.ComponentModel.DataAnnotations;

namespace ProyectoCMSR.Server.models
{
    public class Articulos
    {
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public string? Autor { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; }
        public string? Categoria { get; set; }
        public byte[]? ImagenPrincipal { get; set; }
        public byte[]? ImagenContenido { get; set; }
        public bool visible { get; set; }
        public string? Slug { get; set; }
        public int Visitas { get; set; }
    }
}
