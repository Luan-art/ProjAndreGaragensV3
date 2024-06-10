﻿using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class CompraRepositoryDapper : ICompraRepositoryDapper
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndresGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Compra GetCompra(int id)
        {
            throw new NotImplementedException();
        }

        public bool InserirCompra(Compra compra)
        {
            bool result = false;
            string sql = "INSERT INTO Compra (CarroPlaca, DataCompra, ValorCompra, FuncionarioDocumento, PagamentoId)" +
                " VALUES (@CarroPlaca, @DataCompra, @ValorCompra, @FuncionarioDocumento, @PagamentoId);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new
                    {
                        CarroPlaca = compra.Carro.Placa,
                        DataCompra = compra.DataCompra,
                        ValorCompra = compra.Preco,
                    });

                }

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }
    }
}
