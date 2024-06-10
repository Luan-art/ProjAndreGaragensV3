using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesDapper
{
    public interface ICartaoRepositoryDapper
    {
        bool InserirCartoes(Cartao cartoes);
        Cartao GetCartao(string numeroCartao);
    }
}
