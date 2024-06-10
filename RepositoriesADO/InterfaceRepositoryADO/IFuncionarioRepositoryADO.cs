using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public interface IFuncionarioRepositoryADO
    {
        bool InjetarFuncionario(Funcionario funcionario);
        Funcionario GetFuncionario(string documento);
    }
}
