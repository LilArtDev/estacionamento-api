using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using EstacionamentoAPI.Services.Interfaces;

namespace EstacionamentoAPI.Services
{
    public class MovimentationService : IMovimentationService
    {
        private readonly IMovimentationRepository _repository;
        private readonly IEstablishmentService _establishmentService;
        private readonly IVehicleService _vehicleService;

        public MovimentationService(IMovimentationRepository repository, IEstablishmentService establishmentService, IVehicleService vehicleService)
        {
            _repository = repository;
            _establishmentService = establishmentService;
            _vehicleService = vehicleService;
        }

        public async Task<IEnumerable<Movimentation>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<IEnumerable<Movimentation>> GetByEstablishmentIdAsync(int establishmentId)
        {
            var doesEstablishmentExists = await _establishmentService.CheckEstablishmentExistsByIdAsync(establishmentId);
            if (!doesEstablishmentExists) throw new BadHttpRequestException("O Establishment não existe");

            return await _repository.GetByEstablishmentIdAsync(establishmentId);
        }

        public async Task<IEnumerable<Movimentation>> GetByVehicleIdAsync(int vehicleId)
        {

            var doesVehicleExists = await _vehicleService.CheckVehicleExistsByIdAsync(vehicleId);
            if (!doesVehicleExists) throw new BadHttpRequestException("O Vehicle não existe");
            return await _repository.GetByVehicleIdAsync(vehicleId);
        }

        public async Task<Movimentation> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }


        public async Task AddAsync(Movimentation movimentation)
        {
            var movimentacaoError = await _validateMovimentation(movimentation);
            if (movimentacaoError != null) throw movimentacaoError;

            await _repository.AddAsync(movimentation);
        }

        public async Task UpdateAsync(Movimentation movimentation)
        {
            var movimentacaoError = await _validateMovimentation(movimentation);
            if (movimentacaoError != null) throw movimentacaoError;

            await _repository.UpdateAsync(movimentation);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }


        private async Task<BadHttpRequestException?> _validateMovimentation(Movimentation movimentation)
        {
            string? badRequestmessage = null;

            var doesVehicleExists = await _vehicleService.CheckVehicleExistsByIdAsync(movimentation.VehicleId);
            if (!doesVehicleExists) badRequestmessage = "O Veículo não existe";

            var doesEstablishmentExists = await _establishmentService.CheckEstablishmentExistsByIdAsync(movimentation.EstablishmentId);
            if (!doesEstablishmentExists) badRequestmessage = "O Estabelecimento não existe";

            if (badRequestmessage != null)
            {
                return new BadHttpRequestException(badRequestmessage);
            }
            else return null;
        }

    }
}