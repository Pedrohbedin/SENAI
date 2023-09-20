using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoEventoRepository
    {
        public void Cadastrar(TipoEvento tipoEvento);
        public void Deletar(Guid Id);
        public List<TipoEvento> Listar();
        public void Atualizar(Guid Id, TipoEvento tipoEvento);
        public TipoEvento BuscarPorId(Guid Id);
    }
}
