using System;
using System.Collections.Generic;
using System.Linq;

namespace AdicionarProduto
{
    public class Produto
    {
        public string? Nome { get; set; }
        public int Quantidade { get; set; }
    }

    public static class GerenciadorDeProdutos
    {
        private static List<Produto> listaDeProdutos = new List<Produto>();

        public static string AdicionarProduto(Produto produto)
        {
            Produto produtoA = new Produto();
            produtoA.Nome = "Produto1";

            listaDeProdutos.Add(produtoA);
            var produtoExistente = listaDeProdutos.FirstOrDefault(p => p.Nome == produto.Nome);

            if (produtoExistente != null)
            {
                produtoExistente.Quantidade += produto.Quantidade;
                return "A quantidade do produto foi incrementada";
            }
            else
            {
                
                listaDeProdutos.Add(produto);
    
                return "Produto cadastrado com sucesso";
            }
        }
    }
}
