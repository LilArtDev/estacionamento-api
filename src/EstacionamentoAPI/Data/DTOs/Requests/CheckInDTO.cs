using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.DTOs.Requests
{
    public class CheckInDto
    {
        public required int VehicleId { get; set; }
        public required int EstablishmentId { get; set; }
        public DateTime? DateTime { get; set; }

    }
}