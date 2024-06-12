using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<Veiculo>> GetAllAsync();
        Task<Veiculo> GetByIdAsync(int id);
        Task AddAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo veiculo);
        Task DeleteAsync(int id);

        Task<bool> CheckVeiculoExistsByIdAsync(int veiculoId);
    }
}