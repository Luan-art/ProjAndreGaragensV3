using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesDapper
{
    public interface IServicoRepositoryDapper
    {
        bool InserirServicos(Servico servicos);
        Servico GetService(int id);
    }
}
