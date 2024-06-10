using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;

namespace RepositoriesDapper
{
    public class ServicoRepositoryDapper : IServicoRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

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
