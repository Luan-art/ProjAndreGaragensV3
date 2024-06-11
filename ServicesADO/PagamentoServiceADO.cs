using InterfaceRepositorys;
using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;

namespace ServicesADO
{
    public class PagamentoServiceADO
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoServiceADO(IPagamentoRepository pagamentoRepository)
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
