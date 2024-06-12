using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Repositories.Interfaces
{
    public interface IRegistroMovimentacaoRepository
    {
        Task<IEnumerable<RegistroMovimentacao>> GetAllAsync();
        //TODO: Implementar filtros
        Task<IEnumerable<RegistroMovimentacao>> GetAllAsync(int id);
        Task<IEnumerable<RegistroMovimentacao>> GetByEstabelecimentoIdAsync(int estabelecimentoId);
        Task<IEnumerable<RegistroMovimentacao>> GetByVeiculoIdAsync(int veiculoId);
        Task<RegistroMovimentacao> GetByIdAsync(int id);
        Task AddAsync(RegistroMovimentacao veiculo);
        Task UpdateAsync(RegistroMovimentacao veiculo);
        Task DeleteAsync(int id);
    }
}