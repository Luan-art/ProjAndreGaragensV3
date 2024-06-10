using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesDapper
{
    public interface IVendaRepositoryDapper
    {
        bool InserirVenda(Venda venda);
        Venda GetVenda(int id);
    }
}
