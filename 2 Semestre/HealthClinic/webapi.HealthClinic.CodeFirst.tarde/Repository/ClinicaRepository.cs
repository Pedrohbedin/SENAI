using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    /// <summary>
    /// Implementação do repositório de clínicas.
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// O contexto do banco de dados.
        /// </summary>
        private readonly HealthClinicContext ctx;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ClinicaRepository"/>.
        /// </summary>
        public ClinicaRepository() => ctx = new HealthClinicContext();

        /// <inheritdoc/>
        public void Atualizar(Clinica clinica, Guid Id)
        {
            Clinica clinicaExistente = BuscarPorId(Id);
            ctx.Entry(clinicaExistente).CurrentValues.SetValues(clinica);
            ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public Clinica BuscarPorId(Guid Id) => ctx.Clinica.FirstOrDefault(x => x.IdClinica == Id)!;

        /// <inheritdoc/>
        public void Cadastrar(Clinica clinica)
        {
            try
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public void Deletar(Guid Id)
        {
            try
            {
                ctx.Clinica.Remove(ctx.Clinica.FirstOrDefault(x => x.IdClinica == Id)!);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public List<Clinica> Listar() => ctx.Clinica.ToList();
    }
}
