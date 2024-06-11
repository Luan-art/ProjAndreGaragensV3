using InterfaceRepositorys;
using Models;
using RepositoriesDapper;
using System;

namespace ServicesDapper
{
    public class PagamentoServiceDapper
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoServiceDapper(IPagamentoRepository pagamentoRepository)
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
