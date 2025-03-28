using Microsoft.AspNetCore.Mvc;
using Progetto_Settimanale_Evento.Models;
using Progetto_Settimanale_Evento.Repositories;

namespace Progetto_Settimanale_Evento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetAll()
        {
            var eventi = await _eventoRepository.GetAllAsync();
            return Ok(eventi);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetById(int id)
        {
            var evento = await _eventoRepository.GetByIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Evento evento)
        {
            await _eventoRepository.CreateAsync(evento);
            return CreatedAtAction(nameof(GetById), new { id = evento.EventoId }, evento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Evento evento)
        {
            if (id != evento.EventoId)
            {
                return BadRequest();
            }

            await _eventoRepository.UpdateAsync(evento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _eventoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
