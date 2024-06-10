using Models;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesDapper
{
    public class ServicoServiceDapper
    {
        private readonly IServicoRepositoryDapper _servicoRepository;

        public ServicoServiceDapper(IServicoRepositoryDapper servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public bool InserirServicos(List<Servico> servicos)
        {
            try
            {
                foreach (var servico in servicos)
                {
                    _servicoRepository.InserirServicos(servico);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Servico GetServico(int id) => _servicoRepository.GetService(id);
    }
}
