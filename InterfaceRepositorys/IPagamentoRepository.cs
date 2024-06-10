using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface IPagamentoRepository
    {
        bool InjetarPagamento(Pagamento pagamento);
        Pagamento GetPagamento(int id);
    }
}
