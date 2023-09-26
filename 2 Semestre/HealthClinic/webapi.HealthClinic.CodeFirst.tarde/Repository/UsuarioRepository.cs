using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Utils;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext ctx;
        public UsuarioRepository()
        {
            ctx = new HealthClinicContext();
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {

                Usuario usuarioAchado = ctx.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Email = u.Email,
                    Senha = u.Senha,
                    IdTipoUsuario = u.IdTipoUsuario,

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

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                ctx.Usuario.Remove(ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id)!);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void BuscarPorId(Guid id)
        {
            ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id);
        }
    }
}
