using Microsoft.AspNetCore.Mvc;
using Progetto_Settimanale_Evento.Models;
using Progetto_Settimanale_Evento.Repositories;


namespace Progetto_Settimanale_Evento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BigliettoController : ControllerBase
    {
        private readonly IBigliettoRepository _bigliettoRepository;

        public BigliettoController(IBigliettoRepository bigliettoRepository)
        {
            _bigliettoRepository = bigliettoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biglietto>>> GetAll()
        {
            var biglietti = await _bigliettoRepository.GetAllAsync();
            return Ok(biglietti);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Biglietto>> GetById(int id)
        {
            var biglietto = await _bigliettoRepository.GetByIdAsync(id);
            if (biglietto == null)
            {
                return NotFound();
            }
            return Ok(biglietto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Biglietto biglietto)
        {
            await _bigliettoRepository.CreateAsync(biglietto);
            return CreatedAtAction(nameof(GetById), new { id = biglietto.BigliettoId }, biglietto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bigliettoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
