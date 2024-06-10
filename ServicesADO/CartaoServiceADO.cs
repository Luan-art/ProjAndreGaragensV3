using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;
using System.Collections.Generic;

namespace ServicesADO
{
    public class CartaoServiceADO
    {
        private readonly ICartaoRepositoryADO _cartaoRepository;

        public CartaoServiceADO(ICartaoRepositoryADO cartaoRepository)
        {
            _cartaoRepository = cartaoRepository;
        }

        public bool InserirCartoes(List<Cartao> cartoes)
        {
            try
            {
                foreach (var cartao in cartoes)
                {
                    _cartaoRepository.InserirCartoes(cartao);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Cartao GetCartao(string numeroCartao) => _cartaoRepository.GetCartao(numeroCartao);
    }
}
