using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Banco_SQLServer.Data
{
    public class ProjAndreVeiculosV3_Banco_SQLServerContext : DbContext
    {
        public ProjAndreVeiculosV3_Banco_SQLServerContext (DbContextOptions<ProjAndreVeiculosV3_Banco_SQLServerContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Banco> Banco { get; set; } = default!;
    }
}
