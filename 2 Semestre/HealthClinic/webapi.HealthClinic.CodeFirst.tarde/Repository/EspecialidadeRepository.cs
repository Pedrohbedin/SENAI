using System;
using System.Collections.Generic;
using System.Linq;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    /// <summary>
    /// Implementação do repositório de especialidades.
    /// </summary>
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        /// <summary>
        /// O contexto do banco de dados.
        /// </summary>
        private readonly HealthClinicContext ctx;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="EspecialidadeRepository"/>.
        /// </summary>
        public EspecialidadeRepository()
        {
            ctx = new HealthClinicContext();
        }

        /// <inheritdoc/>
        public void Atualizar(Especialidade especialidade, Guid Id)
        {
            Especialidade especialidadeExistente = BuscarPorId(Id);
            if (especialidadeExistente != null)
            {
                especialidadeExistente.Titulo = especialidade.Titulo;
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public Especialidade BuscarPorId(Guid Id) => ctx.Especialidade.FirstOrDefault(x => x.IdEspecialidade == Id)!;

        /// <inheritdoc/>
        public void Cadastrar(Especialidade especialidade)
        {
            ctx.Especialidade.Add(especialidade);
            ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void Deletar(Guid Id)
        {
            Especialidade especialidade = ctx.Especialidade.FirstOrDefault(x => x.IdEspecialidade == Id)!;
            if (especialidade != null)
            {
                ctx.Especialidade.Remove(especialidade);
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public List<Especialidade> Listar() => ctx.Especialidade.ToList();
    }
}
