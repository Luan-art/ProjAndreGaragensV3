using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public interface IEnderecoRepositoryADO
    {
        bool InserirEndereco(Endereco enderecos);
        Endereco GetEnd(int id);
    }
}
