using Models;

namespace InterfaceRepositorys
{
    public interface IDependente
    {
        public Dependente InserirDependente(Dependente dependente);

        public Dependente GetDependente();
    }
}
