using Microsoft.EntityFrameworkCore;
using Progetto_Settimanale_Evento.Data;
using Progetto_Settimanale_Evento.Models;

namespace Progetto_Settimanale_Evento.Services
{
    public class EventoService
    {
        private readonly ApplicationDbContext _context;

        public EventoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAllEventi()
        {
            return await _context.Eventi.Include(e => e.Artista).ToListAsync();
        }

        public async Task<Evento> GetEventoById(int id)
        {
            return await _context.Eventi.Include(e => e.Artista).FirstOrDefaultAsync(e => e.EventoId == id);
        }

        public async Task<Evento> CreateEvento(Evento evento)
        {
            _context.Eventi.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> UpdateEvento(int id, Evento evento)
        {
            if (id != evento.EventoId)
                return false;

            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEvento(int id)
        {
            var evento = await _context.Eventi.FindAsync(id);
            if (evento == null)
                return false;

            _context.Eventi.Remove(evento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
