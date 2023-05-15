using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Cartao_Interface
{
    public class ContatoComercial : Contato, IContatoComercial
    {
        string? CNPJ {get; set; }
        public ContatoComercial(string nome, string telefone, string email, string cnpj) {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            if (ValidarCNPJ(cnpj) == true) {
                RegistroPessoa = "CNPJ";
                RegistroDaPessoa = cnpj;
            }
        }

        public bool ValidarCNPJ(string _cpnj)
        {
            if(_cpnj.Length == 14) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}