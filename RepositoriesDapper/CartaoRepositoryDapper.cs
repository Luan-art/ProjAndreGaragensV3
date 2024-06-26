﻿using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class CartaoRepositoryDapper : ICartaoRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Cartao GetCartao(string numeroCartao)
        {
            Cartao cartao = new Cartao();
            string sql = "SELECT NumeroCartao, CodigoSeguranca, DataValidade, NomeCartao FROM cartao WHERE NumeroCartao = @nC";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    cartao = db.QuerySingleOrDefault<Cartao>(sql, new { nC = numeroCartao });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return cartao;
        }

        public bool InserirCartoes(Cartao cartao)
        {
            bool result = false;
            string sql = "INSERT INTO Cartao (NumeroCartao, CodigoSeguranca, DataValidade, NomeCartao) " +
                "VALUES (@NumeroCartao, @CodigoSeguranca, @DataValidade, @NomeCartao);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new
                    {
                        NumeroCartao = cartao.NumeroCartao,
                        CodigoSeguranca = cartao.CodigoSeguranca,
                        DataValidade = cartao.DataValidade,
                        NomeCartao = cartao.NomeCartao
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
