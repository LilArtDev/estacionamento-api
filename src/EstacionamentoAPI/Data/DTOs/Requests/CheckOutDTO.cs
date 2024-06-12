using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.DTOs.Requests
{
    public class CheckOut
    {
        public required int VehicleId { get; set; }
        public required int EstablishmentId { get; set; }
        public DateTime? DateTime { get; set; }

    }
}