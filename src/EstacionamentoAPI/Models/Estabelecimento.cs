using System.ComponentModel.DataAnnotations;

namespace EstacionamentoAPI.Models

{
    public class Estabelecimento
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cnpj { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public int VagasMotos { get; set; }

        [Required]
        public int VagasCarros { get; set; }
    }
}