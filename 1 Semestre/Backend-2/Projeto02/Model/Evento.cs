using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto02.Model
{
    public class Evento
    {
        public string? Nome {get; set;}
        public string? Descricao {get; set;}
        public DateTime Data {get; set;}

        public const string PATH = "Database/Evento.csv";

        public Evento() {
            
            string pasta = PATH.Split("/")[0];

            if(!Directory.Exists(pasta)) {
                Directory.CreateDirectory(pasta);
            }
            if(!File.Exists(PATH)) {
                File.Create(PATH);
            }

        }

        public List<Evento> Ler() {
            List<Evento> eventos = new List<Evento>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach(string item in linhas) {
                string[] atributos = item.Split(';');

                Evento e = new Evento();

                e.Nome = atributos[0];
                e.Descricao = atributos[1];
                e.Data = DateTime.Parse(atributos[2]); 
                
                eventos.Add(e);
            }

            return eventos;
        }

        public string PrepararLinhasCSV(Evento e) {
            return $"{e.Nome};{e.Descricao};{e.Data}";
        }

        public void Inserir(Evento e) {
            string[] linhas = {PrepararLinhasCSV(e)};

            File.AppendAllLines(PATH, linhas);
        }

        public Evento Cadastrar() {

            Evento novoEvento = new Evento();

            Console.WriteLine($"Insira o nome do evento:");
            novoEvento.Nome = Console.ReadLine()!;

            Console.WriteLine($"Insira a descrição do evento:");
            novoEvento.Descricao = Console.ReadLine()!;

            Console.WriteLine($"Insira o data do evento:");
            novoEvento.Data = DateTime.Parse(Console.ReadLine()!);

            return novoEvento;
        }
    }
}