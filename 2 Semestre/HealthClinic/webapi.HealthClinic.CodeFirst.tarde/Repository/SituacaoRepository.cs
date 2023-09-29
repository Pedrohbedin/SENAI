using System;
using System.Collections.Generic;
using System.Linq;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    /// <summary>
    /// Implementação do repositório de situações.
    /// </summary>
    public class SituacaoRepository : ISituacaoRepository
    {
        /// <summary>
        /// O contexto do banco de dados.
        /// </summary>
        private readonly HealthClinicContext ctx;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="SituacaoRepository"/>.
        /// </summary>
        public SituacaoRepository()
        {
            ctx = new HealthClinicContext();
        }

        /// <inheritdoc/>
        public void Atualizar(Situacao situacao, Guid id)
        {
            Situacao situacaoAchada = BuscarPorId(id);

            if (situacaoAchada != null)
            {
                situacaoAchada.SituacaoValor = situacao.SituacaoValor;
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public Situacao BuscarPorId(Guid Id)
        {
            return ctx.Situacao.FirstOrDefault(x => x.IdSituacao == Id)!;
        }

        /// <inheritdoc/>
        public void Cadastrar(Situacao situacao)
        {
            ctx.Situacao.Add(situacao);
            ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void Deletar(Guid Id)
        {
            Situacao situacao = BuscarPorId(Id);
            if (situacao != null)
            {
                ctx.Situacao.Remove(situacao);
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public List<Situacao> Listar()
        {
            return ctx.Situacao.ToList();
        }
    }
}
