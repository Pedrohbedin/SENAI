using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    /// <summary>
    /// Define as operações disponíveis para o repositório de clínicas.
    /// </summary>
    public interface IClinicaRepository
    {
        /// <summary>
        /// Cadastra uma nova clínica.
        /// </summary>
        /// <param name="clinica">A clínica a ser cadastrada.</param>
        void Cadastrar(Clinica clinica);

        /// <summary>
        /// Deleta uma clínica pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da clínica a ser deletada.</param>
        void Deletar(Guid Id);

        /// <summary>
        /// Lista todas as clínicas cadastradas.
        /// </summary>
        /// <returns>Uma lista de clínicas.</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Busca uma clínica pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da clínica a ser buscada.</param>
        /// <returns>A clínica encontrada ou null se não encontrada.</returns>
        Clinica BuscarPorId(Guid Id);

        /// <summary>
        /// Atualiza os dados de uma clínica.
        /// </summary>
        /// <param name="clinica">A clínica com os dados atualizados.</param>
        /// <param name="Id">O Id da clínica a ser atualizada.</param>
        void Atualizar(Clinica clinica, Guid Id);
    }
}
