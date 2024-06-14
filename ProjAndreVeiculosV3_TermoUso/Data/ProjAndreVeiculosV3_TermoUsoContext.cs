using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculosV3_TermoUso.Data
{
    public class ProjAndreVeiculosV3_TermoUsoContext : DbContext
    {
        public ProjAndreVeiculosV3_TermoUsoContext(DbContextOptions<ProjAndreVeiculosV3_TermoUsoContext> options)
        : base(options)
        {
        }

        public DbSet<Models.TermoDeUso> TermoDeUso { get; set; } = default!;
    }
}
