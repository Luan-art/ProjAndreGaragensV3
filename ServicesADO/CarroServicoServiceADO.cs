using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesADO
{
    public class CarroServicoServiceADO
    {
        private readonly ICarroServicoRepositoryADO _carroServiceRepository;

        public CarroServicoServiceADO()
        {
            _carroServiceRepository = new CarroServicoRepositoryADO();
        }

        public bool InserirCarros(CarroServico carros)
        {
            try
            {

                _carroServiceRepository.InserirCarroServico(carros);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public CarroServico GetCarroServico(int id) => _carroServiceRepository.GetCarroServico(id);
    }
}
