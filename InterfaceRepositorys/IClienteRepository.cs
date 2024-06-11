using Models;

namespace InterfaceRepositorys
{
    public interface IClienteRepository
    {
        bool InserirCliente(Cliente cliente);
        Cliente GetCliente(string documento);
    }
}
