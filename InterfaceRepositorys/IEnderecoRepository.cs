using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface IEnderecoRepository
    {
        bool InserirEndereco(Endereco enderecos);
        Endereco GetEnd(int id);
    }
}
