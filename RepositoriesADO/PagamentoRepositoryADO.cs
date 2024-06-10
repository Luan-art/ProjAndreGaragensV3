using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesADO
{
    public class PagamentoRepositoryADO : IPagamentoRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

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
