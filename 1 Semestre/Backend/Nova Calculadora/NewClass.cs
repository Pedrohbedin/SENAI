using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nova_Calculadora
{
    public class NewClass
    {
        public float n1;
        public float n2;
        
        public string somar() {
            
            return $"\nO resultado da soma é: {this.n1 + this.n2}";
        }
        public string subtrair() {
            
            return $"\nO resultado da subtração é: {this.n1 - this.n2}";
        }
        public string dividir() {
            
            return $"\nO resultado da divisão é: {this.n1 / this.n2}";
        }
            public string multiplicar() {
            
            return $"\nO resultado da multiplicação é: {this.n1 * this.n2}";
        }
    }
}