using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    /// <summary>
    /// Representa uma consulta médica.
    /// </summary>
    public class Consultas
    {
        /// <summary>
        /// Obtém ou define o Id da consulta.
        /// </summary>
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Obtém ou define o Id do médico associado à consulta.
        /// </summary>
        [Required(ErrorMessage = "O Id do médico é um campo obrigatório")]
        public Guid IdMedico { get; set; }

        /// <summary>
        /// Obtém ou define a referência ao médico associado à consulta.
        /// </summary>
        [ForeignKey(nameof(IdMedico))]
        public Medico Medico { get; set; }

        /// <summary>
        /// Obtém ou define o Id do paciente associado à consulta.
        /// </summary>
        [Required(ErrorMessage = "O Id do paciente é um campo obrigatório")]
        public Guid IdPaciente { get; set; }

        /// <summary>
        /// Obtém ou define a referência ao paciente associado à consulta.
        /// </summary>
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }

        /// <summary>
        /// Obtém ou define a data de agendamento da consulta.
        /// </summary>
        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de agendamento é um campo obrigatório")]
        public DateTime DataAgendamento { get; set; }

        /// <summary>
        /// Obtém ou define a descrição da consulta.
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A descrição é um campo obrigatório")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Obtém ou define o Id da situação da consulta.
        /// </summary>
        public Guid IdSituacao { get; set; }

        /// <summary>
        /// Obtém ou define a referência à situação da consulta.
        /// </summary>
        [ForeignKey(nameof(IdSituacao))]
        public Situacao? Situacao { get; set; }
    }
}
