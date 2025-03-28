using Microsoft.EntityFrameworkCore;
using Progetto_Settimanale_Evento.Data;
using Progetto_Settimanale_Evento.Models;


namespace Progetto_Settimanale_Evento.Repositories
{
    public class BigliettoRepository : IBigliettoRepository
    {
        private readonly ApplicationDbContext _context;

        public BigliettoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Biglietto>> GetAllAsync()
        {
            return await _context.Biglietti.Include(b => b.Evento).Include(b => b.User).ToListAsync();
        }

        public async Task<Biglietto> GetByIdAsync(int id)
        {
            return await _context.Biglietti.Include(b => b.Evento).Include(b => b.User).FirstOrDefaultAsync(b => b.BigliettoId == id);
        }

        public async Task CreateAsync(Biglietto biglietto)
        {
            await _context.Biglietti.AddAsync(biglietto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var biglietto = await _context.Biglietti.FindAsync(id);
            if (biglietto != null)
            {
                _context.Biglietti.Remove(biglietto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
