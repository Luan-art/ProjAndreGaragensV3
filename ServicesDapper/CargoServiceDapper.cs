using Models;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesDapper
{
    public class CargoServiceDapper
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoServiceDapper()
        {
            _cargoRepository = new CargoRepositoryDapper();
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
