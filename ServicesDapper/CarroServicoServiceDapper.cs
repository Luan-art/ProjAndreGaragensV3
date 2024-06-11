using InterfaceRepositorys;
using Models;
using RepositoriesDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesDapper
{
    public class CarroServicoServiceDapper
    {
        private readonly ICarroServicoRepository _carroServiceRepository;

        public CarroServicoServiceDapper()
        {
            _carroServiceRepository = new CarroServicoRepositoryDapper();
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
