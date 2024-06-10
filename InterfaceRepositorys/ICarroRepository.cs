using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface ICarroRepository
    {
        bool InserirCarro(Carro carros);
        Carro GetCarro(string placa);
    }
}
