using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EstacionamentoAPI.Shared;

namespace EstacionamentoAPI.Models
{
    public class RegistroMovimentacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }

        public Veiculo Veiculo { get; set; }

        [Required]
        [ForeignKey("Estabelecimento")]
        public int EstabelecimentoId { get; set; }

        public Estabelecimento Estabelecimento { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        [StringLength(10)]
        public required TipoMovimentacao Tipo { get; set; }
    }
}