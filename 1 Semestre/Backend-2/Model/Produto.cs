using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_2.Model
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public float Preco { get; set; }

        //Caminho da pasta e do arquivo csv

        private const string PATH = "Database/Produto.csv";

        public Produto() {
            // Lógica para criar a pasta e o arquivo
            
            // Criar caminho pasta
            string pasta = PATH.Split("/")[0];
            // Verificar se no caminho já existe uma pasta
            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }
            // Verificar se no caminho já existe um arquivo
            if(!File.Exists(PATH)){
                File.Create(PATH);
            }
        }
        public List<Produto> Ler() {
        List<Produto> produtos = new List<Produto>();
        
        string[] linhas = File.ReadAllLines(PATH);

        foreach(string item in linhas) {
            string[] atribubutos  = item.Split(';');

            Produto p = new Produto();

            p.Codigo = int.Parse(atribubutos[0]);
            p.Nome = atribubutos[1];
            p.Preco = float.Parse(atribubutos[2]);

            produtos.Add(p);
        }
        return produtos;
    }
        public string PrepararLinhasCSV(Produto p) {
            return$"{p.Codigo};{p.Nome};{p.Preco}";
        }

        public void Inserir(Produto p) {
            string[] linhas = {PrepararLinhasCSV(p)};

            File.AppendAllLines(PATH, linhas);
        }
    }
}