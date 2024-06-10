using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesDapper
{
    public interface IBoletoRepositoryDapper
    {
        public bool InserirBoleto(Boleto boleto);

        Boleto GetBoleto(string? v);

    }
}
