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
    }
}