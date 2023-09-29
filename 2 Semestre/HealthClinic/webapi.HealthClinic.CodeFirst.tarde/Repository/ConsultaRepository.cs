using System;
using System.Collections.Generic;
using System.Linq;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    /// <summary>
    /// Implementação do repositório de consultas.
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {
        /// <summary>
        /// O contexto do banco de dados.
        /// </summary>
        private readonly HealthClinicContext ctx;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ConsultaRepository"/>.
        /// </summary>
        public ConsultaRepository() => ctx = new HealthClinicContext();

        /// <inheritdoc/>
        public void Agendar(Consultas consulta)
        {
            ctx.Consultas.Add(consulta);
            ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void Atualizar(Consultas consulta, Guid Id)
        {
            Consultas consultaExistente = BuscarPorId(Id);
            if (consultaExistente != null)
            {
                consultaExistente.Descricao = consulta.Descricao;
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public Consultas BuscarPorId(Guid Id) => ctx.Consultas.FirstOrDefault(x => x.IdConsulta == Id)!;

        /// <inheritdoc/>
        public void Cancelar(Guid id)
        {
            Consultas consulta = ctx.Consultas.FirstOrDefault(x => x.IdConsulta == id)!;
            if (consulta != null)
            {
                ctx.Consultas.Remove(consulta);
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public void IncluirDescricao(string descricao, Guid Id)
        {
            Consultas consulta = ctx.Consultas.FirstOrDefault(x => x.IdConsulta == Id)!;
            if (consulta != null)
            {
                consulta.Descricao = descricao;
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public List<Consultas> Listar() => ctx.Consultas.ToList();

        /// <inheritdoc/>
        public List<Consultas> ListarPorUsuario(Guid idUsuario)
        {
            List<Consultas> MinhasConsultas = ctx.Consultas
                .Where(x => x.Medico.IdUsuario == idUsuario || x.Paciente.IdUsuario == idUsuario)
                .ToList();

            return MinhasConsultas;
        }
    }
}
