using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;

namespace RepositoriesDapper
{
    public class EnderecoRepositoryDapper : IEnderecoRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Endereco GetEnd(int id)
        {
            Endereco end = new Endereco();
            string sql = "SELECT Logradouro , CEP, Bairro, Complemento, UF, Localidade FROM Endereco WHERE id = @Id";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    end = db.QuerySingleOrDefault<Endereco>(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return end;
        }

        public bool InserirEndereco(Endereco enderecos)
        {
            bool result = false;
            string sql = "INSERT INTO Endereco (Logradouro, CEP, Bairro, TipoLogradouro, Complemento, Numero, UF, Cidade) " +
                "VALUES (@Logradouro, @CEP, @Bairro, @TipoLogradouro, @Complemento, @Numero, @UF, @Cidade);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, enderecos);
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
