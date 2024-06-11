using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public class DependenteRepository : IDependente
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV3; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Dependente GetDependente()
        {
            throw new NotImplementedException();
        }

        public Dependente InserirDependente(Dependente dependente)
        {
            throw new NotImplementedException();
        }

        /*      public Dependente InserirDependente(Dependente dependente)
              {

              }

              public Dependente IDependente.GetDependente()
              {
                  DependenteRepository depende = new DependenteRepository();
                  string sql = "SELECT Documento, Nome, DataNascimento, Endereco, Telefone, Email, Cliente  WHERE Documento = @Documento";

                  try
                  {
                      using (var db = new SqlConnection(strConn))
                      {
                          db.Open();

                          using (var cmd = new SqlCommand(sql, db))
                          {
                              cmd.Parameters.AddWithValue("@Documento", documento);

                              using (var reader = cmd.ExecuteReader())
                              {
                                  if (reader.Read())
                                  {
                                      var dependente = new Models.Dependente
                                      {
                                          Documento = reader["Documento"].ToString(),
                                          Nome = reader["Nome"].ToString(),
                                          DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                                          Endereco = reader["Endereco"].ToString(),
                                          Telefone = reader["Telefone"].ToString(),
                                          Email = reader["Email"].ToString()
                                      };

                                      return dependente;
                                  }
                              }
                          }
                      }
                  }
                  catch (Exception ex)
                  {
                      Console.WriteLine(ex);
                  }

                  return null; // Retorna null se o dependente não for encontrado ou se ocorrer um erro
              }*/
    }
}
