using Models;
using RepositoriesDapper;
using System;

namespace ServicesDapper
{
    public class FuncionarioServiceDapper
    {
        private readonly IFuncionarioRepositoryDapper _funcionarioRepository;

        public FuncionarioServiceDapper(IFuncionarioRepositoryDapper funcionarioRepository)
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
