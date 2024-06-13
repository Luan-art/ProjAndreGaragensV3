using Models.DTO;
using Models;
using InterfaceRepositorys;

namespace ProjAndreVeiculosV3_Dependente.Service
{
    public class DependenteService
    {

        private readonly IDependente _DependenteRepository;

        public DependenteService(IDependente dependenteRepository)
        {
            _DependenteRepository = dependenteRepository;
        }

        public Dependente InserirDependente(Dependente dependente)
        {
            try
            {
                return _DependenteRepository.InserirDependente(dependente);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return null;
            }
        }

        public DependenteDTO GetDependente(string id) => _DependenteRepository.GetDependente(id);

        public List<DependenteDTO> GetDependente() => _DependenteRepository.GetDependente();

    }
}


