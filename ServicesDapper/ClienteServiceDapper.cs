using Models;
using RepositoriesDapper;
using System;
using InterfaceRepositorys;

namespace ServicesDapper
{
    public class ClienteServiceDapper
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServiceDapper(IClienteRepository clienteRepository)
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
