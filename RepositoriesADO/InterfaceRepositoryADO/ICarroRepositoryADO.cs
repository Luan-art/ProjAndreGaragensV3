using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO.InterfaceRepositoryADO
{
    public interface ICarroRepositoryADO
    {
        bool InserirCarro(Carro carros);
        Carro GetCarro(string placa);
    }
}
