using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repositories.Interfaces;
using EstacionamentoAPI.Services.Interfaces;
using EstacionamentoAPI.Validators.Interfaces;

namespace EstacionamentoAPI.Services
{
    public class MovimentationService : IMovimentationService
    {
        private readonly IMovimentationRepository _repository;
        private readonly IEstablishmentService _establishmentService;
        private readonly IVehicleService _vehicleService;
        private readonly IMovimentationValidator _movimentationValidator;

        public MovimentationService(IMovimentationRepository repository, IEstablishmentService establishmentService, IVehicleService vehicleService, IMovimentationValidator movimentationValidator)
        {
            _repository = repository;
            _establishmentService = establishmentService;
            _vehicleService = vehicleService;
            _movimentationValidator = movimentationValidator;
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


        public async Task CheckIn(int establishmentId, int vehicleId, DateTime dateTime)
        {

            var movimentacaoError = await _movimentationValidator.ValidateVehicleAndEstablishment(vehicleId: vehicleId, establishmentId: establishmentId);
            if (movimentacaoError != null) throw movimentacaoError;

            var lastVehicleCheckin = await _repository.GetLastByVehicleId(vehicleId);

            bool doesVehicleHaveActiveCheckin = lastVehicleCheckin != null && lastVehicleCheckin?.CheckoutAt == null;
            if (doesVehicleHaveActiveCheckin) throw new BadHttpRequestException("O veículo já possui um checkIn ativo");

            var establishmentStatus = await _establishmentService.GetEstablishmentStatusByIdAsync(establishmentId);
            //TODO: Separar essa lógica em classes diferentes Carro/Moto (Polimorfismo)
            var vehicleType = await _vehicleService.GetVehicleTypeByIdAsync(vehicleId);

            if (vehicleType == "Carro" && establishmentStatus.AvailableCarSpaces == 0) throw new BadHttpRequestException("O estabelecimento não tem vaga para o veículo");
            if (vehicleType == "Moto" && establishmentStatus.AvailableMotorcycleSpaces == 0) throw new BadHttpRequestException("O estabelecimento não tem vaga para o veículo");

            var movimentation = new Movimentations
            {
                EstablishmentId = establishmentId,
                VehicleId = vehicleId,
                CheckInAt = dateTime

            };

            await _repository.AddAsync(movimentation);
        }

        public async Task CheckOut(int movimentationId, DateTime dateTime)
        {
            var checkInMovimentation = await _repository.GetByIdAsync(movimentationId);
            if (checkInMovimentation == null) throw new BadHttpRequestException("CheckIn não encontrado!");

            if (checkInMovimentation.CheckoutAt != null) throw new BadHttpRequestException("CheckOut já realizado!");

            var checkOutedMovimentation = checkInMovimentation;

            checkOutedMovimentation.CheckoutAt = dateTime;

            await _repository.UpdateAsync(checkOutedMovimentation);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}