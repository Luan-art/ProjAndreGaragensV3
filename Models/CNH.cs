using Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CNH
    {
        [Key]
        public string Cnh { get; set; }

        public DateTime DataVencimento { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public Categoria Categoria { get; set; }

        public CNH() { }

        public CNH(CNHDTO dto)
        {
            this.Cnh = dto.Cnh;
            Categoria = new Categoria { Id = dto.CategoriaID };
            DataVencimento = dto.DataVencimento;
            Rg = dto.Rg;
            Cpf = dto.Cpf;
            NomeMae = dto.NomeMae;
            NomePai = dto.NomePai;

        }

    }
}
