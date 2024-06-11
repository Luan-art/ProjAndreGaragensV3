using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;
using InterfaceRepositorys;

namespace ServicesADO
{
    public class VendaServiceADO
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaServiceADO(IVendaRepository vendaRepository)
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
