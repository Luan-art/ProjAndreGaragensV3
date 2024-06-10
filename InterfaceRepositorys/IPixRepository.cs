using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface IPixRepository
    {
        bool InserirPix(Pix pix);
        Pix GetPix(string id);
    }
}
