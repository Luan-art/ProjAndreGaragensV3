using InterfaceRepositorys;
using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesADO
{
    public class EnderecoServiceADO
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoServiceADO(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public bool InserirEnderecos(List<Endereco> enderecos)
        {
            try
            {
                foreach (var endereco in enderecos)
                {
                    _enderecoRepository.InserirEndereco(endereco);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Endereco GetEndereco(int id) => _enderecoRepository.GetEnd(id);
    }
}
