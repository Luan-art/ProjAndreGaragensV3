using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Financiamento
    {
        public int Id { get; set; }
        public Venda venda { get; set; }
        public DateTime DataFinanciamento { get; set; }
        public Banco Banco { get; set; }

        public Financiamento() { }

        public Financiamento(FinanciamentoDTO dto) {

            venda = new Venda { Id = dto.venda };
            DataFinanciamento = dto.DataFinanciamento;
            Banco = new Banco { CNPJ = dto.Banco };

        }
    }
}
