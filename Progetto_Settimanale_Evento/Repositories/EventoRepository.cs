using Microsoft.EntityFrameworkCore;
using Progetto_Settimanale_Evento.Data;
using Progetto_Settimanale_Evento.Models;


namespace Progetto_Settimanale_Evento.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationDbContext _context;

        public EventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            return await _context.Eventi.Include(e => e.Artista).ToListAsync();
        }

        public async Task<Evento> GetByIdAsync(int id)
        {
            return await _context.Eventi.Include(e => e.Artista).FirstOrDefaultAsync(e => e.EventoId == id);
        }

        public async Task CreateAsync(Evento evento)
        {
            await _context.Eventi.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evento evento)
        {
            _context.Eventi.Update(evento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var evento = await _context.Eventi.FindAsync(id);
            if (evento != null)
            {
                _context.Eventi.Remove(evento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
