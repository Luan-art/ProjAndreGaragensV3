using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Pagamento.Data
{
    public class ProjAndreVeiculosV3_PagamentoContext : DbContext
    {
        public ProjAndreVeiculosV3_PagamentoContext (DbContextOptions<ProjAndreVeiculosV3_PagamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Pagamento> Pagamento { get; set; } = default!;

        public DbSet<Models.TipoPix>? TipoPix { get; set; }

        public DbSet<Models.Pix>? Pix { get; set; }

        public DbSet<Models.Boleto>? Boleto { get; set; }

        public DbSet<Models.Cartao>? Cartao { get; set; }
    }
}
