using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}
