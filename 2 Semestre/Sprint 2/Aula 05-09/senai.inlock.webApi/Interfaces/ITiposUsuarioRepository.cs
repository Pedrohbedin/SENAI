using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        TiposUsuarioDomain BuscarPorId(int id);
    }
}
