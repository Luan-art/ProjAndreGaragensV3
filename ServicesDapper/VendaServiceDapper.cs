using Models;
using RepositoriesDapper;
using System;

namespace ServicesDapper
{
    public class VendaServiceDapper
    {
        private readonly IVendaRepositoryDapper _vendaRepository;

        public VendaServiceDapper(IVendaRepositoryDapper vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public bool InserirVenda(Venda venda)
        {
            try
            {
                return _vendaRepository.InserirVenda(venda);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }
    }
}
