using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conversor_de_moedas
{
    public class NewClass
    {

        public static float valorDolar{get; set;}
        public static float valorReal{get; set;}
        public static float ConverterParaReais(float valorDolar) {
            return valorDolar / 4.99f;
        }
        public static float ConverterParaDolar(float valorReal) {
            return valorReal * 4.99f;
        }
    }
}