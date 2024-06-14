using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CNHDTO
    {
        public string Cnh { get; set; }

        public int CategoriaID { get; set; }

        public DateTime DataVencimento { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string NomeMae { get; set; }
        public string NomePai { get; set; }
    }
}
