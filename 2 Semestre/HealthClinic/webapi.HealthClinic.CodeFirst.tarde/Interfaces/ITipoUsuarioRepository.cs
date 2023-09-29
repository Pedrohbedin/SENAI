using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    /// <summary>
    /// Interface para operações do repositório de TipoUsuario.
    /// </summary>
    public interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo TipoUsuario.
        /// </summary>
        /// <param name="tipoUsuario">O TipoUsuario a ser cadastrado.</param>
        void Cadastrar(TipoUsuario tipoUsuario);

        /// <summary>
        /// Deleta um TipoUsuario pelo seu Id.
        /// </summary>
        /// <param name="id">O Id do TipoUsuario a ser deletado.</param>
        void Deletar(Guid id);

        /// <summary>
        /// Lista todos os tipos de usuário.
        /// </summary>
        /// <returns>Uma lista de tipos de usuário.</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Atualiza um TipoUsuario pelo seu Id.
        /// </summary>
        /// <param name="tipoUsuario">Os dados do TipoUsuario a serem atualizados.</param>
        /// <param name="Id">O Id do TipoUsuario a ser atualizado.</param>
        void Atualizar(TipoUsuario tipoUsuario, Guid Id);
    }
}