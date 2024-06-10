using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;

namespace ServicesADO
{
    public class VendaServiceADO
    {
        private readonly IVendaRepositoryADO _vendaRepository;

        public VendaServiceADO(IVendaRepositoryADO vendaRepository)
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
