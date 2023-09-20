using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext ctx;

        public InstituicaoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            BuscarPorId(id).CNPJ = instituicao.CNPJ;
            BuscarPorId(id).NomeFantasia = instituicao.NomeFantasia;
            BuscarPorId(id).Endereco = instituicao.Endereco;

            ctx.SaveChanges();
        }

        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Instituicao.FirstOrDefault(x => x.IdInstituicao == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                ctx.Instituicao.Add(instituicao);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                ctx.Instituicao.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
