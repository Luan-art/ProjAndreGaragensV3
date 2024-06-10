using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;

namespace ServicesADO
{
    public class ClienteServiceADO
    {
        private readonly IClienteRepositoryADO _clienteRepository;

        public ClienteServiceADO(IClienteRepositoryADO clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool InserirCliente(Clientes cliente)
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

        public Clientes GetCliente(string documento) => _clienteRepository.GetCliente(documento);
    }
}
