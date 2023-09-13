using Microsoft.EntityFrameworkCore;
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
            Estudio _estudio = BuscarPorId(Id);

            if (estudio != null) 
            { 
                _estudio.Nome = estudio.Nome;

                ctx.SaveChanges();
            }

        }
        public Estudio BuscarPorId(Guid Id) 
        {
            Estudio estudio = ctx.Estudios.Find(Id);

            if(estudio != null)
            {
                return estudio;
            }

            else
            {
                return null;
            }
        }

        public void Cadastrar(Estudio estudio)
        {

            ctx.Estudios.Add(estudio);

            ctx.SaveChanges();
        }

        public void Deletar(Guid Id)
        {
            Estudio estudio = BuscarPorId(Id);

            if(estudio != null)
            {
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }

        public List<Estudio> Listar() => ctx.Estudios.ToList();

        public List<Estudio> ListarComJogos() => ctx.Estudios.Include(e => e.Jogos).ToList();
    }
}
