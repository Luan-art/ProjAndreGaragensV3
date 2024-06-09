using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class PagamentoDTO
    {
        public int Id { get; set; }
        public string Cartao { get; set; }
        public int Boleto { get; set; }
        public int Pix { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
