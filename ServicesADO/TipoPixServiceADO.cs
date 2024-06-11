using Models;
using RepositoriesADO;
using InterfaceRepositorys;
using System;
using System.Collections.Generic;

namespace ServicesADO
{
    public class TipoPixServiceADO
    {
        private readonly ITipoPixRepository _tipoPixRepository;

        public TipoPixServiceADO(ITipoPixRepository tipoPixRepository)
        {
            _tipoPixRepository = tipoPixRepository;
        }

        public bool InserirTiposPix(List<TipoPix> tiposPix)
        {
            try
            {
                foreach (var tipoPix in tiposPix)
                {
                    _tipoPixRepository.InserirTipoPix(tipoPix);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public TipoPix GetTipoPix(int id) => _tipoPixRepository.GetTipoPix(id);
    }
}
