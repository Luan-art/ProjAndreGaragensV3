using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class FinanciamentoDTO
    {
        public int Id { get; set; }
        public int venda { get; set; }
        public DateTime DataFinanciamento { get; set; }
        public string Banco { get; set; }
    }
}
