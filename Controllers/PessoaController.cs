using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestorDeGastosMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using gestorDeGastosMVC.Models;

namespace gestorDeGastosMVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly GastosContext _banco;

        public PessoaController(GastosContext banco)
        {
            _banco = banco;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Pessoa apelido)
        {
            var buscarNoBanco = _banco.Pessoas.FirstOrDefault(x => x.Nome == apelido.Nome);

            if(buscarNoBanco != null)
            {
                Console.WriteLine("Já existe esse apelido!");
                return RedirectToAction(nameof(Index));
            }
            _banco.Pessoas.Add(apelido);
            _banco.SaveChanges();
            return View();
        }
    }
}