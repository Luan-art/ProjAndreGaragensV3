using Models;
using RepositoriesADO;
using RepositoriesDapper;
using System;
using System.Collections.Generic;
using InterfaceRepositorys;


namespace ServicesADO
{
    public class CartaoServiceADO
    {
        private readonly ICartaoRepository _cartaoRepository;

        public CartaoServiceADO(ICartaoRepository cartaoRepository)
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
