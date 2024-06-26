﻿using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesADO
{
    public class CartaoRepositoryADO : ICartaoRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Cartao GetCartao(string numeroCartao)
        {
            throw new NotImplementedException();
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
