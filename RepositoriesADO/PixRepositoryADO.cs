using Microsoft.Data.SqlClient;
using Models;
using RepositoriesDapper;
using System;

namespace RepositoriesADO
{
    public class PixRepositoryADO : IPixRepositoryADO
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndresGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Pix GetPix(string id)
        {
            throw new NotImplementedException();
        }

        public bool InserirPix(Pix pix)
        {
            bool result = false;
            string sql = "INSERT INTO Pix (TipoPixId, ChavePix) VALUES (@TipoPixId, @ChavePix)";
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
