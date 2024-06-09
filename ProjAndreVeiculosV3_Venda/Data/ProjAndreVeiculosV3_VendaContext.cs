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

        public DbSet<Models.Venda> Vendas { get; set; } = default!;
        public DbSet<Models.Carro> Carro { get; set; } = default!;
        public DbSet<Models.Pessoas> Pessoas { get; set; } = default!;
        public DbSet<Models.Clientes> Cliente { get; set; } = default!;
        public DbSet<Models.Funcionario> Funcionarios { get; set; } = default!;
        public DbSet<Models.Pagamento> Pagamento { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Venda>()
                .ToTable("Vendas");

            modelBuilder.Entity<Pessoas>()
                .ToTable("Pessoas")
                .HasDiscriminator<string>("PessoaType")
                .HasValue<Clientes>("Clientes")
                .HasValue<Funcionario>("Funcionarios");

            base.OnModelCreating(modelBuilder);
        }

    }
}
