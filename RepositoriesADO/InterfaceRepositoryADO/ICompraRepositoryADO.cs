using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public interface ICompraRepositoryADO
    {
        bool InserirCompra(Compra compra);
        Compra GetCompra(int id);
    }
}
