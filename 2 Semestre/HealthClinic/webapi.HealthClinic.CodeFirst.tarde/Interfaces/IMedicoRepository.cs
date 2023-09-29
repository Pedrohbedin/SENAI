using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    /// <summary>
    /// Define as operações disponíveis para o repositório de médicos.
    /// </summary>
    public interface IMedicoRepository
    {
        /// <summary>
        /// Cadastra um novo médico.
        /// </summary>
        /// <param name="medico">O médico a ser cadastrado.</param>
        void Cadastrar(Medico medico);

        /// <summary>
        /// Deleta um médico pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id do médico a ser deletado.</param>
        void Deletar(Guid Id);

        /// <summary>
        /// Lista todos os médicos cadastrados.
        /// </summary>
        /// <returns>Uma lista de médicos.</returns>
        List<Medico> Listar();

        /// <summary>
        /// Busca um médico pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id do médico a ser buscado.</param>
        /// <returns>O médico encontrado ou null se não encontrado.</returns>
        Medico BuscarPorId(Guid Id);

        /// <summary>
        /// Atualiza os dados de um médico.
        /// </summary>
        /// <param name="medico">O médico com os dados atualizados.</param>
        /// <param name="Id">O Id do médico a ser atualizado.</param>
        void Atualizar(Medico medico, Guid Id);
    }
}
