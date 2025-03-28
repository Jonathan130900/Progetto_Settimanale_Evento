using Microsoft.AspNetCore.Mvc;
using Progetto_Settimanale_Evento.Models;
using Progetto_Settimanale_Evento.Repositories;

namespace Progetto_Settimanale_Evento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private readonly IArtistaRepository _artistaRepository;

        public ArtistaController(IArtistaRepository artistaRepository)
        {
            _artistaRepository = artistaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> GetAll()
        {
            var artisti = await _artistaRepository.GetAllAsync();
            return Ok(artisti);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetById(int id)
        {
            var artista = await _artistaRepository.GetByIdAsync(id);
            if (artista == null)
            {
                return NotFound();
            }
            return Ok(artista);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Artista artista)
        {
            await _artistaRepository.CreateAsync(artista);
            return CreatedAtAction(nameof(GetById), new { id = artista.ArtistaId }, artista);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Artista artista)
        {
            if (id != artista.ArtistaId)
            {
                return BadRequest();
            }

            await _artistaRepository.UpdateAsync(artista);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _artistaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
