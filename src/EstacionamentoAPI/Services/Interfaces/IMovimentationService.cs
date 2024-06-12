using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Services.Interfaces
{
    public interface IMovimentationService
    {
        Task<IEnumerable<Movimentations>> GetAllAsync();
        Task<IEnumerable<Movimentations>> GetByEstablishmentIdAsync(int establishmentId);
        Task<IEnumerable<Movimentations>> GetByVehicleIdAsync(int vehicleId);
        Task<Movimentations> GetByIdAsync(int id);
        Task AddAsync(Movimentations Movimentations);
        Task UpdateAsync(Movimentations Movimentations);
        Task DeleteAsync(int id);
    }
}



