﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext ctx;

        public ClinicaRepository()
        {
            ctx = new HealthClinicContext();
        }

        public void Atualizar(Clinica clinica, Guid Id)
        {

            BuscarPorId(Id).Nome = clinica.Nome;
            BuscarPorId(Id).HoraAbertura = clinica.HoraAbertura;
            BuscarPorId(Id).HoraFechamento = clinica.HoraFechamento;
            BuscarPorId(Id).CNPJ = clinica.CNPJ;
            BuscarPorId(Id).Endereco = clinica.Endereco;
            BuscarPorId(Id).RazaoSocial = clinica.RazaoSocial;
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(Guid Id)
        {
            return ctx.Clinica.FirstOrDefault(x => x.IdClinica == Id);
        }

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

        public void Deletar(Guid Id)
        {
            try
            {
                ctx.Clinica.Remove(ctx.Clinica.FirstOrDefault(x => x.IdClinica == Id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinica.ToList();
        }
    }
}
