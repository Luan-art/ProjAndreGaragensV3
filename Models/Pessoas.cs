using Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Pessoas
    {
        [Key]
        public string Documento { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        [NotMapped]
        public Endereco Endereco { get; set; }

        public string Telefone   { get; set; }

        public string Email { get; set; }

        [Column("PessoaType")]
        public string PessoaType { get; set; }

        public Pessoas() { }
        public Pessoas(PessoaDTO dto)
        {
            Documento = dto.Documento;
            Nome = dto.Nome;
            DataNascimento = dto.DataNascimento;
            Endereco = new Endereco { Id = dto.Endereco};
            Email = dto.Email;
            Telefone = dto.Telefone;
            Email = dto.Email;
        }

    }
}
