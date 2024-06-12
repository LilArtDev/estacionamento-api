using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Validators.Interfaces
{
    public interface IMovimentationValidator
    {
        Task<BadHttpRequestException?> ValidateVehicleAndEstablishment(int vehicleId, int establishmentId);
    }
}