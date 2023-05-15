using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Cartao_Interface
{
    public class Agenda : IAgenda
    {
        List<Contato> contatos = new List<Contato>();

        public Agenda()
        {
            
        }

        public void Adicionar(Contato _contato)
        {
            contatos.Add(_contato);
        }

        public void Listar()
        {
            if(contatos.Count > 0) {
                foreach(Contato p in contatos) {
                    Console.WriteLine(@$"
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

            Nome: {p.Nome}
            Telefone: {p.Telefone}
            Email: {p.Email}
            {p.RegistroPessoa}: {p.RegistroDaPessoa}

-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=                
                    ");
                    
                }
            }

            else {
                Console.WriteLine($"Nenhum item inserido...");
                
            }
        }

        public void validar()
        {
            throw new NotImplementedException();
        }
    }
}