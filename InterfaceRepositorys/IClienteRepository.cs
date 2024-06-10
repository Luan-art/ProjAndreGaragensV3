using Models;

namespace InterfaceRepositorys
{
    public interface IClienteRepository
    {
        bool InserirCliente(Clientes cliente);
        Clientes GetCliente(string documento);
    }
}
