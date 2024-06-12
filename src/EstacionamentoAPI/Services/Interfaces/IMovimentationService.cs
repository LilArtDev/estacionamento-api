using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Services.Interfaces
{
    public interface IMovimentationService
    {
        Task<IEnumerable<Movimentation>> GetAllAsync();
        Task<IEnumerable<Movimentation>> GetByEstablishmentIdAsync(int establishmentId);
        Task<IEnumerable<Movimentation>> GetByVehicleIdAsync(int vehicleId);
        Task<Movimentation> GetByIdAsync(int id);
        Task AddAsync(Movimentation movimentation);
        Task UpdateAsync(Movimentation movimentation);
        Task DeleteAsync(int id);
    }
}



