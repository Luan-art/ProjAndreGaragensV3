using Models;

namespace RepositoriesDapper
{
    public interface IClienteRepositoryDapper
    {
        bool InserirCliente(Clientes cliente);
        Clientes GetCliente(string documento);
    }
}
