using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();
        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!!!")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição é obrigatória!!!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de lançamento é obrigatória!!!")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "O preço do jogo é obrigatório")]
        public Decimal Preco { get; set; }
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudio? estudio { get; set; }
    }
}
