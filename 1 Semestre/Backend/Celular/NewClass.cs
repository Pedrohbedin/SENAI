using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Celular
{
    public class NewClass
    {
        public string cor = "Branco";
        public string modelo = "Iphone";
        public string tamanho = "15x30";
        public bool ligado = true;
        public string escolha = "";
        public string opcao = "";

        public string mensagens = "";
        public string opcao1 = "";
        public void Menu() {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(@$"
                Escolha um opção:
                    
                [1] Desligar
                [2] Fazer ligação
                [3] Enviar mensagem

                ");
                Console.ResetColor();
                escolha = Console.ReadLine();
            }
        public void ligar() {
            do {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(@$"
                Escolha um contato:

                [1] Polícia 
                [2] Senai
                [3] Voltar

                ");
                Console.ResetColor();
                opcao = Console.ReadLine();
                
            } while(opcao != "1" && opcao != "2" && opcao != "3" || opcao == "");
        }

        public void mensagem() {
            do {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(@$"
                Escolha um contato:

                [1] Polícia 
                [2] Senai
                [3] Voltar

                ");
                Console.ResetColor();
                opcao1 = Console.ReadLine();
                
            } while(opcao1 != "1" && opcao1 != "2" && opcao1 != "3" || opcao1 == "");

            do {
                Console.WriteLine($"Escreva a mensagem:");
                mensagens = Console.ReadLine();
            } while (mensagens == "");

            Console.WriteLine($"Enviando: {mensagens}, para {opcao1}º opção");
            Thread.Sleep(5000);

            escolha = "";
                
        }
    }
}