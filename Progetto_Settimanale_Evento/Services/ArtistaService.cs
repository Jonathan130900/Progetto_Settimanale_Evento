using Microsoft.EntityFrameworkCore;
using Progetto_Settimanale_Evento.Data;
using Progetto_Settimanale_Evento.Models;

namespace Progetto_Settimanale_Evento.Services
{
    public class ArtistaService
    {
        private readonly ApplicationDbContext _context;

        public ArtistaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artista>> GetAllArtisti()
        {
            return await _context.Artisti.ToListAsync();
        }

        public async Task<Artista> GetArtistaById(int id)
        {
            return await _context.Artisti.FindAsync(id);
        }

        public async Task<Artista> CreateArtista(Artista artista)
        {
            _context.Artisti.Add(artista);
            await _context.SaveChangesAsync();
            return artista;
        }

        public async Task<bool> UpdateArtista(int id, Artista artista)
        {
            if (id != artista.ArtistaId)
                return false;

            _context.Entry(artista).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteArtista(int id)
        {
            var artista = await _context.Artisti.FindAsync(id);
            if (artista == null)
                return false;

            _context.Artisti.Remove(artista);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
