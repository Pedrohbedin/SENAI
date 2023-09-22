using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    [Table(nameof(Medico))]
    [Microsoft.EntityFrameworkCore.Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "O id do usuário é um campo obrigatorio")]
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
        [Required(ErrorMessage = "O id da especialidade é um campo obrigatório")]
        public Guid IdEspecialidade { get; set; }
        [ForeignKey(nameof(Especialidade))]
        public Especialidade? Especialidade { get; set; }
        [Required(ErrorMessage = "O id clinica é um campo obrigatório")]
        public Guid IdClinica { get; set; }
        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é um campo obrigatório")]
        public string? Nome { get; set; }
        [Column(TypeName = "CHAR(7)")]
        [Required(ErrorMessage = "O CRM é um campo obrigatório")]
        public string? CRM { get; set; }
    }
}
