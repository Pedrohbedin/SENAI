using System;
using System.Collections.Generic;
using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    /// <summary>
    /// Define as operações disponíveis para o repositório de situações.
    /// </summary>
    public interface ISituacaoRepository
    {
        /// <summary>
        /// Cadastra uma nova situação.
        /// </summary>
        /// <param name="situacao">A situação a ser cadastrada.</param>
        void Cadastrar(Situacao situacao);

        /// <summary>
        /// Deleta uma situação pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da situação a ser deletada.</param>
        void Deletar(Guid Id);

        /// <summary>
        /// Lista todas as situações cadastradas.
        /// </summary>
        /// <returns>Uma lista de situações.</returns>
        List<Situacao> Listar();

        /// <summary>
        /// Busca uma situação pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da situação a ser buscada.</param>
        /// <returns>A situação encontrada ou null se não encontrada.</returns>
        Situacao BuscarPorId(Guid Id);

        /// <summary>
        /// Atualiza os dados de uma situação.
        /// </summary>
        /// <param name="situacao">A situação com os dados atualizados.</param>
        /// <param name="Id">O Id da situação a ser atualizada.</param>
        void Atualizar(Situacao situacao, Guid Id);
    }
}
