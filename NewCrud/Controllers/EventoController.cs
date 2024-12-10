using Microsoft.AspNetCore.Mvc;
using NewCrud.Models;
using NewCrud.Request;
using NewCrud.Services.Interfaces;

namespace NewCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController(IEventoService eventoService) : ControllerBase
    {
        private readonly IEventoService _eventoService = eventoService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEventoAsync([FromQuery] GetEventoRequest request)
        {
            try
            {
                var result = await _eventoService.GetEventoAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostEventoAsync([FromBody] EventoRequest request)
        {
            try
            {
                var result = await _eventoService.PostEventoAsync(request);
                if (result == null)
                    return BadRequest("Não foi possivel registrar Evento");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchEventoAsync([FromForm] Evento request)
        {
            try
            {
                var result = _eventoService.PatchEventoAsync(request);
                if (result == null)
                    return BadRequest("Erro ao atualizar Evento");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutEventoAsync([FromBody] Evento request)
        {
            try
            {
                var result = _eventoService.PatchEventoAsync(request);
                if (result == null)
                    return BadRequest("Erro ao atualizar Evento");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpDelete, Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteEventoAsync([FromRoute] int id)
        {
            try
            {
                var result = await _eventoService.DeleteEventoAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
