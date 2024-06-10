﻿using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;

namespace RepositoriesDapper
{
    public class TipoPixRepositoryDapper : ITipoPixRepositoryDapper
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndresGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

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
