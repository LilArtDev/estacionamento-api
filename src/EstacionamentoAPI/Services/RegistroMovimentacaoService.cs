using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using EstacionamentoAPI.Services.Interfaces;

namespace EstacionamentoAPI.Services
{
    public class RegistroMovimentacaoService : IRegistroMovimentacaoService
    {
        private readonly IRegistroMovimentacaoRepository _repository;
        private readonly IEstabelecimentoService _estabelecimentoService;
        private readonly IVeiculoService _veiculoService;

        public RegistroMovimentacaoService(IRegistroMovimentacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RegistroMovimentacao>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<IEnumerable<RegistroMovimentacao>> GetByEstabelecimentoIdAsync(int estabelecimentoId)
        {
            var doesEstabelecimentoExists = await _estabelecimentoService.CheckEstabelecimentoExistsByIdAsync(estabelecimentoId);
            if (!doesEstabelecimentoExists) throw new BadHttpRequestException("O Estabelecimento não existe");

            return await _repository.GetByEstabelecimentoIdAsync(estabelecimentoId);
        }

        public async Task<IEnumerable<RegistroMovimentacao>> GetByVeiculoIdAsync(int veiculoId)
        {

            var doesVeiculoExists = await _veiculoService.CheckVeiculoExistsByIdAsync(veiculoId);
            if (!doesVeiculoExists) throw new BadHttpRequestException("O Veiculo não existe");
            return await _repository.GetByVeiculoIdAsync(veiculoId);
        }

        public async Task<RegistroMovimentacao> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }


        public async Task AddAsync(RegistroMovimentacao registroMovimentacao)
        {
            var movimentacaoError = await _validateMovimentacao(registroMovimentacao);
            if (movimentacaoError != null) throw movimentacaoError;

            await _repository.AddAsync(registroMovimentacao);
        }

        public async Task UpdateAsync(RegistroMovimentacao registroMovimentacao)
        {
            var movimentacaoError = await _validateMovimentacao(registroMovimentacao);
            if (movimentacaoError != null) throw movimentacaoError;

            await _repository.UpdateAsync(registroMovimentacao);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }


        private async Task<BadHttpRequestException?> _validateMovimentacao(RegistroMovimentacao registroMovimentacao)
        {
            var doesVeiculoExists = _veiculoService.CheckVeiculoExistsByIdAsync(registroMovimentacao.VeiculoId);
            var doesEstabelecimentoExists = _estabelecimentoService.CheckEstabelecimentoExistsByIdAsync(registroMovimentacao.EstabelecimentoId);

            await Task.WhenAll(doesVeiculoExists, doesEstabelecimentoExists);

            if (!await doesVeiculoExists) return new BadHttpRequestException("O Veiculo não existe");
            if (!await doesEstabelecimentoExists) return new BadHttpRequestException("O Estabelecimento não existe");
            return null;
        }

    }
}