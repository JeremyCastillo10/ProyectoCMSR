using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCMSR.Server.Data;

namespace ProyectoCMSR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private readonly Contexto _contexto;
        public SegurosController(Contexto contexto) { _contexto = contexto; }
        [HttpGet]
        public async Task<ActionResult> getSeguros()
        {
            var medicos = await _contexto.Medicos.ToListAsync();
            if(medicos == null)
            {
                return BadRequest(medicos);
            }
            return Ok(medicos);
        }

    }
}
