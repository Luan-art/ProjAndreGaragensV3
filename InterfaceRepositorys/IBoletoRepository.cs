using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface IBoletoRepository
    {
        public bool InserirBoleto(Boleto boleto);

        Boleto GetBoleto(string? v);

    }
}
