using Progetto_Settimanale_Evento.Models;

namespace Progetto_Settimanale_Evento.Repositories
{
    public interface IArtistaRepository
    {
        Task<IEnumerable<Artista>> GetAllAsync();
        Task<Artista> GetByIdAsync(int id);
        Task CreateAsync(Artista artista);
        Task UpdateAsync(Artista artista);
        Task DeleteAsync(int id);
    }
}
