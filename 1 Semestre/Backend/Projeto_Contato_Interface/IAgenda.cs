using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Cartao_Interface
{
    public interface IAgenda
    {
        void Adicionar(Contato _contato);

        void Listar();

        void validar();
    }
}