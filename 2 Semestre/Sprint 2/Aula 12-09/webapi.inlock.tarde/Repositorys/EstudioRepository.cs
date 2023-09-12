using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interface;

namespace webapi.inlock.tarde.Repositorys
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid Id, Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public Estudio BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> Listar() => ctx.Estudios.ToList();

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.ToList();
        }
    }
}
