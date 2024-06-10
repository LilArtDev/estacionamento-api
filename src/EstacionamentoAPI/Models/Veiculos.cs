using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models
{
    public class Veiculo
    {
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public string Tipo { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }

        [Required]
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
    }
}