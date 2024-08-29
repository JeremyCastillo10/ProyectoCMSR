using ApiWebCMSR.models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCMSR.Server.Data;
using ProyectoCMSR.Server.models;
using ProyectoCMSR.Shared.DTOS;
using System.Linq;

namespace ProyectoCMSR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly Contexto _contexto;
        public MedicosController(Contexto contexto) { _contexto = contexto; }
        [HttpPost]
        public async Task<ActionResult<Medicos>> CreateMedico([FromBody] Medicos_M medicoDto)
        {
            if (medicoDto == null)
            {
                return BadRequest("Medico object is null");
            }

            var medico = new Medicos
            {
                Nombre = medicoDto.Nombre,
                Descripcion = medicoDto.Descripcion,
                EspecialidadId = medicoDto.EspecialidadId,
                ImagenMedico = medicoDto.ImagenBase64 != null ? Convert.FromBase64String(medicoDto.ImagenBase64) : null
            };

            _contexto.Medicos.Add(medico);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllMedicos), new { id = medico.Id }, medico);
        }



        [HttpGet("getMedicoById/{id}")]
        public async Task<ActionResult<Medicos_M>> GetMedicoById(int id)
        {
            var medico = await _contexto.Medicos
                .Where(m => m.Id == id)
                .Select(m => new Medicos_M
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion,
                    EspecialidadId = m.EspecialidadId,
                    ImagenBase64 = m.ImagenMedico != null ? Convert.ToBase64String(m.ImagenMedico) : null
                })
                .FirstOrDefaultAsync();

            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }


        // GET: api/medicos
        // GET: api/medicos
        [HttpGet("getMedicos")]
        public async Task<ActionResult<IEnumerable<Medicos_M>>> GetAllMedicos()
        {
            var medicos = await _contexto.Medicos
                .Select(m => new Medicos_M
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion,
                    EspecialidadId = m.EspecialidadId,
                    ImagenBase64 = m.ImagenMedico != null ? Convert.ToBase64String(m.ImagenMedico) : null
                })
                .ToListAsync();

            return Ok(medicos);
        }
        [HttpDelete("GetPorId/{id}")]
        public async Task<ActionResult<bool>> DeleteMedico(int id)
        {
            var dbMedico = await _contexto.Medicos.FindAsync(id);
            if (dbMedico == null)
            {
                return NotFound();
            }

            dbMedico.Visible = false;

            await _contexto.SaveChangesAsync();

            return Ok(true);
        }



        //[HttpDelete("{id}")]
        //public async Task<ActionResult<bool>> DeleteServicio(int id)
        //{
        //    var dbservicio = await _contexto.Medicos.FindAsync(id);
        //    if (dbservicio == null)
        //    {
        //        return NotFound();
        //    }

        //    dbservicio.Visible = false;

        //    await _contexto.SaveChangesAsync();

        //    return Ok(true);
        //}
    }
}
