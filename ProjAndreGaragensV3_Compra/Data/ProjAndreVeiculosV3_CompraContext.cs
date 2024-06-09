using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Compra.Data
{
    public class ProjAndreVeiculosV3_CompraContext : DbContext
    {
        public ProjAndreVeiculosV3_CompraContext (DbContextOptions<ProjAndreVeiculosV3_CompraContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Compra> Compra { get; set; } = default!;

        public DbSet<Models.Carro> Carro { get; set; } = default!;

    }
}
