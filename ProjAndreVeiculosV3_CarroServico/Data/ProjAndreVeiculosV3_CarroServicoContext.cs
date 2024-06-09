using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_CarroServico.Data
{
    public class ProjAndreVeiculosV3_CarroServicoContext : DbContext
    {
        public ProjAndreVeiculosV3_CarroServicoContext (DbContextOptions<ProjAndreVeiculosV3_CarroServicoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.CarroServico> CarroServico { get; set; } = default!;
        public DbSet<Models.Servico> Servico { get; set; } = default!;
        public DbSet<Models.Carro> Carro { get; set; } = default!;

    }
}
