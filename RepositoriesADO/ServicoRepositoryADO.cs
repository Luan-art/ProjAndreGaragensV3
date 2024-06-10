using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;

namespace RepositoriesADO
{
    public class ServicoRepositoryADO : IServicoRepositoryADO
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndresGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Servico GetService(int id)
        {
            throw new NotImplementedException();
        }

        public bool InserirServicos(Servico servicos)
        {
            bool result = false;
            string sql = "INSERT INTO Servico (Descricao) VALUES (@Descricao);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, servicos);
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
