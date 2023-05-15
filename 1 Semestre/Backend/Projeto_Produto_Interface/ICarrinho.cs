using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Produto_Interface
{
    public interface ICarrinho
    {
        void Adicionar(Produto _produton);

        void Listar();

        void Atualizar(int _codigo, Produto _produto);

        void Remover(int _codigo); 
    }
}