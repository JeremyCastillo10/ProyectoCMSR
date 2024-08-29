using ApiWebCMSR.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCMSR.Server.Data;
using ProyectoCMSR.Server.models;
using ProyectoCMSR.Shared.DTOS;

namespace ProyectoCMSR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly Contexto _context;

        public EspecialidadController(Contexto context)
        {
            _context = context;
        }

        //[HttpGet("getEspecialidad")]
        //public async Task<ActionResult<IEnumerable<Especialidad_M>>> GetEspecialidades()
        //{
        //    var especialidades = await _context.Especialidades
        //        .Select(m => new Especialidad_M
        //        {
        //            Id = m.Id,
        //            Nombre = m.Nombre,
        //        })
        //        .ToListAsync();

        //    return Ok(especialidades);
        //}
        [HttpGet("getEspecialidad")]
        public async Task<ActionResult<List<Especialidad_M>>> GetNacionalidades()
        {
            var Nacionalidades = await _context.Especialidades.Select(x => new Especialidad_M { Id = x.Id, Nombre = x.Nombre }).ToListAsync();
            if (Nacionalidades == null)
            {
                return NotFound("No hay");
            }
            return Ok(Nacionalidades);
        }
    }
}
