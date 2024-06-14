using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Venda.Data
{
    public class ProjAndreVeiculosV3_VendaContext : DbContext
    {
        public ProjAndreVeiculosV3_VendaContext(DbContextOptions<ProjAndreVeiculosV3_VendaContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Venda> Venda { get; set; } = default!;
        public DbSet<Models.Carro> Carro { get; set; } = default!;
        public DbSet<Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<Models.Pagamento> Pagamento { get; set; } = default!;

    }
}
