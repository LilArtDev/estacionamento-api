using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Services.Interfaces
{
    public interface IRegistroMovimentacaoService
    {
        Task<IEnumerable<RegistroMovimentacao>> GetAllAsync();
        Task<IEnumerable<RegistroMovimentacao>> GetByEstabelecimentoIdAsync(int estabelecimentoId);
        Task<IEnumerable<RegistroMovimentacao>> GetByVeiculoIdAsync(int veiculoId);
        Task<RegistroMovimentacao> GetByIdAsync(int id);
        Task AddAsync(RegistroMovimentacao registroMovimentacao);
        Task UpdateAsync(RegistroMovimentacao registroMovimentacao);
        Task DeleteAsync(int id);
    }
}



