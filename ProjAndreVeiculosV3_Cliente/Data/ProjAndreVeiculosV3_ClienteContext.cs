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
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.Documento);
        }
    }
}

