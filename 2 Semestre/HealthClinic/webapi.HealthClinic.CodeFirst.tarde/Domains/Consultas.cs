using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    public class Consultas
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O Id do médico é um campo obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico Medico { get; set; }

        [Required(ErrorMessage = "O id do paciente é um campo obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de agendamento é um campo obrigatório")]
        public DateTime DataAgendamento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A descricao é um campo obrigatório")]
        public string? Descricao { get; set; }

        public Guid IdSituacao { get; set; }

        [ForeignKey(nameof(IdSituacao))]
        public Situacao? Situacao { get; set; }
    }
}