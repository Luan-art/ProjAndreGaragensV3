using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;

namespace ServicesADO
{
    public class PagamentoServiceADO
    {
        private readonly IPagamentoRepositoryADO _pagamentoRepository;

        public PagamentoServiceADO(IPagamentoRepositoryADO pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public bool InjetarPagamento(Pagamento pagamento)
        {
            try
            {
                return _pagamentoRepository.InjetarPagamento(pagamento);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Pagamento GetPagamento(int id) => _pagamentoRepository.GetPagamento(id);
    }
}
