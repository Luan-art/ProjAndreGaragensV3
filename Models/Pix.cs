using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pix
    {
        public int Id { get; set; }
        public TipoPix Tipo { get; set; }
        public string ChavePix { get; set; }

        public Pix() { }
        public Pix(PixDTO dto)
        {
            Tipo = new TipoPix { Id = dto.Tipo };
            ChavePix = dto.ChavePix;
        }
    }
}
