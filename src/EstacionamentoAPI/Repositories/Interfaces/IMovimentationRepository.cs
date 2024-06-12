using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Repositories.Interfaces
{
    public interface IMovimentationRepository
    {
        Task<IEnumerable<Movimentations>> GetAllAsync();
        //TODO: Implementar filtros
        Task<IEnumerable<Movimentations>> GetAllAsync(int id);
        Task<IEnumerable<Movimentations>> GetByEstablishmentIdAsync(int establishmentId);
        Task<IEnumerable<Movimentations>> GetByVehicleIdAsync(int vehicleId);
        Task<Movimentations> GetByIdAsync(int id);
        Task AddAsync(Movimentations vehicle);
        Task UpdateAsync(Movimentations vehicle);
        Task DeleteAsync(int id);

        Task<Movimentations?> GetLastByVehicleId(int vehicleId);
    }
}