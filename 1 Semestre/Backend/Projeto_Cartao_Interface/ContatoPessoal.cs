using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Cartao_Interface
{
    public class ContatoPessoal : Contato, IContatoPessoal
    {
        string? CPF {get; set; }

        public ContatoPessoal(string nome, string telefone, string email, string cpf) {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            if(ValidarCPF(cpf) == true) {
                RegistroPessoa = "CPF";
                RegistroDaPessoa = cpf;
            }
        }

        public bool ValidarCPF(string _cpf)
        {
             if(_cpf.Length == 11) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}