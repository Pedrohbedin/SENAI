using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final_Sprint_3
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string? NomeProduto { get; set; }
        public float Preco { get; set; }
        public DateTime DataCadastro { get; set; }              
        public int MarcaCodigo; 
        public Usuario CadastroPor = new Usuario();
        
        public Marca Marca = new Marca();
        List<Produto> listaDeProdutos = new List<Produto>();
        
        public void Cadastrar()
        {

            Produto produto = new Produto();
    
            Console.WriteLine($"Insira o código do seu produto:");
            produto.Codigo = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Insira o nome do seu produto:");
            produto.NomeProduto = Console.ReadLine()!;

            Console.WriteLine($"Insira o preço do seu produto:");
            produto.Preco = float.Parse(Console.ReadLine()!);

            produto.DataCadastro = DateTime.Now;

            Console.WriteLine($"Insira o código da marca do seu produto:");
            produto.MarcaCodigo = int.Parse(Console.ReadLine()!);

            listaDeProdutos.Add(produto);

            Marca = Marca.listaDeMarcas.Find(x => x.Codigo == produto.MarcaCodigo)!;
        }

        public void Listar()
        {
            if(listaDeProdutos.Count > 0) {
                foreach(Produto p in listaDeProdutos) {
                    Console.WriteLine(@$"
                    Codigo: {p.Codigo}
                    Nome: {p.NomeProduto}
                    Preco: {CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", p.Preco}
                    Data: {p.DataCadastro}
                    Marca: {Marca.listaDeMarcas.Find(x => x.Codigo == p.MarcaCodigo)!.NomeMarca}
                    ");
                    
                }
            }
            else
            {
                Console.WriteLine($"Nenhum valor inserido");
            }
        }
        
        public void Deletar(int codigo)
        {
            listaDeProdutos.Remove(listaDeProdutos.Find(x => x.Codigo == codigo)!);
        }
    }
}