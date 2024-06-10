using Models;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesDapper
{
    public class BoletoServiceDapper
    {
        private IBoletoRepositoryDapper _boletoRepository;

        public BoletoServiceDapper()
        {
            _boletoRepository = new BoletoRepositoryDapper();
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
