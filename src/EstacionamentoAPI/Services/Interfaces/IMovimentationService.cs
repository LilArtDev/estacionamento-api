using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Services.Interfaces
{
    public interface IMovimentationService
    {
        Task<IEnumerable<Movimentations>> GetAllAsync();
        Task<IEnumerable<Movimentations>> GetByEstablishmentIdAsync(int establishmentId);
        Task<IEnumerable<Movimentations>> GetByVehicleIdAsync(int vehicleId);
        Task<Movimentations> GetByIdAsync(int id);
        Task CheckIn(int establishmentId, int vehicleId, DateTime dateTime);
        Task CheckOut(int movimentationId, DateTime dateTime);
        Task DeleteAsync(int id);
    }
}



