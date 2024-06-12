using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public required string Brand { get; set; }

        [Required]
        public required string Model { get; set; }

        [Required]
        public required string Color { get; set; }

        [Required]
        public required string LicensePlate { get; set; }

        [Required]
        public required string Type { get; set; }
    }
}