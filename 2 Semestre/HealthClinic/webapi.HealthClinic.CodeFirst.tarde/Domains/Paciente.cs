using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    [Table(nameof(Paciente))]
    [Microsoft.EntityFrameworkCore.Index(nameof(CEP), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "O Id do Usuário é um campo obrigatório")]
        public Guid idUsuario { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Usuario? Usuario { get; set; }
        [Column(TypeName = "VARCHAR(110)")]
        [Required(ErrorMessage = "O nome do usuário é um campo obrigatório")]
        public string? Nome { get; set; }
        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de nascimento do usuário é um campo obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O telefone do usuário é um campo obrigatório")]
        public string? Telefone { get; set; }
        [Column(TypeName = "CHAR(9)")]
        [Required(ErrorMessage = "O RG é um campo obrigatório")]
        public string? RG { get; set; }
        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O CPF do usuário é um campo obrigatório")]
        public string? CPF { get; set; }
        [Column(TypeName = "CHAR(8)")]
        [Required(ErrorMessage = "O CEP do usuário é um campo obrigatório")]
        public string? CEP { get; set; }
        [Column(TypeName = "VARCHAR(110)")]
        [Required(ErrorMessage = "O Endereço do usuário é um campo obrigatório")]
        public string? Endereco { get; set; }
    }
}
