using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class CarroServicoRepositoryDapper : ICarroServicoRepository
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

                    db.Execute(sql, new { ServicoId = carroServico.Servico.Id, CarroPlaca = carroServico.Carro.Placa });

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
