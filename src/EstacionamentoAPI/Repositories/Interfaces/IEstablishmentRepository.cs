using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Repositories.Interfaces
{
    public interface IEstablishmentRepository
    {
        Task<IEnumerable<Establishment>> GetAllAsync();
        Task<Establishment> GetByIdAsync(int id);
        Task AddAsync(Establishment establishment);
        Task UpdateAsync(Establishment establishment);
        Task DeleteAsync(int id);
    }
}