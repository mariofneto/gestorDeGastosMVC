using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer;

namespace gestorDeGastosMVC.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string PessoaNome { get; set; }
        public string NomeGasto { get; set; }
        public decimal PrecoGasto { get; set; }
    }
}