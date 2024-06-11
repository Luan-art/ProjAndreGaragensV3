using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Carro.Data
{
    public class ProjAndreVeiculosV3_CarroContext : DbContext
    {
        public ProjAndreVeiculosV3_CarroContext(DbContextOptions<ProjAndreVeiculosV3_CarroContext> options)
                   : base(options)
        {
        }

        public DbSet<Models.Carro> Carro { get; set; } = default!;
        public DbSet<Models.Pessoa>? Pessoa { get; set; } = default!;
        public DbSet<Models.Cliente>? Cliente { get; set; } = default!;
        public DbSet<Models.Funcionario>? Funcionario { get; set; } = default!;
        public DbSet<Models.Boleto>? Boleto { get; set; } = default!;
        public DbSet<Models.Cargo>? Cargo { get; set; } = default!;
        public DbSet<Models.CarroServico>? CarroServico { get; set; } = default!;
        public DbSet<Models.Cartao>? Cartao { get; set; } = default!;
        public DbSet<Models.Compra>? Compra { get; set; } = default!;
        public DbSet<Models.Endereco>? Endereco { get; set; } = default!;
        public DbSet<Models.Pagamento>? Pagamento { get; set; } = default!;
        public DbSet<Models.Pix>? Pix { get; set; } = default!;
        public DbSet<Models.Servico>? Servico { get; set; } = default!;
        public DbSet<Models.TipoPix>? TipoPix { get; set; } = default!;
        public DbSet<Models.Venda>? Venda { get; set; } = default!;

        public DbSet<Models.Categoria>? Categoria { get; set; } = default!;
        public DbSet<Models.CNH>? CNH { get; set; } = default!;
        public DbSet<Models.Condutor>? Condutor { get; set; } = default!;
        public DbSet<Models.Seguro>? Seguro { get; set; } = default!;
        public DbSet<Models.Dependente>? Dependente { get; set; } = default!;
        public DbSet<Models.PendenciaFinanceira>? PendenciaFinanceira { get; set; } = default!;
        public DbSet<Models.Financiamento>? Financiamento { get; set; } = default!;
        public DbSet<Models.AceiteTermoDeUso>? AceiteTermoDeUso { get; set; } = default!;
        public DbSet<Models.TermoDeUso>? TermoDeUso { get; set; } = default!;
        public DbSet<Models.Banco>? Banco { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura a chave primária na entidade raiz Pessoa
            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.Documento);

            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Funcionario>().ToTable("Funcionario");
            modelBuilder.Entity<Condutor>().ToTable("Condutor");
            modelBuilder.Entity<Dependente>().ToTable("Dependente");

            modelBuilder.Entity<Carro>().ToTable("Carro");
            modelBuilder.Entity<Boleto>().ToTable("Boleto");
            modelBuilder.Entity<Cargo>().ToTable("Cargo");
            modelBuilder.Entity<CarroServico>().ToTable("CarroServico");
            modelBuilder.Entity<Cartao>().ToTable("Cartao");
            modelBuilder.Entity<Compra>().ToTable("Compra");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Pagamento>().ToTable("Pagamento");
            modelBuilder.Entity<Pix>().ToTable("Pix");
            modelBuilder.Entity<Servico>().ToTable("Servico");
            modelBuilder.Entity<TipoPix>().ToTable("TipoPix");
            modelBuilder.Entity<Venda>().ToTable("Venda");

            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<CNH>().ToTable("CNH");
            modelBuilder.Entity<Seguro>().ToTable("Seguro");
            modelBuilder.Entity<PendenciaFinanceira>().ToTable("PendenciaFinanceira");
            modelBuilder.Entity<Financiamento>().ToTable("Financiamento");
            modelBuilder.Entity<AceiteTermoDeUso>().ToTable("AceiteTermoDeUso");
            modelBuilder.Entity<TermoDeUso>().ToTable("TermoDeUso");
            modelBuilder.Entity<Banco>().ToTable("Banco");
        }



    }
}

