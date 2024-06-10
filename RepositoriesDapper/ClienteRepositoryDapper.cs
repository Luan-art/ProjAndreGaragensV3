using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class ClienteRepositoryDapper : IClienteRepositoryDapper
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Clientes GetCliente(string documento)
        {
            throw new NotImplementedException();
        }

        public bool InserirCliente(Clientes cliente)
        {
            bool result = false;
            string sql = "INSERT INTO Cliente (Documento, Renda, Nome, DataNascimento, EnderecoID, Telefone, Email) " +
                "VALUES (@Documento, @Renda, @Nome, @DataNascimento, @EnderecoID, @Telefone, @Email);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new
                    {
                        Documento = cliente.Documento,
                        Renda = cliente.Renda,
                        Nome = cliente.Nome,
                        DataNascimento = cliente.DataNascimento,
                        EnderecoId = cliente.Endereco.Id,
                        Telefone = cliente.Telefone,
                        Email = cliente.Email
                    });

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
