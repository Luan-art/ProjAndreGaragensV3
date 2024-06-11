using InterfaceRepositorys;
using Models;
using RepositoriesADO;

namespace ServicesADO
{
    public class CarroServiceADO
    {
        private readonly ICarroRepository _carroRepository;

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
