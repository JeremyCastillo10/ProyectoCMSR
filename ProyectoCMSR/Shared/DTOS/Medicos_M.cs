using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCMSR.Shared.DTOS
{
    public class Medicos_M
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int EspecialidadId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ImagenBase64 { get; set; }
    }
}
