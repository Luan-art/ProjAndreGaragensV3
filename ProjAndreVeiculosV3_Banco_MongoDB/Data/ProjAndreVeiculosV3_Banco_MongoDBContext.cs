using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Banco_MongoDB.Data
{
    public class ProjAndreVeiculosV3_Banco_MongoDBContext : DbContext
    {
        public ProjAndreVeiculosV3_Banco_MongoDBContext (DbContextOptions<ProjAndreVeiculosV3_Banco_MongoDBContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Banco> Banco { get; set; } = default!;
    }
}
