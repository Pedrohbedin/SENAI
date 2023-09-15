using webapi.inlock.codefirst.Contexts;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;

namespace webapi.inlock.codefirst.Repository
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly InlockContext ctx;

        public TiposUsuarioRepository()
        {
            ctx = new InlockContext();
        }
        public TiposUsuario BuscarPorId(Guid Id)
        {
            return (ctx.TiposUsuarios.FirstOrDefault(x => x.IdTiposUsuario == Id)!);
        }
    }
}
