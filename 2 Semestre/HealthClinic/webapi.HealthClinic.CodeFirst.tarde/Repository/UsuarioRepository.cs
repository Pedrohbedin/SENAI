using System;
using System.Linq;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Utils;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    /// <summary>
    /// Implementação do repositório de usuários.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// O contexto do banco de dados.
        /// </summary>
        private readonly HealthClinicContext ctx;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UsuarioRepository"/>.
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new HealthClinicContext();
        }

        /// <inheritdoc/>
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioAchado = ctx.Usuario
                    .Select(u => new Usuario
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
                    })
                    .FirstOrDefault(u => u.Email == email)!;

                if (usuarioAchado != null && Criptografia.CompararHash(senha, usuarioAchado.Senha!))
                {
                    return usuarioAchado;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuario = BuscarPorId(id);
                if (usuario != null)
                {
                    ctx.Usuario.Remove(usuario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public Usuario BuscarPorId(Guid id)
        {
            return ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id)!;
        }

        /// <inheritdoc/>
        public void Atualizar(Usuario usuario, Guid id)
        {
            Usuario usuarioAchado = BuscarPorId(id);

            if (usuarioAchado != null)
            {
                usuarioAchado.TipoUsuario = usuario.TipoUsuario;
                usuarioAchado.IdTipoUsuario = usuario.IdTipoUsuario;
                usuarioAchado.Senha = Criptografia.GerarHash(usuario.Senha!);
                usuarioAchado.Email = usuario.Email;

                ctx.SaveChanges();
            }
        }
    }
}
