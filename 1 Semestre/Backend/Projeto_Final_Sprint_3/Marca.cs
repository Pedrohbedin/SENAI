using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final_Sprint_3
{
    public class Marca
    {
        int Codigo;
        string? NomeMarca;
        DateTime DataCadastro;

        public Marca(int codigo, string nomeProduto, DateTime dataCadastro) {
            Codigo = codigo;
            NomeMarca = nomeProduto;
            DataCadastro = dataCadastro;
        }
    }
}