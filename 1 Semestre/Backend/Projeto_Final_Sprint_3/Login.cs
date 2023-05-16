using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final_Sprint_3
{
    public class Login
    {

        List<Produto> produtos = new List<Produto>();
        
        public void Adicinar(Produto _produto) {
            produtos.Add(_produto);
        }

        // Declaração dos metodos
        public static void LoginUsuario() {

            string? emailInserido;
            string? senhaInserida;
            string email = "teste";
            string senha = "teste";
            do 
            {
                Console.WriteLine($"Insira seu email:");
                emailInserido = Console.ReadLine();

                Console.WriteLine($"Insira sua senha:");
                senhaInserida = Console.ReadLine();
                
                if (emailInserido != email || senhaInserida != senha) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEmail ou senha incorretos\n");
                    Console.ResetColor();
                    
                }
            } while(senhaInserida != senha || emailInserido != email );
            Console.Clear();

            Menu();
        } 

        public static void Menu() {
            List<Marca> Marcas = new List<Marca>();
            string? input;
            Produto produto;

            do {
                Console.WriteLine(@$"
        [1] Cadastrar marca
        [2] Listar marcas
        [3] Cadastrar produto
        [4] Listar produtos
        ");
        input = Console.ReadLine();

        switch (input) {
            case "3":
            Marca marca = new Marca(1, "nome", DateTime.Now);
            Marca marca1 = new Marca(2, "nome2", DateTime.Now);

            Marcas.Add(marca);
            Console.WriteLine(marca);
            Console.WriteLine(marca1);
            
            break;
        }
            }while(input != "4");
        }
    }
}