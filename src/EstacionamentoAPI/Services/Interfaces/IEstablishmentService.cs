using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Services.Interfaces
{
    public interface IEstablishmentService
    {
        Task<IEnumerable<Establishment>> GetAllAsync();
        Task<Establishment> GetByIdAsync(int id);
        Task AddAsync(Establishment establishment);
        Task UpdateAsync(int id, Establishment establishment);
        Task DeleteAsync(int id);

        Task<bool> CheckEstablishmentExistsByIdAsync(int id);
    }
}