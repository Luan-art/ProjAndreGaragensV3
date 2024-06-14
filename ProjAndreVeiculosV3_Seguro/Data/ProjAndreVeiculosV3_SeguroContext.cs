using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Seguro.Data
{
    public class ProjAndreVeiculosV3_SeguroContext : DbContext
    {
        public ProjAndreVeiculosV3_SeguroContext (DbContextOptions<ProjAndreVeiculosV3_SeguroContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Seguro> Seguro { get; set; } = default!;
        public DbSet<Models.Carro> Carro { get; set; } = default!;
        public DbSet<Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<Models.Condutor> Condutor { get; set; } = default!;


    }
}
