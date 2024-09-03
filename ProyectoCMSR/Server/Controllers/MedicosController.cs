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


        [HttpGet("getMedicos")]
        public async Task<ActionResult<IEnumerable<Medicos_M>>> GetAllMedicos()
        {
            var medicos = await _contexto.Medicos
                .Where(m => m.Visible == true)
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
        [HttpGet("getMedicosByEspecialidad/{especialidadId}")]
        public async Task<ActionResult<IEnumerable<Medicos_M>>> GetMedicosByEspecialidad(int especialidadId)
        {
            var medicos = await _contexto.Medicos
                .Where(m => m.EspecialidadId == especialidadId && m.Visible == true)
                .Select(m => new Medicos_M
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion,
                    EspecialidadId = m.EspecialidadId,
                    ImagenBase64 = m.ImagenMedico != null ? Convert.ToBase64String(m.ImagenMedico) : null
                })
                .ToListAsync();

            if (medicos == null || !medicos.Any())
            {
                return NotFound();
            }

            return Ok(medicos);
        }
        [HttpGet("getMedicosByNombre")]
        public async Task<ActionResult<IEnumerable<Medicos_M>>> GetMedicosByNombre([FromQuery] string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return BadRequest("El parámetro 'nombre' es obligatorio.");
            }

            var medicos = await _contexto.Medicos
                .Where(m => m.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase) && m.Visible == true)
                .Select(m => new Medicos_M
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion,
                    EspecialidadId = m.EspecialidadId,
                    ImagenBase64 = m.ImagenMedico != null ? Convert.ToBase64String(m.ImagenMedico) : null
                })
                .ToListAsync();

            if (medicos == null || !medicos.Any())
            {
                return NotFound("No se encontraron médicos con el nombre proporcionado.");
            }

            return Ok(medicos);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutMedico(int id, [FromBody] Medicos_M medico_M)
        {
            if (medico_M == null)
            {
                return BadRequest("Medico object is null");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Buscar el médico existente
            var medico = await _contexto.Medicos.FirstOrDefaultAsync(m => m.Id == id);
            if (medico == null)
            {
                return NotFound("Medico not found");
            }

            // Actualizar los campos del médico
            medico.Nombre = medico_M.Nombre;
            medico.Descripcion = medico_M.Descripcion;
            medico.EspecialidadId = medico_M.EspecialidadId;

            // Actualizar la imagen si se proporciona
            if (!string.IsNullOrEmpty(medico_M.ImagenBase64))
            {
                try
                {
                    medico.ImagenMedico = Convert.FromBase64String(medico_M.ImagenBase64);
                }
                catch (FormatException)
                {
                    return BadRequest("Invalid base64 format for image.");
                }
            }

            // No es necesario llamar a Update si estás obteniendo la entidad con FirstOrDefaultAsync
            // El seguimiento de cambios ya está habilitado en Entity Framework
            await _contexto.SaveChangesAsync();

            return Ok("Medico updated successfully");
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
