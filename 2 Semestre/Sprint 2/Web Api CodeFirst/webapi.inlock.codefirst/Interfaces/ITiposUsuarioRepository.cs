using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        TiposUsuario BuscarPorId(Guid Id);
    }
}
