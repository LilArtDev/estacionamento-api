using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EstacionamentoAPI.Shared;

namespace EstacionamentoAPI.Models
{
    public class Movimentation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public Vehicle? Vehicle { get; set; }

        [Required]
        [ForeignKey("Establishment")]
        public int EstablishmentId { get; set; }

        public Establishment? Establishment { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(10)]
        public required MovimentionType Type { get; set; }
    }
}