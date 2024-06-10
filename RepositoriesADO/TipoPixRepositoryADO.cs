using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;

namespace RepositoriesADO
{
    public class TipoPixRepositoryADO : ITipoPixRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public TipoPix GetTipoPix(int id)
        {
            throw new NotImplementedException();
        }

        public bool InserirTipoPix(TipoPix tiposPix)
        {
            bool result = false;
            string sql = "INSERT INTO TipoPix (Nome) VALUES (@Nome);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, tiposPix);

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
