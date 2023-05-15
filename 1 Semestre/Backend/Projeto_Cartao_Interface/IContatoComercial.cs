using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Cartao_Interface
{
    public interface IContatoComercial
    {
        bool ValidarCNPJ(string _cpnj);
    }
}