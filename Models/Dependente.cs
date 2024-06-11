using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dependente : Pessoa
    {
        public Cliente Cliente { get; set; }

        public Dependente() { }

        public Dependente(DependenteDTO dto){

            Cliente = new Cliente { Documento = dto.ClienteID };
        }
    }
}
