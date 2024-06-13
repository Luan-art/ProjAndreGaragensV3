using Models;
using Models.DTO;

namespace InterfaceRepositorys
{
    public interface IDependente
    {
        public Dependente InserirDependente(Dependente dependente);

        public DependenteDTO GetDependente(string Documento);

        public List<DependenteDTO> GetDependente();

    }
}
