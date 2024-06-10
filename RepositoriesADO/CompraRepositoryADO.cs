using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesADO
{
    public class CompraRepositoryADO : ICompraRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Compra GetCompra(int id)
        {
            throw new NotImplementedException();
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
