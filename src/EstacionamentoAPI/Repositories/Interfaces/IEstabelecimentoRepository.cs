using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Repositories.Interfaces
{
    public interface IEstabelecimentoRepository
    {
        Task<IEnumerable<Estabelecimento>> GetAllAsync();
        Task<Estabelecimento> GetByIdAsync(int id);
        Task AddAsync(Estabelecimento estabelecimento);
        Task UpdateAsync(Estabelecimento estabelecimento);
        Task DeleteAsync(int id);
    }
}