using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamentoAPI.Models
{
    public class Movimentations
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public required int VehicleId { get; set; }

        public Vehicle? Vehicle { get; set; }

        [Required]
        [ForeignKey("Establishment")]
        public required int EstablishmentId { get; set; }

        public Establishment? Establishment { get; set; }

        [Required]
        public DateTime CheckInAt { get; set; }

        public DateTime? CheckoutAt { get; set; }
    }
}