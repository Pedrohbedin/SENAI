using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    /// <summary>
    /// Representa uma clínica.
    /// </summary>
    [Table(nameof(Clinica))]
    [Microsoft.EntityFrameworkCore.Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        /// <summary>
        /// Obtém ou define o Id da clínica.
        /// </summary>
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Obtém ou define o nome da clínica.
        /// </summary>
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome é um campo obrigatório")]
        public string? Nome { get; set; }

        /// <summary>
        /// Obtém ou define o CNPJ da clínica.
        /// </summary>
        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é um campo obrigatório")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        /// <summary>
        /// Obtém ou define a razão social da clínica.
        /// </summary>
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "A razão social é um campo obrigatório")]
        public string? RazaoSocial { get; set; }

        /// <summary>
        /// Obtém ou define o horário de abertura da clínica.
        /// </summary>
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de abertura é um campo obrigatório")]
        public TimeOnly HoraAbertura { get; set; }

        /// <summary>
        /// Obtém ou define o horário de fechamento da clínica.
        /// </summary>
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de fechamento é um campo obrigatório")]
        public TimeOnly HoraFechamento { get; set; }

        /// <summary>
        /// Obtém ou define o endereço da clínica.
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço é um campo obrigatório")]
        public string? Endereco { get; set; }
    }
}
