using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models

{
    public class Establishment
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Document { get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        public required string Telephone { get; set; }

        [Required]
        public int MotorcycleSpaces { get; set; }

        [Required]
        public int CarSpaces { get; set; }
    }
}