using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SeguroDTO
    {

        public int Id { get; set; }
        public string Cliente { get; set; }
        public decimal Franquia { get; set; }
        public string Carro { get; set; }
        public string CondutorPrincipal { get; set; }
    }
}
