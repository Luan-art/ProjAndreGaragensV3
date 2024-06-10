using Models;
using RepositoriesADO;
using RepositoriesADO.InterfaceRepositoryADO;

namespace ServicesADO
{
    public class CarroServiceADO
    {
        private readonly ICarroRepositoryADO _carroRepository;

        public CarroServiceADO()
        {
            _carroRepository = new CarroRepositoryADO();
        }

        public bool InserirCarros(List<Carro> carros)
        {
            try
            {
                foreach (var carro in carros)
                {
                    _carroRepository.InserirCarro(carro);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Carro GetCarro(string placa) => _carroRepository.GetCarro(placa);

    }
}
