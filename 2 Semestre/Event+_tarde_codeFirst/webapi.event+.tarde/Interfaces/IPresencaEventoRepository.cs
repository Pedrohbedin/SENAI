using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IPresencaEventoRepository
    {
        void Cadastrar(PresencaEvento presencaEvento);
        void Deletar(Guid id);
        List<PresencaEvento> Listar();
        void Atualizar(Guid id, PresencaEvento presencaEvento);
        List<PresencaEvento> ListarMinhas(Guid id);
    }
}
