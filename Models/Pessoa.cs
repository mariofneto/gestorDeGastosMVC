using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestorDeGastosMVC.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Gasto> Gastos { get; set; }
    }
}