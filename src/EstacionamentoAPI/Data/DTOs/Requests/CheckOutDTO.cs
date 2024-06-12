using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.DTOs.Requests
{
    public class CheckOutDto
    {
        public DateTime? DateTime { get; set; }

    }
}