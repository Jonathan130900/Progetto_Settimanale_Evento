using Progetto_Settimanale_Evento.Models;

namespace Progetto_Settimanale_Evento.Repositories
{
    public interface IBigliettoRepository
    {
        Task<IEnumerable<Biglietto>> GetAllAsync();
        Task<Biglietto> GetByIdAsync(int id);
        Task CreateAsync(Biglietto biglietto);
        Task DeleteAsync(int id);
    }
}
