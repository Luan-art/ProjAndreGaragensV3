using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public interface ICargoRepositoryADO
    {
        bool InserirCargo(Cargo cargo);
        Cargo GetCargo(int id);
    }
}
