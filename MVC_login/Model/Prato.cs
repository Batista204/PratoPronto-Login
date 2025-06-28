using System.ComponentModel.DataAnnotations;

namespace PratoPronto.Models
{
    public class Prato
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        public string Foto { get; set; }

        public string Categoria { get; set; }
    }
}
