using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Financiamento.Data
{
    public class ProjAndreVeiculosV3_FinanciamentoContext : DbContext
    {
        public ProjAndreVeiculosV3_FinanciamentoContext (DbContextOptions<ProjAndreVeiculosV3_FinanciamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Financiamento> Financiamento { get; set; } = default!;
        public DbSet<Models.Venda> Venda { get; set; } = default!;
        public DbSet<Models.Banco> Banco { get; set; } = default!;

    }
}
