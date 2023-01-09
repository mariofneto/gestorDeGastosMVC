using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gestorDeGastosMVC.Context;
using gestorDeGastosMVC.Models;

namespace gestorDeGastosMVC.Controllers
{
    public class GastoController : Controller
    {
        private readonly GastosContext _banco;

        public GastoController(GastosContext banco)
        {
            _banco = banco;
        }

        public IActionResult Index()
        {
            var todos = _banco.Gastos.ToList();
            return View(todos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Gasto gastoCompleto)
        {
            if (ModelState.IsValid)
            {
                _banco.Gastos.Add(gastoCompleto);
                _banco.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(gastoCompleto);
        }

        public IActionResult Detalhes(int id)
        {
            if (id == null)
                return NotFound();
            var detalhesGasto = _banco.Gastos.Find(id);
            if (detalhesGasto == null)
                return NotFound();
            return View(detalhesGasto);
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(int id, Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                var buscarNoBanco = _banco.Gastos.Find(id);

                buscarNoBanco.PessoaId = gasto.PessoaId;
                buscarNoBanco.NomeGasto = gasto.NomeGasto;
                buscarNoBanco.PrecoGasto = gasto.PrecoGasto;
                _banco.Gastos.Update(buscarNoBanco);
                _banco.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(Index);
        }
    }
}