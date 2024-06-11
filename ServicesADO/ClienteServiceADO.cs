using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;
using InterfaceRepositorys;

namespace ServicesADO
{
    public class ClienteServiceADO
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServiceADO(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool InserirCliente(Cliente cliente)
        {
            try
            {
                return _clienteRepository.InserirCliente(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Cliente GetCliente(string documento) => _clienteRepository.GetCliente(documento);
    }
}
