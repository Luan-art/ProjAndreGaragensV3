using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesADO
{
    public class CargoRepositoryADO : ICargoRepositoryADO
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Cargo GetCargo(int? v)
        {
            throw new NotImplementedException();
        }

        public Carro GetCargo(int id)
        {
            throw new NotImplementedException();
        }

        public bool InserirCargo(Cargo cargo)
        {
            bool result = false;
            string sql = "INSERT INTO Cargo (Descricao) VALUES (@Descricao);";
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

        Cargo ICargoRepositoryADO.GetCargo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
