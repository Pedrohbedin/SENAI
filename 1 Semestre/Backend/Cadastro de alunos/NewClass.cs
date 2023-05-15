using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_alunos
{
    public class NewClass
    {
        public string nome = "";
        public string curso = "";
        public int idade;
        public string RG = "";
        public bool bolsista;
        public float mf;
        public float mensalidade;

        public float vermediafinal() {
        return this.mf;
    }

    public string bolsistadesconto() {

        string saida;

        if (bolsista == true && mf >= 8) {
        saida = $"\nVocê recebeu 50% de desconto no valor da sua mensalidade fazendo com que o valor dela seja {mensalidade * 0.5}";
    }
    else if (bolsista == true && mf > 6 && mf < 8) {
        saida = $"\nVocê recebeu 30% de desconto no valor da sua mensalidade fazendo com que o valor dela seja {mensalidade * 0.7}";
    }
    else {
       saida =  $"\nO valor correspondente a sua mensalidade é {mensalidade}";
    }
    return saida;
    }
    }

}

