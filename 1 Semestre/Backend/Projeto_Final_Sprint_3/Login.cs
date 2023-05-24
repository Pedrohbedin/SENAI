using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final_Sprint_3
{
    public class Login
    {
        // Declaração dos metodos
        public static void LoginUsuario() {
            string input;
            bool logado = false; 
            Usuario usuario = new Usuario();

            do {
                    Console.Clear();
                    Console.WriteLine(@$"
                    [1] Cadastrar usuario
                    [2] Logue com o seu usuario
                    [3] Delete um usuário
                    [4] Listar Usuarios
                    [5] Sair do programa
                    ");
                    input = Console.ReadLine()!;
                    
                    switch(input) {
                        case"1":
                        Console.Clear();
                        usuario.Cadastrar();
                        break;

                        case"2":
                        logado = usuario.Login();

                        if (logado == true) {
                            Menu();
                        }
                        break;

                        case"3":
                        Console.Clear();
                        Console.WriteLine($"Insira o código do usuario a ser removido");
                        int codigoMarca = int.Parse(Console.ReadLine()!);
                        usuario.Deletar(codigoMarca);
                        break;
                        
                        case"4":
                        usuario.Listar();
                        Console.ReadLine();
                        break;
                    }
                } while(input != "5");
                
            Console.Clear();
        } 

        public static void Menu() {
            bool logado = true;
            string? input;
            
            Marca marca = new Marca();
            Produto produto = new Produto();

            

        do {
            Console.Clear();
            Console.WriteLine(@$"
        [1] Cadastrar marca
        [2] Listar marcas
        [3] Remover marca

        [4] Cadastrar produto
        [5] Listar produtos
        [6] Remover produto

        [7] Deslogar
        ");
        input = Console.ReadLine();

        switch (input) {

            case"1":
                marca.Cadastrar();
            break;

            case "2":
             Console.Clear();        
                marca.Listar();
                Console.WriteLine($"Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            break;
            case "3":
            Console.Clear();
            Console.WriteLine($"Insira o código da marca a ser removida");
            int codigoMarca = int.Parse(Console.ReadLine()!);
            marca.Deletar(codigoMarca);
            break;
            case "4":
            Console.Clear();
            produto.Cadastrar();
            break;
            case "5":
            Console.Clear();
            produto.Listar();
            Console.WriteLine($"Pressione qualquer tecla para continuar...");
            Console.ReadLine();
            break;
            case "6":
            Console.Clear();
            Console.WriteLine($"Insira o código da marca a ser removida");
            int codigoProduto = int.Parse(Console.ReadLine()!);
            produto.Deletar(codigoProduto);
            break;
            case "7":
            logado = false;
            break;

        }

        }while(logado == true);

        }
    }
}