using System;
using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    /// <summary>
    /// Define as operações disponíveis para o repositório de usuários.
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuario">O usuário a ser cadastrado.</param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Deleta um usuário pelo seu Id.
        /// </summary>
        /// <param name="id">O Id do usuário a ser deletado.</param>
        void Deletar(Guid id);

        /// <summary>
        /// Busca um usuário pelo seu email e senha.
        /// </summary>
        /// <param name="email">O email do usuário.</param>
        /// <param name="senha">A senha do usuário.</param>
        /// <returns>O usuário encontrado ou null se não encontrado.</returns>
        Usuario BuscarPorEmailESenha(string email, string senha);

        /// <summary>
        /// Atualiza os dados de um usuário.
        /// </summary>
        /// <param name="usuario">O usuário com os dados atualizados.</param>
        /// <param name="id">O Id do usuário a ser atualizado.</param>
        void Atualizar(Usuario usuario, Guid id);

        /// <summary>
        /// Busca um usuário pelo seu Id.
        /// </summary>
        /// <param name="id">O Id do usuário a ser buscado.</param>
        /// <returns>O usuário encontrado ou null se não encontrado.</returns>
        Usuario BuscarPorId(Guid id);
    }
}
