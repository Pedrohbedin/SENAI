using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {
        [Fact]
        public void SomarDoisNumeros()
        {

            var n1 = 3.3;
            var n2 = 2.2;
            var valorEsperado = 5.5;

            var soma = Calculo.Somar(n1, n2);

            Assert.Equal(valorEsperado, soma); 
        }
        [Fact]
        public void SubtraisDoisNumeros()
        {
            var n1 = 6.5;
            var n2 = 3.5;
            var valorEsperado = 3;

            var subtracao = Calculo.Subtrair(n1, n2);

            Assert.Equal(valorEsperado, subtracao);
        }
        [Fact]
        public void MultiplicarDoisNumeros()
        {
            var n1 = 3;
            var n2 = 2;
            var valorEsperado = 6;

            var multiplicacao = Calculo.Multiplicar(n1, n2);

            Assert.Equal(valorEsperado, multiplicacao);
        }
        [Fact]
        public void DividirDoisNumeros() 
        {
            var n1 = 6;
            var n2 = 2;
            var valorEsperado = 3;

            var divisao = Calculo.Dividir(n1, n2);

            Assert.Equal(valorEsperado, divisao);
        }
    }
}
