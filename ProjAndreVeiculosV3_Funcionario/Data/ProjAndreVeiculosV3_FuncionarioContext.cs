using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Funcionario.Data
{
    public class ProjAndreVeiculosV3_FuncionarioContext : DbContext
    {
        public ProjAndreVeiculosV3_FuncionarioContext(DbContextOptions<ProjAndreVeiculosV3_FuncionarioContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Cargo> Cargo { get; set; }

    }
}
