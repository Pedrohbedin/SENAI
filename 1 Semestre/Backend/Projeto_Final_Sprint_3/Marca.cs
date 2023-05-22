using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final_Sprint_3
{
    

    public class Marca
    {
        public int Codigo { get; set; }
        public string? NomeMarca { get; set; }
        public DateTime DataCadastro { get; set; }

        public static List<Marca> listaDeMarcas = new List<Marca>();

        public void Cadastrar()
        {
            Marca marca = new Marca();
    
            Console.WriteLine($"Insira o código da sua marca:");
            marca.Codigo = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Insira o nome da sua marca:");
            marca.NomeMarca = Console.ReadLine()!;
            
            marca.DataCadastro = DateTime.Now;

            listaDeMarcas.Add(marca);
        }

        public void Listar()
        {
            if(listaDeMarcas.Count > 0) {
                foreach(Marca c in listaDeMarcas) {
                    Console.WriteLine(@$"
-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        Codigo: {c.Codigo}
        Nome: {c.NomeMarca}
        Data: {c.DataCadastro}");

                }
                
Console.WriteLine($"\n-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
                
            }
            else
            {
                Console.WriteLine($"Nenhum valor inserido");
            }
        }

        public void Deletar(int _codigo)
        {
            listaDeMarcas.Remove(listaDeMarcas.Find(x => x.Codigo == _codigo)!);
        }
    }
}