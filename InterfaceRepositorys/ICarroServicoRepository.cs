using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface ICarroServicoRepository
    {
        bool InserirCarroServico(CarroServico carroServico);

        CarroServico GetCarroServico(int id);
    }
}
