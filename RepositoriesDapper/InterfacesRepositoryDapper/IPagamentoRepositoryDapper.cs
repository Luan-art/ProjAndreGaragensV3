using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesDapper
{
    public interface IPagamentoRepositoryDapper
    {
        bool InjetarPagamento(Pagamento pagamento);
        Pagamento GetPagamento(int id);
    }
}
