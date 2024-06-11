using InterfaceRepositorys;
using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;

namespace ServicesADO
{
    public class FuncionarioServiceADO
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioServiceADO(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public bool InserirFuncionario(Funcionario funcionario)
        {
            try
            {
                return _funcionarioRepository.InjetarFuncionario(funcionario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Funcionario GetFuncionario(string documento) => _funcionarioRepository.GetFuncionario(documento);
    }
}
