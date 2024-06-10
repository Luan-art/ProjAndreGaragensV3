using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface ICartaoRepository
    {
        bool InserirCartoes(Cartao cartoes);
        Cartao GetCartao(string numeroCartao);
    }
}
