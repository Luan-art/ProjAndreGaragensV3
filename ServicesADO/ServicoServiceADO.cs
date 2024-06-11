using Models;
using InterfaceRepositorys;
using System;
using System.Collections.Generic;

namespace ServicesADO
{
    public class ServicoServiceADO
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoServiceADO(IServicoRepository servicoRepository)
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
