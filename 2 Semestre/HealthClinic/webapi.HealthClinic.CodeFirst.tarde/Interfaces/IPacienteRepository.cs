using System;
using System.Collections.Generic;
using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    /// <summary>
    /// Define as operações disponíveis para o repositório de pacientes.
    /// </summary>
    public interface IPacienteRepository
    {
        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        /// <param name="paciente">O paciente a ser cadastrado.</param>
        void Cadastrar(Paciente paciente);

        /// <summary>
        /// Deleta um paciente pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id do paciente a ser deletado.</param>
        void Deletar(Guid Id);

        /// <summary>
        /// Lista todos os pacientes cadastrados.
        /// </summary>
        /// <returns>Uma lista de pacientes.</returns>
        List<Paciente> Listar();

        /// <summary>
        /// Busca um paciente pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id do paciente a ser buscado.</param>
        /// <returns>O paciente encontrado ou null se não encontrado.</returns>
        Paciente BuscarPorId(Guid Id);

        /// <summary>
        /// Atualiza os dados de um paciente.
        /// </summary>
        /// <param name="paciente">O paciente com os dados atualizados.</param>
        /// <param name="Id">O Id do paciente a ser atualizado.</param>
        void Atualizar(Paciente paciente, Guid Id);
    }
}
