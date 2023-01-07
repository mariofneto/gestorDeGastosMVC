using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gestorDeGastosMVC.Context;

namespace gestorDeGastosMVC.Controllers
{
    [Route("[controller]")]
    public class Gasto : Controller
    {
        private readonly GastosContext _banco;

        public Gasto(GastosContext banco)
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
        public IActionResult Criar(Gasto gasto)
        {
            _banco.Add(gasto);
            return View();
        }
    }
}