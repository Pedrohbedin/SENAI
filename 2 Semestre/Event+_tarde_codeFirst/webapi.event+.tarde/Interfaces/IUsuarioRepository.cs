using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPorEmailESenha(string email, string senha);
        Usuario BuscarPorId(Guid id);
        void Cadastrar(Usuario usuario);
    }
}
