using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle> GetByIdAsync(int id);
        Task AddAsync(Vehicle vehicle);
        Task UpdateAsync(int id, Vehicle vehicle);
        Task DeleteAsync(int id);

        Task<bool> CheckVehicleExistsByIdAsync(int vehicleId);
        Task<string?> GetVehicleTypeByIdAsync(int vehicleId);
    }
}