using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto02.Model;
using Projeto02.View;

namespace Projeto02.Controller
{
    public class EventoController
    {
        Evento e = new Evento();
        EventoView ev = new EventoView();

        public void ListarProduto() {
            e.Inserir(e.Cadastrar());
            List<Evento> eventos = e.Ler();
            ev.Listar(eventos);
        }
    }
}