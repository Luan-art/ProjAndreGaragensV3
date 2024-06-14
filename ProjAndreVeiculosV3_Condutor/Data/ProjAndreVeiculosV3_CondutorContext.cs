using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Condutor.Data
{
    public class ProjAndreVeiculosV3_CondutorContext : DbContext
    {
        public ProjAndreVeiculosV3_CondutorContext (DbContextOptions<ProjAndreVeiculosV3_CondutorContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Condutor> Condutor { get; set; } = default!;
        public DbSet<Models.Categoria> Categoria { get; set; } = default!;
        public DbSet<Models.CNH> CNH { get; set; } = default!;
        public DbSet<Models.Endereco> Endereco { get; set; } = default!;

    }
}
