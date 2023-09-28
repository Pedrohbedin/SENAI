using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Deletar(Guid id);
        Usuario BuscarPorEmailESenha(string email, string senha);
        Usuario Atualizar(Usuario usuario, Guid Id);
    }
}
