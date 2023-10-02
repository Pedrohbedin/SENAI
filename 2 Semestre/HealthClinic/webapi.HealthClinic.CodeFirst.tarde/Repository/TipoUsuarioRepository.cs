using System.Data;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    /// <summary>
    /// Implementação do repositório de tipos de usuário.
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// O contexto do banco de dados.
        /// </summary>
        private readonly HealthClinicContext ctx;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="TipoUsuarioRepository"/>.
        /// </summary>
        public TipoUsuarioRepository()
        {
            ctx = new HealthClinicContext();
        }

        /// <inheritdoc/>
        public void Atualizar(TipoUsuario tipoUsuario, Guid id)
        {
            TipoUsuario tipoUsuarioExistente = BuscarPorId(id);

            if (tipoUsuarioExistente != null)
            {
                tipoUsuarioExistente.Titulo = tipoUsuario.Titulo;
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public TipoUsuario BuscarPorId(Guid id)
        {
            return ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;
        }

        /// <inheritdoc/>
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipoUsuario);
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
            TipoUsuario tipoUsuario = BuscarPorId(id);
            if (tipoUsuario != null)
            {
                ctx.TipoUsuario.Remove(tipoUsuario);
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
