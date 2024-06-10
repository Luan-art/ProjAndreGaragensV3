using Models;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesDapper
{
    public class TipoPixServiceDapper
    {
        private readonly ITipoPixRepositoryDapper _tipoPixRepository;

        public TipoPixServiceDapper(ITipoPixRepositoryDapper tipoPixRepository)
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
