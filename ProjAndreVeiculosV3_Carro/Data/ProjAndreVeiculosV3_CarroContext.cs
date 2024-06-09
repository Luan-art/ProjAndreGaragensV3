using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Carro.Data
{
    public class ProjAndreVeiculosV3_CarroContext : DbContext
    {
        public ProjAndreVeiculosV3_CarroContext (DbContextOptions<ProjAndreVeiculosV3_CarroContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Carro> Carro { get; set; } = default!;
    }
}
