using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesADO
{
    public class CarroServicoRepositoryADO : ICarroServicoRepositoryADO
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public CarroServico GetCarroServico(int id)
        {
            throw new NotImplementedException();
        }

        public bool InserirCarroServico(CarroServico carroServico)
        {
            bool result = false;
            string sql = "INSERT INTO CarroServico (ServicoID, CarroPlaca) " +
                "VALUES (@ServicoID, @CarroPlaca);";
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
