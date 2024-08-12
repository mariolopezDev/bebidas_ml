using Microsoft.AspNetCore.Mvc;
using Bebidas_ML.Models;
using Bebidas_ML.Services;

namespace Bebidas_ML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidaController : ControllerBase
    {
        private readonly IBebidaService _bebidaService;

        public BebidaController(IBebidaService bebidaService)
        {
            _bebidaService = bebidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BebidaDto>>> GetBebidas()
        {
            var bebidas = await _bebidaService.GetAllBebidasAsync();
            return Ok(bebidas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BebidaDto>> GetBebida(int id)
        {
            var bebida = await _bebidaService.GetBebidaByIdAsync(id);
            if (bebida == null)
                return NotFound();

            return Ok(bebida);
        }

        [HttpPost]
        public async Task<ActionResult<Bebida>> CreateBebida(Bebida bebida)
        {
            if (bebida == null)
                return BadRequest();

            var createdBebida = await _bebidaService.CreateBebidaAsync(bebida);
            return CreatedAtAction(nameof(GetBebida), new { id = createdBebida.Id }, createdBebida);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBebida(int id, Bebida bebida)
        {
            if (id != bebida.Id)
                return BadRequest();

            var updatedBebida = await _bebidaService.UpdateBebidaAsync(bebida);
            if (updatedBebida == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBebida(int id)
        {
            var deleted = await _bebidaService.DeleteBebidaAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
