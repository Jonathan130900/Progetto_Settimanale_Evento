using Progetto_Settimanale_Evento.Models;

namespace Progetto_Settimanale_Evento.Repositories
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> GetAllAsync();
        Task<Evento> GetByIdAsync(int id);
        Task CreateAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);
    }
}
