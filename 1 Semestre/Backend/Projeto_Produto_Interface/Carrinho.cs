using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Projeto_Produto_Interface
{
    public class Carrinho : ICarrinho
    {
        public float Valor {get; set; }
        List<Produto> carrinho = new List<Produto>();

        public void Adicionar(Produto _produto)
        {
            carrinho.Add(_produto); 
        }

        public void Atualizar(int _codigo, Produto _produto)
        {
            carrinho.Find(x => x.Codigo == _codigo)!.Nome = _produto.Nome;
        }

        public void Listar()
        {
            if(carrinho.Count > 0) {
                foreach(Produto p in carrinho) {
                    Console.WriteLine(@$"
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

            Código: {p.Codigo}
            Nome: {p.Nome}
            Preço: {p.Preco.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}

-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=                
                    ");
                    
                }
            }

            else {
                Console.WriteLine($"Nenhum item inserido...");
                
            }
        }

        public void Remover(int _codigo)
        {
            carrinho.Remove(carrinho.Find(x => x.Codigo == _codigo)!);
        }

        public void TotalCarrinho() {
            Valor = 0;
            if(carrinho.Count > 0) {
                foreach(Produto p in carrinho) {
                    if(p.Preco > 0) {
                        Valor += p.Preco;
                    }
                }

                Console.WriteLine($"\nO total do seu carrinho é {Valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");
                
            }
        }
    }
}