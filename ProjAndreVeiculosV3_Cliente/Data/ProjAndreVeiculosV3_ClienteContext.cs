using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Cliente.Data
{
    public class ProjAndreVeiculosV3_ClienteContext : DbContext
    {
        public ProjAndreVeiculosV3_ClienteContext(DbContextOptions<ProjAndreVeiculosV3_ClienteContext> options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoas>()
                .ToTable("Pessoas")
                .HasDiscriminator<string>("PessoaType")
                .HasValue<Pessoas>("Pessoas")
                .HasValue<Funcionario>("Funcionarios")
                .HasValue<Clientes>("Clientes");

            base.OnModelCreating(modelBuilder);
        }
    }
}
