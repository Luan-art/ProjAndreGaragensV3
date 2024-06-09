using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Servico.Data
{
    public class ProjAndreVeiculosV3_ServicoContext : DbContext
    {
        public ProjAndreVeiculosV3_ServicoContext (DbContextOptions<ProjAndreVeiculosV3_ServicoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Servico> Servico { get; set; } = default!;
    }
}
