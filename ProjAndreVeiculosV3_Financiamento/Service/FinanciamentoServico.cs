using InterfaceRepositorys;
using Models;
using ProjAndreVeiculosV3_Financiamento.Repository;

namespace ProjAndreVeiculosV3_Financiamento.Service
{
    public class FinanciamentoServico
    {
        private readonly IFinanciamento _financiamentoRepository;

        public FinanciamentoServico()
        {
            _financiamentoRepository = new FinanciamentoRepository();
        }

        public Financiamento InserirFinanciamento(Financiamento financiamento)
        {
            try
            {
                _financiamentoRepository.InserirFinanciamento(financiamento);

                return financiamento;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return null;
            }
        }

        public Financiamento GetFinanciamento(int id) => _financiamentoRepository.GetFinancimento(id);

        public List<Financiamento> GetFinanciamento() => _financiamentoRepository.GetFinanciamento();
    }
}
