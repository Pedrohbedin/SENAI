using System;
using System.Collections.Generic;
using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    /// <summary>
    /// Define as operações disponíveis para o repositório de especialidades.
    /// </summary>
    public interface IEspecialidadeRepository
    {
        /// <summary>
        /// Cadastra uma nova especialidade.
        /// </summary>
        /// <param name="especialidade">A especialidade a ser cadastrada.</param>
        void Cadastrar(Especialidade especialidade);

        /// <summary>
        /// Deleta uma especialidade pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da especialidade a ser deletada.</param>
        void Deletar(Guid Id);

        /// <summary>
        /// Lista todas as especialidades cadastradas.
        /// </summary>
        /// <returns>Uma lista de especialidades.</returns>
        List<Especialidade> Listar();

        /// <summary>
        /// Busca uma especialidade pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da especialidade a ser buscada.</param>
        /// <returns>A especialidade encontrada ou null se não encontrada.</returns>
        Especialidade BuscarPorId(Guid Id);

        /// <summary>
        /// Atualiza os dados de uma especialidade.
        /// </summary>
        /// <param name="especialidade">A especialidade com os dados atualizados.</param>
        /// <param name="Id">O Id da especialidade a ser atualizada.</param>
        void Atualizar(Especialidade especialidade, Guid Id);
    }
}
