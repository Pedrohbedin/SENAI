using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Gamer.infra;
using Projeto_Gamer.Models;

namespace Projeto_Gamer.Controllers
{
    [Route("[controller]")]
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        Context c = new Context();

        [Route("Listar")]
        public IActionResult Index() {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            ViewBag.Jogador = c.Jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();

            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form) {

            Jogador novoJogador = new Jogador();

            novoJogador.Nome = form["Nome"].ToString();
            novoJogador.Email = form["Email"].ToString();
            novoJogador.Senha = form["Senha"].ToString();
            novoJogador.IdEquipe = int.Parse(form["Equipe"]!);
            

            c.Add(novoJogador);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form) {
                
            Jogador novoJogador = new Jogador();
            
            novoJogador.IdJogador = int.Parse(form["IdJogador"]!);
            novoJogador.Nome = form["Nome"].ToString();
            novoJogador.Email = form["Email"].ToString();
            novoJogador.Senha = form["Senha"].ToString();
            novoJogador.IdEquipe = int.Parse(form["IdEquipe"]!);
            
            Jogador jogadorbuscado = c.Jogador.First(j => j.IdJogador == novoJogador.IdJogador);

            jogadorbuscado.IdEquipe = novoJogador.IdEquipe;
            jogadorbuscado.Nome = novoJogador.Nome;
            jogadorbuscado.Email = novoJogador.Email;
            jogadorbuscado.Senha = novoJogador.Senha;
            

            c.Jogador.Update(jogadorbuscado);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir{id}")]

        public IActionResult Excluir(int id){
            Jogador e = c.Jogador.First(e => e.IdJogador == id);

            c.Jogador.Remove(e);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Editar{id}")]

        public IActionResult Editar(int id) {
            Jogador e = c.Jogador.First(e => e.IdJogador == id);
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            ViewBag.Jogador = e;

            ViewBag.Equipe = c.Equipe.ToList();

            return View("Editar");
        }
    }
}