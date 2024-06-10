using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesDapper
{
    public interface IPixRepositoryDapper
    {
        bool InserirPix(Pix pix);
        Pix GetPix(string id);
    }
}
