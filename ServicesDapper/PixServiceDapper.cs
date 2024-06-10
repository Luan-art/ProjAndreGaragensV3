using Models;
using RepositoriesDapper;
using System;

namespace ServicesDapper
{
    public class PixServiceDapper
    {
        private readonly IPixRepositoryDapper _pixRepository;

        public PixServiceDapper(IPixRepositoryDapper pixRepository)
        {
            _pixRepository = pixRepository;
        }

        public bool InserirPix(Pix pix)
        {
            try
            {
                return _pixRepository.InserirPix(pix);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Pix GetPix(string id) => _pixRepository.GetPix(id);
    }
}
