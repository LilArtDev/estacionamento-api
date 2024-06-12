using System.ComponentModel.DataAnnotations;
using EstacionamentoAPI.Shared;

namespace EstacionamentoAPI.DTOs
{
    public class RegistroMovimentacaoDTO
    {
        [Required(ErrorMessage = "O ID do veículo é obrigatório")]
        public int VeiculoId { get; set; }

        [Required(ErrorMessage = "O ID do estabelecimento é obrigatório")]
        public int EstabelecimentoId { get; set; }

        [Required(ErrorMessage = "A data e hora são obrigatórias")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O tipo de movimentação é obrigatório")]
        public TipoMovimentacao Tipo { get; set; }
    }
}