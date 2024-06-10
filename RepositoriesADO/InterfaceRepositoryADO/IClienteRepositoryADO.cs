using Models;

namespace RepositoriesADO
{
    public interface IClienteRepositoryADO
    {
        bool InserirCliente(Clientes cliente);
        Clientes GetCliente(string documento);
    }
}
