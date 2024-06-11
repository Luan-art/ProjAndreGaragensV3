using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class PixRepositoryDapper : IPixRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Pix GetPix(string id)
        {
            Pix pag = new Pix();
            string sql = "SELECT TipoId, ChavePix FROM Pix WHERE Id = @Id";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    pag = db.QuerySingleOrDefault<Pix>(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return pag;
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

                    db.Execute(sql, new { TipoPixId = pix.Tipo.Id, ChavePix = pix.ChavePix });

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
