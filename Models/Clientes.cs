using Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Clientes : Pessoas
    {
        [Column("Renda")]
        public Decimal Renda { get; set; }

        public Clientes() { }
        public Clientes(ClienteDTO dto) : base (dto)
        { 
            Renda = dto.Renda;
            
        }
        
    }
}

   

