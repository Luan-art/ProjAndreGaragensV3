using Models;
using RepositoriesDapper;
using System;
using System.Collections.Generic;
using InterfaceRepositorys;

namespace ServicesDapper
{
    public class TipoPixServiceDapper
    {
        private readonly ITipoPixRepository _tipoPixRepository;

        public TipoPixServiceDapper(ITipoPixRepository tipoPixRepository)
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
