using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CompraDTO
    {

        public int Id { get; set; }
        public string Carro { get; set; }
        public Decimal Preco { get; set; }
        public DateTime DataCompra { get; set; }

    }
}

