using Microsoft.AspNetCore.Mvc;
using Bebidas_ML.Models;
using Bebidas_ML.Services;

namespace Bebidas_ML.Controllers
{
    [Route("api/tiposbebida")]
    [ApiController]
    public class TipoBebidaController : ControllerBase
    {
        private readonly ITipoBebidaService _tipoBebidaService;

        public TipoBebidaController(ITipoBebidaService tipoBebidaService)
        {
            _tipoBebidaService = tipoBebidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoBebida>>> GetTiposBebida()
        {
            var tiposBebida = await _tipoBebidaService.GetAllTiposBebidasAsync();
            return Ok(tiposBebida);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoBebida>> GetTipoBebida(int id)
        {
            var tipoBebida = await _tipoBebidaService.GetTipoBebidaByIdAsync(id);
            if (tipoBebida == null)
                return NotFound();

            return Ok(tipoBebida);
        }

        [HttpPost]
        public async Task<ActionResult<TipoBebida>> CreateTipoBebida(TipoBebida tipoBebida)
        {
            var createdTipoBebida = await _tipoBebidaService.CreateTipoBebidaAsync(tipoBebida);
            return CreatedAtAction(nameof(GetTipoBebida), new { id = createdTipoBebida.Id }, createdTipoBebida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoBebida(int id, TipoBebida tipoBebida)
        {
            if (id != tipoBebida.Id)
                return BadRequest();

            var updatedTipoBebida = await _tipoBebidaService.UpdateTipoBebidaAsync(tipoBebida);
            if (updatedTipoBebida == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoBebida(int id)
        {
            var deleted = await _tipoBebidaService.DeleteTipoBebidaAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
