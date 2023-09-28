using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);
        void Deletar(Guid id);
        List<TipoUsuario> Listar();
        void Atualizar(TipoUsuario tipoUsuario, Guid Id);
    }
}
