using Models;
using RepositoriesDapper;
using System;
using InterfaceRepositorys;

namespace ServicesDapper
{
    public class VendaServiceDapper
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaServiceDapper(IVendaRepository vendaRepository)
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
