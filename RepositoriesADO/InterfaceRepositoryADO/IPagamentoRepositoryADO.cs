using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public interface IPagamentoRepositoryADO
    {
        bool InjetarPagamento(Pagamento pagamento);
        Pagamento GetPagamento(int id);
    }
}
