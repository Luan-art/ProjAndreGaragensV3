using InterfaceRepositorys;
using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesADO
{
    public class CargoServiceADO
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoServiceADO()
        {
            _cargoRepository = new CargoRepositoryADO();
        }

        public bool InserirCargos(List<Cargo> cargos)
        {
            try
            {
                foreach (var cargo in cargos)
                {
                    _cargoRepository.InserirCargo(cargo);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Cargo GetCargo(int id) => _cargoRepository.GetCargo(id);
    }
}
