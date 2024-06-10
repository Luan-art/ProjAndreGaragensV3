using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;

namespace RepositoriesADO
{
    public class CarroRepositoryADO : ICarroRepository
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
                    using (var cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@Placa", placa);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                carro = new Carro
                                {
                                    Placa = reader["Placa"].ToString(),
                                    Nome = reader["Nome"].ToString(),
                                    AnoModelo = Convert.ToInt32(reader["AnoModelo"]),
                                    Cor = reader["Cor"].ToString(),
                                    Vendido = Convert.ToBoolean(reader["Vendido"])
                                };
                            }
                        }
                    }
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

                    using (var cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@Placa", carro.Placa);
                        cmd.Parameters.AddWithValue("@Nome", carro.Nome);
                        cmd.Parameters.AddWithValue("@AnoModelo", carro.AnoModelo);
                        cmd.Parameters.AddWithValue("@Cor", carro.Cor);
                        cmd.Parameters.AddWithValue("@Vendido", carro.Vendido);

                        cmd.ExecuteNonQuery();
                    }
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

