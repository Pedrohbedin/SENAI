using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercicio2
{
    public class NewClass
    {
        public int acucarDisponivel = 100;
        public bool acucar = false;

        public int acucarPedido;

        public void fazerCafe() {
            if (acucar == false) {
                Console.WriteLine($"O seu café sem açucar está pronto");
            }
            else {
                if(acucarDisponivel > acucarPedido) {
                    do{
                        Console.WriteLine($"Insira a quantidade de acucar desejada:");
                        acucarPedido = int.Parse(Console.ReadLine()!);
                    }while(acucarDisponivel < acucarPedido);
                    
                    Console.WriteLine($"Seu café com açucar está pronto");
                    acucarDisponivel = acucarDisponivel - acucarPedido;
                }
                
            }
        }
        
    }
}