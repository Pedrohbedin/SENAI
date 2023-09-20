using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext ctx;
        public UsuarioRepository()
        {
            ctx = new EventContext();
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {

                Usuario usuarioAchado = ctx.Usuarios.Select(u => new Usuario
                {
                    idUsuario = u.idUsuario,
                    Name = u.Name,
                    Email = u.Email,
                    Senha = u.Senha,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.Email == email)!;
                
                if (usuarioAchado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioAchado.Senha!);
                    if (confere)
                    {
                        return usuarioAchado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioAchado = ctx.Usuarios.Select(u => new Usuario
                {
                    idUsuario = u.idUsuario,
                    Name = u.Name,
                    Email = u.Email,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.idUsuario == id)!;
                return usuarioAchado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuarios.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
