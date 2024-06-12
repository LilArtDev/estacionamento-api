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

        public async Task<IEnumerable<Movimentations>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<IEnumerable<Movimentations>> GetByEstablishmentIdAsync(int establishmentId)
        {
            var doesEstablishmentExists = await _establishmentService.CheckEstablishmentExistsByIdAsync(establishmentId);
            if (!doesEstablishmentExists) throw new BadHttpRequestException("O Establishment não existe");

            return await _repository.GetByEstablishmentIdAsync(establishmentId);
        }

        public async Task<IEnumerable<Movimentations>> GetByVehicleIdAsync(int vehicleId)
        {

            var doesVehicleExists = await _vehicleService.CheckVehicleExistsByIdAsync(vehicleId);
            if (!doesVehicleExists) throw new BadHttpRequestException("O Vehicle não existe");
            return await _repository.GetByVehicleIdAsync(vehicleId);
        }

        public async Task<Movimentations> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }


        public async Task AddAsync(Movimentations Movimentations)
        {
            var movimentacaoError = await _validateMovimentation(Movimentations);
            if (movimentacaoError != null) throw movimentacaoError;

            await _repository.AddAsync(Movimentations);
        }

        public async Task UpdateAsync(Movimentations Movimentations)
        {
            var movimentacaoError = await _validateMovimentation(Movimentations);
            if (movimentacaoError != null) throw movimentacaoError;

            await _repository.UpdateAsync(Movimentations);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }


        private async Task<BadHttpRequestException?> _validateMovimentation(Movimentations Movimentations)
        {
            string? badRequestmessage = null;

            var doesVehicleExists = await _vehicleService.CheckVehicleExistsByIdAsync(Movimentations.VehicleId);
            if (!doesVehicleExists) badRequestmessage = "O Veículo não existe";

            var doesEstablishmentExists = await _establishmentService.CheckEstablishmentExistsByIdAsync(Movimentations.EstablishmentId);
            if (!doesEstablishmentExists) badRequestmessage = "O Estabelecimento não existe";

            if (badRequestmessage != null)
            {
                return new BadHttpRequestException(badRequestmessage);
            }
            else return null;
        }

    }
}