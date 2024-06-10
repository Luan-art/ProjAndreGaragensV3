using Models;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesDapper
{
    public class EnderecoServiceDapper
    {
        private readonly IEnderecoRepositoryDapper _enderecoRepository;

        public EnderecoServiceDapper(IEnderecoRepositoryDapper enderecoRepository)
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
