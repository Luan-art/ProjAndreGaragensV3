using Models;
using RepositoriesDapper;
using System;

namespace ServicesDapper
{
    public class ClienteServiceDapper
    {
        private readonly IClienteRepositoryDapper _clienteRepository;

        public ClienteServiceDapper(IClienteRepositoryDapper clienteRepository)
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
