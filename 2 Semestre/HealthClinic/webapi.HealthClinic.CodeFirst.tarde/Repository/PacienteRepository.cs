using System;
using System.Collections.Generic;
using System.Linq;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    /// <summary>
    /// Implementação do repositório de pacientes.
    /// </summary>
    public class PacienteRepository : IPacienteRepository
    {
        /// <summary>
        /// O contexto do banco de dados.
        /// </summary>
        private readonly HealthClinicContext ctx;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="PacienteRepository"/>.
        /// </summary>
        public PacienteRepository()
        {
            ctx = new HealthClinicContext();
        }

        /// <inheritdoc/>
        public void Atualizar(Paciente paciente, Guid Id)
        {
            Paciente pacienteAchado = BuscarPorId(Id);

            if (pacienteAchado != null)
            {
                pacienteAchado.DataNascimento = paciente.DataNascimento;
                pacienteAchado.IdUsuario = paciente.IdUsuario;
                pacienteAchado.Endereco = paciente.Endereco;
                pacienteAchado.Telefone = paciente.Telefone;
                pacienteAchado.Usuario = paciente.Usuario;
                pacienteAchado.Nome = paciente.Nome;
                pacienteAchado.CEP = paciente.CEP;
                pacienteAchado.CPF = paciente.CPF;
                pacienteAchado.RG = paciente.RG;

                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public Paciente BuscarPorId(Guid id) => ctx.Paciente.FirstOrDefault(x => x.IdPaciente == id)!;

        /// <inheritdoc/>
        public void Cadastrar(Paciente paciente)
        {
            try
            {
                ctx.Paciente.Add(paciente);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public void Deletar(Guid id)
        {
            Paciente paciente = BuscarPorId(id);
            if (paciente != null)
            {
                ctx.Paciente.Remove(paciente);
            }
        }

        /// <inheritdoc/>
        public List<Paciente> Listar()
        {
            try
            {
                List<Paciente> pacientes = ctx.Paciente.ToList();
                foreach (Paciente paciente in pacientes)
                {
                    paciente.Usuario = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == paciente.IdUsuario);
                }
                return pacientes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
