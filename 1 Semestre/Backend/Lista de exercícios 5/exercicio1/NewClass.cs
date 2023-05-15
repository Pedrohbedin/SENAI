using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercicio1
{
    public class NewClass
    {
            public int andarAtual {get; set;}
            public int totalAndares {get; set;}
            public int capacidade {get; set;}
            public int totalPessoas {get; set;}
            public void Inicializa() {
                Console.WriteLine($"A capacidade do elevador é: {capacidade}");
                Console.WriteLine($"O total de andares do prédio é: {totalAndares}");
            }
            public void Entrar() {
                if(totalPessoas < capacidade) {
                    totalPessoas++;
                    Console.WriteLine($"Você entrou no elevador");
                }
            }
            public void Sair() {
                totalPessoas--;
                Console.WriteLine($"Você saiu do elevador no andar {andarAtual}");
            }
            public void Subir() {
                if(andarAtual < totalAndares ) {
                    andarAtual++;
                    Console.WriteLine($"\nVocê subiu\n");
                }
                else {
                    Console.WriteLine($"Você está no ultimo andar");
                    Environment.Exit(0);
                }
            }
        public void Descer() {
            if(andarAtual == 0) {
                Console.WriteLine($"Você está no térreo");
            }
            else {
                andarAtual--;
            }
        }
    }
}