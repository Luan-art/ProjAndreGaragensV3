using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class CompraRepositoryDapper : ICompraRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Compra GetCompra(int id)
        {
            Compra compra = new Compra();
            string sql = "SELECT CarroPlaca , Preco, DataCompra FROM Compra WHERE id = @Id";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    compra = db.QuerySingleOrDefault<Compra>(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return compra;
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
