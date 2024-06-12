using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.DTOs
{
    [SwaggerSchema(Description = "DTO para criar ou atualizar um establishment")]
    public class EstablishmentDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [SwaggerSchema(Description = "Name do establishment", Nullable = false)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        [SwaggerSchema(Description = "CNPJ do establishment", Nullable = false)]
        public required string Document { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres")]
        [SwaggerSchema(Description = "Endereço do establishment", Nullable = false)]
        public required string Address { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres")]
        [SwaggerSchema(Description = "Telephone do establishment", Nullable = false)]
        public required string Telephone { get; set; }

        [Required(ErrorMessage = "A quantidade de vagas para motos é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de vagas para motos deve ser um número positivo")]
        [SwaggerSchema(Description = "Quantidade de vagas para motos", Nullable = false)]
        public required int MotorcycleSpaces { get; set; }

        [Required(ErrorMessage = "A quantidade de vagas para carros é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de vagas para carros deve ser um número positivo")]
        [SwaggerSchema(Description = "Quantidade de vagas para carros", Nullable = false)]
        public required int CarSpaces { get; set; }
    }
}