using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesADO
{
    public class TipoPixServiceADO
    {
        private readonly ITipoPixRepositoryADO _tipoPixRepository;

        public TipoPixServiceADO(ITipoPixRepositoryADO tipoPixRepository)
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
