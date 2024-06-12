using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using EstacionamentoAPI.Services.Interfaces;

namespace EstacionamentoAPI.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Veiculo veiculo)
        {
            await _repository.AddAsync(veiculo);
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            await _repository.UpdateAsync(veiculo);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<bool> CheckVeiculoExistsByIdAsync(int id)
        {
            var veiculo = await _repository.GetByIdAsync(id);

            return veiculo != null;
        }
    }
}