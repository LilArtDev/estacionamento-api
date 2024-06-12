using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Services.Interfaces
{
    public interface IEstabelecimentoService
    {
        Task<IEnumerable<Estabelecimento>> GetAllAsync();
        Task<Estabelecimento> GetByIdAsync(int id);
        Task AddAsync(Estabelecimento estabelecimento);
        Task UpdateAsync(int id, Estabelecimento estabelecimento);
        Task DeleteAsync(int id);

        Task<bool> CheckEstabelecimentoExistsByIdAsync(int id);
    }
}