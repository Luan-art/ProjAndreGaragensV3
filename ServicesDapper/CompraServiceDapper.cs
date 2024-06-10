﻿using Models;
using RepositoriesDapper;
using System;

namespace ServicesDapper
{
    public class CompraServiceDapper
    {
        private readonly ICompraRepositoryDapper _compraRepository;

        public CompraServiceDapper(ICompraRepositoryDapper compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public bool InserirCompra(Compra compra)
        {
            try
            {
                return _compraRepository.InserirCompra(compra);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                return false;
            }
        }

        public Compra GetCompra(int id) => _compraRepository.GetCompra(id);
    }
}