using InterfaceRepositorys;
using Models;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesDapper
{
    public class CarroServiceDapper
    {
        private readonly ICarroRepository _carroRepository;

        public CarroServiceDapper()
        {
            _carroRepository = new CarroRepositoryDapper();
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
