using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestorDeGastosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace gestorDeGastosMVC.Context
{
    public class GastosContext : DbContext
    {
        public GastosContext(DbContextOptions<GastosContext> options) : base(options)
        {

        }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

    }
}