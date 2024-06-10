using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class CarroRepositoryDapper : ICarroRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Carro GetCarro(string placa)
        {
            Carro carro = null;
            string sql = "SELECT Placa, Nome, AnoModelo, Cor, Vendido FROM Carro WHERE Placa = @Placa";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    carro = db.QuerySingleOrDefault<Carro>(sql, new { Placa = placa });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return carro;
        }

        public bool InserirCarro(Carro carro)
        {
            bool result = false;
            string sql = "INSERT INTO Carro (Placa, Nome, AnoModelo, Cor, Vendido) " +
                "VALUES (@Placa, @Nome, @AnoModelo, @Cor, @Vendido);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new
                    {
                        Placa = carro.Placa,
                        Nome = carro.Nome,
                        AnoModelo = carro.AnoModelo,
                        Cor = carro.Cor,
                        Vendido = carro.Vendido
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
