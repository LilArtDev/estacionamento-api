using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.DTOs
{
    [SwaggerSchema(Description = "DTO para criar ou atualizar um veículo")]
    public class VehicleDTO
    {
        [Required(ErrorMessage = "A marca é obrigatória")]
        [StringLength(50, ErrorMessage = "A marca deve ter no máximo 50 caracteres")]
        [SwaggerSchema(Description = "Marca do veículo", Nullable = false)]
        public required string Brand { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório")]
        [StringLength(50, ErrorMessage = "O modelo deve ter no máximo 50 caracteres")]
        [SwaggerSchema(Description = "Modelo do veículo", Nullable = false)]
        public required string Model { get; set; }

        [Required(ErrorMessage = "A cor é obrigatória")]
        [StringLength(20, ErrorMessage = "A cor deve ter no máximo 20 caracteres")]
        [SwaggerSchema(Description = "Cor do veículo", Nullable = false)]
        public required string Color { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória")]
        [StringLength(7, ErrorMessage = "A placa deve ter no máximo 7 caracteres")]
        [SwaggerSchema(Description = "Placa do veículo", Nullable = false)]
        public required string LicensePlate { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório")]
        [StringLength(20, ErrorMessage = "O tipo deve ter no máximo 20 caracteres")]
        [SwaggerSchema(Description = "Tipo do veículo", Nullable = false)]
        public required string Type { get; set; }
    }
}