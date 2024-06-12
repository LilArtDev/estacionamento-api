using System.ComponentModel.DataAnnotations;
using EstacionamentoAPI.Shared;

namespace EstacionamentoAPI.DTOs
{
    public class MovimentationDTO
    {
        [Required(ErrorMessage = "O ID do veículo é obrigatório")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "O ID do establishment é obrigatório")]
        public int EstablishmentId { get; set; }

        [Required(ErrorMessage = "A data e hora são obrigatórias")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "O tipo de movimentação é obrigatório")]
        public MovimentionType Type { get; set; }
    }
}