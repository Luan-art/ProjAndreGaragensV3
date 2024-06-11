using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    /* public class DependenteRepository : IDependente
     {
         private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV3; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

         public Dependente InserirDependente(Dependente dependente)
         {
             throw new NotImplementedException();
         }

         public Dependente GetDependente()
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

                         using (var reader = cmd.ExecuteReader())
                         {
                             while(reader.Read())
                             {
                                 DependenteDTO r = new DependenteDTO
                                 {
                                     Documento = reader.GetString(0),
                                     Nome = reader.GetString(1),
                                     DataNascimento = reader.GetDateTime(2),
                                     Telefone = reader.GetString(4)

                                 };

                             }


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

         }
     }
    */
}