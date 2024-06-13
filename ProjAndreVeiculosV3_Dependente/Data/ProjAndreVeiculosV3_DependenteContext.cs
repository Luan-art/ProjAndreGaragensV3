using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Dependente.Data
{
    public class ProjAndreVeiculosV3_DependenteContext : DbContext
    {
        public ProjAndreVeiculosV3_DependenteContext (DbContextOptions<ProjAndreVeiculosV3_DependenteContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Dependente> Dependente { get; set; } = default!;

        public DbSet<Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<Models.Endereco> Endereco { get; set; } = default!;

    }
}
