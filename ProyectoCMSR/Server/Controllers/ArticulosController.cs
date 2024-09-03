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
    public class ArticulosController : ControllerBase
    {
        private readonly Contexto _contexto;
        public ArticulosController(Contexto contexto) { _contexto = contexto; }
        public async Task<ActionResult<Articulos>> CreateMedico([FromBody] Articulos_M articuloDto)
        {
            if (articuloDto == null)
            {
                return BadRequest("Medico object is null");
            }

            var articulo = new Articulos
            {
                Autor = articuloDto.Autor,
                Titulo = articuloDto.Titulo,
                Slug = articuloDto.Slug,
                Categoria = articuloDto.Categoria,
                Contenido = articuloDto.Contenido,
                FechaCreacion = articuloDto.FechaCreacion,  
                FechaModificacion = articuloDto.FechaModificacion,
                ImagenPrincipal = articuloDto.ImagenPrincipal != null ? Convert.FromBase64String(articuloDto.ImagenPrincipal) : null,
                ImagenContenido = articuloDto.ImagenContenido != null ? Convert.FromBase64String(articuloDto.ImagenContenido) : null,
                Visitas = articuloDto.Visitas,
                visible = articuloDto.visible,

            };

            _contexto.Articulos.Add(articulo);
            await _contexto.SaveChangesAsync();

            return Ok(articulo);
        }
        // GET: api/Articulos
        [HttpGet("GetArticulos")]
        public async Task<ActionResult<IEnumerable<Articulos_M>>> GetAllArticulos()
        {
            var articulos = await _contexto.Articulos
                .Where(a => a.visible)
                .Select(a => new Articulos_M
                {
                    Id = a.Id,
                    Titulo = a.Titulo,
                    Contenido = a.Contenido,
                    Autor = a.Autor,
                    FechaCreacion = a.FechaCreacion,
                    FechaModificacion = a.FechaModificacion,
                    Categoria = a.Categoria,
                    ImagenPrincipal = a.ImagenPrincipal != null ? Convert.ToBase64String(a.ImagenPrincipal) : null,
                    ImagenContenido = a.ImagenContenido != null ? Convert.ToBase64String(a.ImagenContenido) : null,
                    Slug = a.Slug,
                    Visitas = a.Visitas,
                    visible = a.visible
                })
                .ToListAsync();

            return Ok(articulos);
        }
        // GET: api/Articulos/{id}
        [HttpGet("GetArticulosById/{id}")]
        public async Task<ActionResult<Articulos_M>> GetArticuloById(int id)
        {
            var articulo = await _contexto.Articulos
                .Where(a => a.Id == id)
                .Select(a => new Articulos_M
                {
                    Id = a.Id,
                    Titulo = a.Titulo,
                    Contenido = a.Contenido,
                    Autor = a.Autor,
                    FechaCreacion = a.FechaCreacion,
                    FechaModificacion = a.FechaModificacion,
                    Categoria = a.Categoria,
                    ImagenPrincipal = a.ImagenPrincipal != null ? Convert.ToBase64String(a.ImagenPrincipal) : null,
                    ImagenContenido = a.ImagenContenido != null ? Convert.ToBase64String(a.ImagenContenido) : null,
                    Slug = a.Slug,
                    Visitas = a.Visitas,
                    visible = a.visible
                })
                .FirstOrDefaultAsync();

            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }


        // PUT: api/Articulos/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateArticulo(int id, [FromBody] Articulos_M articuloDto)
        {
            if (articuloDto == null)
            {
                return BadRequest("Articulos object is null");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Buscar el artículo existente
            var articulo = await _contexto.Articulos.FirstOrDefaultAsync(a => a.Id == id);
            if (articulo == null)
            {
                return NotFound("Articulo not found");
            }

            // Actualizar los campos del artículo
            articulo.Titulo = articuloDto.Titulo;
            articulo.Contenido = articuloDto.Contenido;
            articulo.Autor = articuloDto.Autor;
            articulo.FechaCreacion = articuloDto.FechaCreacion;
            articulo.FechaModificacion = articuloDto.FechaModificacion;
            articulo.Categoria = articuloDto.Categoria;
            articulo.Slug = articuloDto.Slug;
            articulo.Visitas = articuloDto.Visitas;
            articulo.visible = articuloDto.visible;

            // Actualizar las imágenes si se proporcionan
            if (!string.IsNullOrEmpty(articuloDto.ImagenPrincipal))
            {
                try
                {
                    articulo.ImagenPrincipal = Convert.FromBase64String(articuloDto.ImagenPrincipal);
                }
                catch (FormatException)
                {
                    return BadRequest("Invalid base64 format for ImagenPrincipal.");
                }
            }

            if (!string.IsNullOrEmpty(articuloDto.ImagenContenido))
            {
                try
                {
                    articulo.ImagenContenido = Convert.FromBase64String(articuloDto.ImagenContenido);
                }
                catch (FormatException)
                {
                    return BadRequest("Invalid base64 format for ImagenContenido.");
                }
            }

            // Guardar los cambios
            await _contexto.SaveChangesAsync();

            return Ok("Articulo updated successfully");
        }

    }
}
