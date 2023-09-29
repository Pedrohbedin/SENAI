using System;
using System.Collections.Generic;
using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    /// <summary>
    /// Define as operações disponíveis para o repositório de consultas.
    /// </summary>
    public interface IConsultaRepository
    {
        /// <summary>
        /// Agenda uma nova consulta.
        /// </summary>
        /// <param name="consulta">A consulta a ser agendada.</param>
        void Agendar(Consultas consulta);

        /// <summary>
        /// Cancela uma consulta pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da consulta a ser cancelada.</param>
        void Cancelar(Guid Id);

        /// <summary>
        /// Busca uma consulta pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da consulta a ser buscada.</param>
        /// <returns>A consulta encontrada ou null se não encontrada.</returns>
        Consultas BuscarPorId(Guid Id);

        /// <summary>
        /// Inclui uma descrição em uma consulta.
        /// </summary>
        /// <param name="descricao">A descrição a ser incluída.</param>
        /// <param name="Id">O Id da consulta à qual a descrição será incluída.</param>
        void IncluirDescricao(string descricao, Guid Id);

        /// <summary>
        /// Lista todas as consultas de um usuário pelo seu Id.
        /// </summary>
        /// <param name="idUsuario">O Id do usuário cujas consultas serão listadas.</param>
        /// <returns>Uma lista de consultas do usuário.</returns>
        List<Consultas> ListarPorUsuario(Guid idUsuario);

        /// <summary>
        /// Lista todas as consultas cadastradas.
        /// </summary>
        /// <returns>Uma lista de consultas.</returns>
        List<Consultas> Listar();

        /// <summary>
        /// Atualiza os dados de uma consulta.
        /// </summary>
        /// <param name="consulta">A consulta com os dados atualizados.</param>
        /// <param name="Id">O Id da consulta a ser atualizada.</param>
        void Atualizar(Consultas consulta, Guid Id);
    }
}
