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


        public async Task CheckIn(Movimentations movimentation)
        {

            var movimentacaoError = await _validateMovimentation(movimentation);
            if (movimentacaoError != null) throw movimentacaoError;

            var lastVehicleCheckin = await _repository.GetLastByVehicleId(movimentation.VehicleId);

            bool doesVehicleHaveActiveCheckin = lastVehicleCheckin != null && lastVehicleCheckin?.CheckoutAt == null;
            if (doesVehicleHaveActiveCheckin) throw new BadHttpRequestException("O veículo possui um checkIn ativo");

            var establishmentStatus = await _establishmentService.GetEstablishmentStatusByIdAsync(movimentation.EstablishmentId);
            //TODO: Separar essa lógica em classes diferentes Carro/Moto
            var vehicleType = await _vehicleService.GetVehicleTypeByIdAsync(movimentation.VehicleId);

            if (vehicleType == "Carro" && establishmentStatus.AvailableCarSpaces == 0) throw new BadHttpRequestException("O estabelecimento não tem vaga para o veículo");
            if (vehicleType == "Moto" && establishmentStatus.AvailableMotorcycleSpaces == 0) throw new BadHttpRequestException("O estabelecimento não tem vaga para o veículo");

            await _repository.AddAsync(movimentation);
        }

        public async Task CheckOut(Movimentations movimentation)
        {
            var movimentacaoError = await _validateMovimentation(movimentation);
            if (movimentacaoError != null) throw movimentacaoError;

            //TODO: Ver se existe o checkin estabelecimento tem vaga
            //TODO: Ver se o carro ja realizou checkout


            await _repository.UpdateAsync(movimentation);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }


        private async Task<BadHttpRequestException?> _validateMovimentation(Movimentations movimentation)
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