using MudBlazor;
using ProyectoCMSR.Server.models;
using System.ComponentModel.DataAnnotations;

namespace ApiWebCMSR.models
{
    public class Medicos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; }
        public byte[] ImagenMedico { get; set; }
        public bool Visible { get; set; }
    }
}
