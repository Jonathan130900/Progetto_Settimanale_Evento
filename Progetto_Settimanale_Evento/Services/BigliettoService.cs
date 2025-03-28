using Progetto_Settimanale_Evento.Data;
using Progetto_Settimanale_Evento.Models;
using Microsoft.EntityFrameworkCore;

namespace Progetto_Settimanale_Evento.Services
{
    public class BigliettoService
    {
        private readonly ApplicationDbContext _context;

        public BigliettoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Biglietto>> GetAllBiglietti()
        {
            return await _context.Biglietti.Include(b => b.Evento).ToListAsync();
        }

        public async Task<Biglietto> GetBigliettoById(int id)
        {
            return await _context.Biglietti.Include(b => b.Evento).FirstOrDefaultAsync(b => b.BigliettoId == id);
        }

        public async Task<Biglietto> CreateBiglietto(AcquistoBigliettoDto dto, string userId)
        {
            var evento = await _context.Eventi.FindAsync(dto.EventoId);
            if (evento == null)
                return null;

            var biglietto = new Biglietto
            {
                EventoId = dto.EventoId,
                UserId = userId,
                DataAcquisto = DateTime.UtcNow
            };

            _context.Biglietti.Add(biglietto);
            await _context.SaveChangesAsync();
            return biglietto;
        }
    }
}
