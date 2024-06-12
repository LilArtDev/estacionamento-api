using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using EstacionamentoAPI.Services.Interfaces;

namespace EstacionamentoAPI.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _repository.AddAsync(vehicle);
        }

        public async Task UpdateAsync(int id, Vehicle updatedVehicle)
        {
            var vehicle = await _repository.GetByIdAsync(id);

            if (vehicle == null) throw new KeyNotFoundException("Veículo não encontrado");

            if (vehicle.Equals(updatedVehicle)) throw new BadHttpRequestException("Nenhuma alteração realizada");


            await _repository.UpdateAsync(vehicle);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<bool> CheckVehicleExistsByIdAsync(int id)
        {
            var vehicle = await _repository.GetByIdAsync(id);
            return vehicle != null;
        }
    }
}