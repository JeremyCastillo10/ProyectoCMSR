using ApiWebCMSR.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoCMSR.Server.models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
      
    }
}
