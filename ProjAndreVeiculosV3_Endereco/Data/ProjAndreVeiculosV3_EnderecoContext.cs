using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_Endereco.Data
{
    public class ProjAndreVeiculosV3_EnderecoContext : DbContext
    {
        public ProjAndreVeiculosV3_EnderecoContext (DbContextOptions<ProjAndreVeiculosV3_EnderecoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Endereco> Endereco { get; set; } = default!;
    }
}
