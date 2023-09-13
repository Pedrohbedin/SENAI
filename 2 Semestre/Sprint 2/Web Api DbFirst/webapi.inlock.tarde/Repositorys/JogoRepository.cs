using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interface;

namespace webapi.inlock.tarde.Repositorys
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid Id, Jogo jogo)
        {
            Jogo jogoAchado = BuscarPorId(Id);
            if (jogoAchado != null)
            {
                jogoAchado.Nome = jogo.Nome;   
            }
        }

        public Jogo BuscarPorId(Guid Id) => ctx.Jogos.Find(Id);

        public void Cadastrar(Jogo jogo)
        {
            if (jogo != null)
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            } 
        }
        public void Deletar(Guid Id)
        {
            Jogo jogoAchado = BuscarPorId(Id);
            if (jogoAchado != null)
            {
                ctx.Jogos.Remove(jogoAchado);
                ctx.SaveChanges();
            }
        }
        public List<Jogo> Listar() => ctx.Jogos.ToList();
    }
}
