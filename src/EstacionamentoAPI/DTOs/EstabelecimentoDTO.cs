using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EstacionamentoAPI.DTOs
{
    [SwaggerSchema(Description = "DTO para criar ou atualizar um estabelecimento")]
    public class EstabelecimentoDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [SwaggerSchema(Description = "Nome do estabelecimento", Nullable = false)]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        [SwaggerSchema(Description = "CNPJ do estabelecimento", Nullable = false)]
        public required string Cnpj { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres")]
        [SwaggerSchema(Description = "Endereço do estabelecimento", Nullable = false)]
        public required string Endereco { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres")]
        [SwaggerSchema(Description = "Telefone do estabelecimento", Nullable = false)]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "A quantidade de vagas para motos é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de vagas para motos deve ser um número positivo")]
        [SwaggerSchema(Description = "Quantidade de vagas para motos", Nullable = false)]
        public required int VagasMotos { get; set; }

        [Required(ErrorMessage = "A quantidade de vagas para carros é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de vagas para carros deve ser um número positivo")]
        [SwaggerSchema(Description = "Quantidade de vagas para carros", Nullable = false)]
        public required int VagasCarros { get; set; }
    }
}