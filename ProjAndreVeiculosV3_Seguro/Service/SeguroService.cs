using InterfaceRepositorys;
using Models;
using Models.DTO;
using ProjAndreVeiculosV3_Seguro.Repository;

namespace ProjAndreVeiculosV3_Seguro.Service
{
    public class SeguroService
    {
        private readonly ISeguro _seguroRepository;

        public SeguroService()
        {
            _seguroRepository = new SeguroRepository();
        }

        public Seguro InserirSeguro(Seguro seguro)
        {
            try
            {
                _seguroRepository.InserirSeguro(seguro);

                return seguro;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return null;
            }
        }

        public Seguro GetSeguro(int id) => _seguroRepository.GetSeguro(id);

        public List<Seguro> GetSeguro() => _seguroRepository.GetSeguro();

    }
}
