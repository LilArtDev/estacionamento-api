using EstacionamentoAPI.Models;
using EstacionamentoAPI.Services.Interfaces;
using EstacionamentoAPI.Validators.Interfaces;

namespace EstacionamentoAPI.Validators
{
    public class MovimentationValidator : IMovimentationValidator
    {
        private readonly IVehicleService _vehicleService;
        private readonly IEstablishmentService _establishmentService;

        public MovimentationValidator(IVehicleService vehicleService, IEstablishmentService establishmentService)
        {
            _vehicleService = vehicleService;
            _establishmentService = establishmentService;
        }

        public async Task<BadHttpRequestException?> ValidateVehicleAndEstablishment(int vehicleId, int establishmentId)
        {
            string? badRequestMessage = null;

            var doesVehicleExists = await _vehicleService.CheckVehicleExistsByIdAsync(vehicleId);
            if (!doesVehicleExists) badRequestMessage = "O Veículo não existe";

            var doesEstablishmentExists = await _establishmentService.CheckEstablishmentExistsByIdAsync(establishmentId);
            if (!doesEstablishmentExists) badRequestMessage = "O Estabelecimento não existe";

            if (badRequestMessage != null)
            {
                return new BadHttpRequestException(badRequestMessage);
            }
            else return null;
        }
    }
}