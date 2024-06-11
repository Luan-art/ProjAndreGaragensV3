using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class PendenciaFinanceiraDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPendencia { get; set; }
        public DateTime DataCobranca { get; set; }
        public bool Status { get; set; }
        public string ClienteDocumento { get; set; }
    }
}
