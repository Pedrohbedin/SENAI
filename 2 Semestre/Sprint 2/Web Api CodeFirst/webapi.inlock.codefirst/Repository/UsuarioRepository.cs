using Microsoft.AspNetCore.Http.HttpResults;
using webapi.inlock.codefirst.Contexts;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Utilis;

namespace webapi.inlock.codefirst.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InlockContext ctx;

        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Email == email);

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere) 
                    {
                        return usuarioBuscado;
                    }
                    else
                    {
                        return null!;
                    }
                }
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
    }
}
