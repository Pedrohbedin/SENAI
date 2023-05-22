using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final_Sprint_3
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? SenhaInserida {get; set; }
        public string? EmailInserido {get; set; }
        public List<Usuario> listaUsuarios = new List<Usuario>();

        public int CodigoDeletar { get; set; }

        public void Cadastrar()
        {

            Usuario usuario = new Usuario();

            Console.WriteLine($"Cadastre seu código");
            usuario.Codigo = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Cadastre seu nome:");
            usuario.Nome = Console.ReadLine()!;

            Console.WriteLine($"Cadastre seu email:");
            usuario.Email= Console.ReadLine()!;

            Console.WriteLine($"Cadastre sua senha:");
            usuario.Senha = Console.ReadLine()!;

            usuario.DataCadastro = DateTime.Now;

            listaUsuarios.Add(usuario);
        }

        public void Listar() {
            if(listaUsuarios.Count > 0) {
                foreach(Usuario usuario in listaUsuarios) {
                    Console.WriteLine(@$"
-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        Nome: {usuario.Nome}
        Codigo: {usuario.Codigo}
        Email: {usuario.Email}");
}
                Console.WriteLine($"\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
                
            };
        }

        public bool Login() {
            Console.WriteLine($"Insira seu email:");
            EmailInserido = Console.ReadLine();
            
            Console.WriteLine($"Insira sua senha:");
            SenhaInserida = Console.ReadLine();

            if (listaUsuarios.Count > 0) { 
                foreach(Usuario usuario in listaUsuarios) {
                    if (SenhaInserida == usuario.Senha && EmailInserido == usuario.Email) {
                        return true;
                    }
                    else {
                    return false;
                    }
                }
                return true;
            }
            else {
                return false;
            }
 
        }

        public void Deletar(int codigo)
        {
            listaUsuarios.Remove(listaUsuarios.Find(x => x.Codigo == codigo)!); 
        }  
    }
}