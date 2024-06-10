using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesADO
{
    public class FuncionarioRepositoryADO : IFuncionarioRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Funcionario GetFuncionario(string documento)
        {
            throw new NotImplementedException();
        }

        public bool InjetarFuncionario(Funcionario funcionario)
        {
            bool result = false;
            string sql = "INSERT INTO Funcionario ( Documento, CargoId, ValorComissao, Comissao, Nome, DataNascimento, EnderecoID, Telefone, Email) " +
                "VALUES (  @Documento, @CargoId, @ValorComissao, @Comissao, @Nome, @DataNascimento, @EnderecoID, @Telefone, @Email);";
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
