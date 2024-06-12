using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Repositories.Interfaces
{
    public interface IMovimentationRepository
    {
        Task<IEnumerable<Movimentation>> GetAllAsync();
        //TODO: Implementar filtros
        Task<IEnumerable<Movimentation>> GetAllAsync(int id);
        Task<IEnumerable<Movimentation>> GetByEstablishmentIdAsync(int establishmentId);
        Task<IEnumerable<Movimentation>> GetByVehicleIdAsync(int vehicleId);
        Task<Movimentation> GetByIdAsync(int id);
        Task AddAsync(Movimentation vehicle);
        Task UpdateAsync(Movimentation vehicle);
        Task DeleteAsync(int id);
    }
}