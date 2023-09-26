﻿using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    public interface ISituacaoRepository
    {
        void Cadastrar(Situacao situacao);
        void Deletar(Guid Id);
    }
}
