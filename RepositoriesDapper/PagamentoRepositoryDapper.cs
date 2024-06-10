﻿using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class PagamentoRepositoryDapper : IPagamentoRepositoryDapper
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndresGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Pagamento GetPagamento(int id)
        {
            throw new NotImplementedException();
        }

        public bool InjetarPagamento(Pagamento pagamento)
        {
            bool result = false;
            string sql = "INSERT INTO Pagamento ( CartaoNumero, BoletoId, PixId, DataPagamento) VALUES ( @CartaoNumero, @BoletoId, @PixId, @DataPagamento);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new
                    {
                        CartaoNumero = pagamento.Cartao.NumeroCartao,
                        BoletoId = pagamento.Boleto.Id
                    ,
                        PixId = pagamento.Pix.Id,
                        DataPagamento = pagamento.DataPagamento
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
