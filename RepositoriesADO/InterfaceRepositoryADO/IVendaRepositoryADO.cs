using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public interface IVendaRepositoryADO
    {
        bool InserirVenda(Venda venda);
        Venda GetVenda(int id);
    }
}
