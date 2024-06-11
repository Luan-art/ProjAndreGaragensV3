using Models;
using InterfaceRepositorys;
using System;

namespace ServicesDapper
{
    public class PixServiceDapper
    {
        private readonly IPixRepository _pixRepository;

        public PixServiceDapper(IPixRepository pixRepository)
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
