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

            if (buscarNoBanco != null)
            {
                return RedirectToAction(nameof(Index));
            }
            _banco.Pessoas.Add(apelido);
            _banco.SaveChanges();
            return View(Index);
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(Pessoa apelidoAntigo, Pessoa apelidoNovo)
        {

            if (ModelState.IsValid)
            {
                var buscarNoBanco = _banco.Pessoas.FirstOrDefault(x => x.Nome == apelidoAntigo.Nome);
                buscarNoBanco.Nome = apelidoNovo.Nome;


                _banco.Pessoas.Update(buscarNoBanco);
                _banco.SaveChanges();

                return RedirectToAction(nameof(Index));

            }

            return View(Index);
        }
    }
}