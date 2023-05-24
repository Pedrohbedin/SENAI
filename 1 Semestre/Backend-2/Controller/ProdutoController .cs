using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_2.Model;
using Backend_2.View;

namespace Backend_2.Controller
{
    public class ProdutoController 
    {
        Produto produto = new Produto();
        ProdutoView produtoView = new ProdutoView();

        public void ListarProdutos() {
            List<Produto> produtos = produto.Ler();
            produtoView.Listar(produtos);
        }
    }
}