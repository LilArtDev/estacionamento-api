using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models
{
    public class Veiculo
    {
        public int Id { get; set; }

        [Required]
        public required string Marca { get; set; }

        [Required]
        public required string Modelo { get; set; }

        [Required]
        public required string Cor { get; set; }

        [Required]
        public required string Placa { get; set; }

        [Required]
        public required string Tipo { get; set; }
    }
}