using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesADO
{
    public class BoletoServiceADO
    {
        private IBoletoRepositoryADO _boletoRepository;

        public BoletoServiceADO()
        {
            _boletoRepository = new BoletoRepositoryADO();
        }

        public bool InserirBoleto(List<Boleto> boletos)
        {
            try
            {
                foreach (var boleto in boletos)
                {
                    _boletoRepository.InserirBoleto(boleto);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Boleto GetBoleto(string v) => _boletoRepository.GetBoleto(v);
    }
}
