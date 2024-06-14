using Models.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface ISeguro
    {
        public Seguro InserirSeguro(Seguro seguro);

        public Seguro GetSeguro(int id);

        public List<Seguro> GetSeguro();
    }
}
