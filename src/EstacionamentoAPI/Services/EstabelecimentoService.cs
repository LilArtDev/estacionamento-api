using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using EstacionamentoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

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
            var estabelecimento = await _repository.GetByIdAsync(id);

            if (estabelecimento == null) throw new KeyNotFoundException("Estabelecimento não encontrado");

            return estabelecimento;
        }

        public async Task AddAsync(Estabelecimento estabelecimento)
        {
            await _repository.AddAsync(estabelecimento);
        }

        public async Task UpdateAsync(int id, Estabelecimento estabelecimentoAtualizado)
        {
            var estabelecimento = await _repository.GetByIdAsync(id);

            if (estabelecimento == null) throw new KeyNotFoundException("Estabelecimento não encontrado");

            if (estabelecimento.Equals(estabelecimentoAtualizado)) throw new BadHttpRequestException("Nenhuma alteração realizada");

            await _repository.UpdateAsync(estabelecimentoAtualizado);
        }

        public async Task DeleteAsync(int id)
        {
            var estabelecimento = await _repository.GetByIdAsync(id);

            if (estabelecimento == null) throw new KeyNotFoundException("Estabelecimento não encontrado");

            await _repository.DeleteAsync(id);
        }
    }
}