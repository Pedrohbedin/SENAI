using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Cartao_Interface
{
    public abstract class Contato
    {
        public string? Nome {get; set; }
        public string? Telefone {get; set; }
        public string? Email {get; set; }
        public string? RegistroPessoa {get; set; }
        public string ? RegistroDaPessoa {get; set; }
    }
}