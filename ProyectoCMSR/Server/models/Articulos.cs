using System.ComponentModel.DataAnnotations;

namespace ProyectoCMSR.Server.models
{
    public class Articulos
    {
        [Key]
        public int Id { get; set; }               // Identificador único del artículo
        public string Titulo { get; set; }        // Título del artículo
        public string Contenido { get; set; }     // Contenido completo del artículo (en formato HTML o texto enriquecido)
        public string Autor { get; set; }         // Nombre del autor del artículo
        public DateTime FechaCreacion { get; set; } = DateTime.Now;// Fecha y hora de creación del artículo
        public DateTime FechaModificacion { get; set; } // Fecha y hora de la última modificación
        public string Categoria { get; set; }     // Categoría del artículo
        public byte[] ImagenPrincipal { get; set; } 
        public byte[] ImagenContenido { get; set; } 
        public bool visible { get; set; }          // Estado de publicación (true = publicado, false = borrador)
        public string Slug { get; set; }          // URL amigable para el artículo
        public int Visitas { get; set; }          // Número de visitas del artículo
    }
}
