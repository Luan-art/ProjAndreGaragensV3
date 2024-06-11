using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Numerics;

namespace RepositoriesDapper
{
    public class BoletoRepositoryDapper : IBoletoRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Boleto GetBoleto(string id)
        {
            Boleto boleto = new Boleto();
            string sql = "SELECT Numero, DataVencimento FROM Boleto WHERE id = @Id";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    boleto = db.QuerySingleOrDefault<Boleto>(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return boleto;
        }

        public bool InserirBoleto(Boleto boleto)
        {
            bool result = false;
            string sql = "INSERT INTO Boleto (Numero, DataVencimento) " +
                "VALUES (@Numero, @DataVencimento);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new { Numero = boleto.Numero, DataVencimento = boleto.DataVencimento });

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
