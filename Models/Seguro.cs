using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Seguro
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Franquia { get; set; }
        public Carro Carro { get; set; }
        public Condutor CondutorPrincipal { get; set; }

        public Seguro() { }
        public Seguro(SeguroDTO dto)
        {
            Cliente = new Cliente { Documento = dto.Cliente };
            Franquia = dto.Franquia;
            Carro = new Carro { Placa = dto.Carro};
            CondutorPrincipal = new Condutor { Documento = dto.CondutorPrincipal };
        }

    }
}

