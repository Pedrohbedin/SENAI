using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_2.Model;

namespace Backend_2.View
{
    public class ProdutoView 
    {
        //método para exibir os dados da lista no console

        public void Listar(List<Produto> produto) {
            foreach (Produto item in produto) {
                Console.WriteLine(@$"
                Código: {item.Codigo}
                Nome: {item.Nome}
                Preco: {item.Preco:C2}");
            }
            Console.WriteLine($"");
            
        }
    }
}