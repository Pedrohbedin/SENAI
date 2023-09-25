using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    [Table(nameof(Clinica))]
    [Microsoft.EntityFrameworkCore.Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome é um campo obrigatório")]
        public string? Nome { get; set; }
        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é um campo obrigatório")]
        [StringLength(14)]
        public string? CNPJ { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "A razao social é um campo obrigatório")]
        public string? RazaoSocial { get; set; }
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horario de abertura é um campo obrigatório")]
        public TimeSpan? HoraAbertura { get; set; } 
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horario de fechamento é um campo obrigatório")]
        public TimeSpan? HoraFechamento { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço é um campo obrigatório")]
        public string? Endereco { get; set; }
    }
}
