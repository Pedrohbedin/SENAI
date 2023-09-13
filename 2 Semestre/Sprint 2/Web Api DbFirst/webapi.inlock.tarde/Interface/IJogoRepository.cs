using webapi.inlock.tarde.Domains;

namespace webapi.inlock.tarde.Interface
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();

        Jogo BuscarPorId(Guid Id);

        void Cadastrar(Jogo jogo);

        void Atualizar(Guid Id, Jogo jogo);

        void Deletar(Guid Id);
    }
}
