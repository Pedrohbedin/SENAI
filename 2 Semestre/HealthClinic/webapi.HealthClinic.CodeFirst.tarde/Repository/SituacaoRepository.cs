using Microsoft.VisualBasic;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    public class SituacaoRepository : ISituacaoRepository
    {
        private readonly HealthClinicContext ctx;

        public SituacaoRepository()
        {
            ctx = new HealthClinicContext();
        }

        public Situacao BuscarPorId(Guid Id)
        {
            return ctx.Situacao.FirstOrDefault(x => x.idSituacao == Id);
        }

        public void Cadastrar(Situacao situacao)
        {
            ctx.Situacao.Add(situacao);
            ctx.SaveChanges();
        }

        public void Deletar(Guid Id)
        {
            ctx.Situacao.Remove(ctx.Situacao.FirstOrDefault(x => x.idSituacao == Id));
            ctx.SaveChanges();
        }

        public List<Situacao> Listar()
        {
            return ctx.Situacao.ToList();
        }
    }
}
