using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface ITipoPixRepository
    {
        bool InserirTipoPix(TipoPix tiposPix);
        TipoPix GetTipoPix(int id);
    }
}
