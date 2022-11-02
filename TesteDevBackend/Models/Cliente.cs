using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TesteDev.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? CPF { get; set; }

        [DisplayName("Cliente")]
        public string? Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [DisplayFormat()]
        public int? sexo { get; set; } //ISO/IEC 5218
        public string? Endereco { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public DateTime? DataInserido { get; set; }
        public DateTime? DataExcluido { get; set; }
    }
}
