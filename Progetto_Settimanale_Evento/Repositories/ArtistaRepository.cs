using Microsoft.EntityFrameworkCore;
using Progetto_Settimanale_Evento.Data;
using Progetto_Settimanale_Evento.Models;

namespace Progetto_Settimanale_Evento.Repositories
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly ApplicationDbContext _context;

        public ArtistaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artista>> GetAllAsync()
        {
            return await _context.Artisti.ToListAsync();
        }

        public async Task<Artista> GetByIdAsync(int id)
        {
            return await _context.Artisti.FindAsync(id);
        }

        public async Task CreateAsync(Artista artista)
        {
            await _context.Artisti.AddAsync(artista);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Artista artista)
        {
            _context.Artisti.Update(artista);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var artista = await _context.Artisti.FindAsync(id);
            if (artista != null)
            {
                _context.Artisti.Remove(artista);
                await _context.SaveChangesAsync();
            }
        }
    }
}
