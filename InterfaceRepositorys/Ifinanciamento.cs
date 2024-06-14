using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceRepositorys
{
    public interface IFinanciamento
    {
        public Financiamento InserirFinanciamento(Financiamento financiamento);

        public Financiamento GetFinancimento(int id);

        public List<Financiamento> GetFinanciamento();
    }
}
