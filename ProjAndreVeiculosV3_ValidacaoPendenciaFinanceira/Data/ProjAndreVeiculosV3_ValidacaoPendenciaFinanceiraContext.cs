using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_ValidacaoPendenciaFinanceira.Data
{
    public class ProjAndreVeiculosV3_ValidacaoPendenciaFinanceiraContext : DbContext
    {
        public ProjAndreVeiculosV3_ValidacaoPendenciaFinanceiraContext (DbContextOptions<ProjAndreVeiculosV3_ValidacaoPendenciaFinanceiraContext> options)
            : base(options)
        {
        }

        public DbSet<Models.PendenciaFinanceira> PendenciaFinanceira { get; set; } = default!;
        public DbSet<Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<Models.Endereco> Endereco { get; set; } = default!;


    }
}
