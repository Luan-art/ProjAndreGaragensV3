using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Banco.Data
{
    public class ProjAndreVeiculosV3_BancoContext : DbContext
    {
        public ProjAndreVeiculosV3_BancoContext (DbContextOptions<ProjAndreVeiculosV3_BancoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Banco> Banco { get; set; } = default!;
    }
}
