using System;
using System.Collections.Generic;
using System.Linq;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Controllers;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    /// <summary>
    /// Implementação do repositório de médicos.
    /// </summary>
    public class MedicoRepository : IMedicoRepository
    {
        /// <summary>
        /// O contexto do banco de dados.
        /// </summary>
        private readonly HealthClinicContext ctx;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="MedicoRepository"/>.
        /// </summary>
        public MedicoRepository()
        {
            ctx = new HealthClinicContext();
        }

        /// <inheritdoc/>
        public void Atualizar(Medico medico, Guid Id)
        {
            Medico medicoExistente = BuscarPorId(Id);
            if (medicoExistente != null)
            {
                medicoExistente.Clinica = medico.Clinica;
                medicoExistente.IdClinica = medico.IdClinica;
                medicoExistente.IdEspecialidade = medico.IdEspecialidade;
                medicoExistente.Especialidade = medico.Especialidade;
                medicoExistente.CRM = medico.CRM;
                medicoExistente.IdUsuario = medico.IdUsuario;
                medicoExistente.Nome = medico.Nome;
                medicoExistente.Usuario = medico.Usuario;

                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public Medico BuscarPorId(Guid Id) => ctx.Medico.FirstOrDefault(x => x.IdUsuario == Id)!;

        /// <inheritdoc/>
        public void Cadastrar(Medico medico)
        {
            try
            {
                ctx.Medico.Add(medico);
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
            Medico medico = ctx.Medico.FirstOrDefault(x => x.IdMedico == Id)!;
            if (medico != null)
            {
                ctx.Medico.Remove(medico);
                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public List<Medico> Listar()
        {
            List<Medico> medicos = ctx.Medico.ToList();
            foreach (Medico medico in medicos)
            {
                medico.Usuario = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == medico.IdUsuario);
                medico.Especialidade = ctx.Especialidade.FirstOrDefault(x => x.IdEspecialidade == medico.IdEspecialidade);
                medico.Clinica = ctx.Clinica.FirstOrDefault(x => x.IdClinica == medico.IdClinica);
                medico.Usuario.TipoUsuario = ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == medico.Usuario.IdTipoUsuario);
            }

            return ctx.Medico.ToList();
        }
    }
}
