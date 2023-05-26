using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto02.Model;

namespace Projeto02.View
{
    public class EventoView
    {
        public void Listar(List<Evento> e) {
            foreach(Evento item in e) {
                Console.WriteLine(@$"--------------------------
{item.Nome}
{item.Descricao}
{item.Data}");
            }
            Console.WriteLine($"--------------------------");
            
        }
    }
}