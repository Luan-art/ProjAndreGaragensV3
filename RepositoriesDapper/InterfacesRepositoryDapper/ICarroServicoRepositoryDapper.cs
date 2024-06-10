using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesDapper
{
    public interface ICarroServicoRepositoryDapper
    {
        bool InserirCarroServico(CarroServico carroServico);

        CarroServico GetCarroServico(int id);
    }
}
