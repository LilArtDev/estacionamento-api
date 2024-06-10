using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Repositories.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> GetAllAsync();
        Task<Veiculo> GetByIdAsync(int id);
        Task AddAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo veiculo);
        Task DeleteAsync(int id);
    }
}