using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using EstacionamentoAPI.Services.Interfaces;

namespace EstacionamentoAPI.Services
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly IEstabelecimentoRepository _repository;

        public EstabelecimentoService(IEstabelecimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Estabelecimento>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Estabelecimento> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Estabelecimento estabelecimento)
        {
            await _repository.AddAsync(estabelecimento);
        }

        public async Task UpdateAsync(Estabelecimento estabelecimento)
        {
            await _repository.UpdateAsync(estabelecimento);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}