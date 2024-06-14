using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Condutor : Pessoa
    {
        public CNH CNH { get; set; }

        public Condutor() { }
        public Condutor(CondutorDTO dto) : base(dto)
        {
            CNH = new CNH { Cnh = dto.CNHId };

        }
    }
}
