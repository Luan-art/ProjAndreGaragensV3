using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public interface IServicoRepositoryADO
    {
        bool InserirServicos(Servico servicos);
        Servico GetService(int id);
    }
}
