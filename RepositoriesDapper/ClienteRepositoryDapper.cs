using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class ClienteRepositoryDapper : IClienteRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Cliente GetCliente(string documento)
        {
            Cliente cliente = new Cliente();
            string sql = "SELECT Documento, Renda, Nome, DataNascimento, Endereco, Telefone, Email FROM Pessoa WHERE Documento = @Documento";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    cliente = db.QuerySingleOrDefault<Cliente>(sql, new { Documento = documento });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return cliente;
        }

        public bool InserirCliente(Cliente cliente)
        {
            bool result = false;
            string sql = "INSERT INTO Pessoa (Documento, Renda, Nome, DataNascimento, Endereco, Telefone, Email, PessoaType) " +
                "VALUES (@Documento, @Renda, @Nome, @DataNascimento, @Endereco, @Telefone, @Email, PessoaType);";
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
                        Endereco = cliente.Endereco.Id,
                        Telefone = cliente.Telefone,
                        Email = cliente.Email,
                        PessoaType = "Cliente"
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
