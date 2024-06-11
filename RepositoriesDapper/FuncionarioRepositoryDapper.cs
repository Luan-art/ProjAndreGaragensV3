using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesDapper
{
    public class FuncionarioRepositoryDapper : IFuncionarioRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Funcionario GetFuncionario(string documento)
        {
            Funcionario end = new Funcionario();
            string sql = "SELECT Documento , CargoId, ValorComissao, Comissao, Nome, DataNascimento, ENdereco, Telefone, Email FROM Pessoa WHERE Documento = @Documento";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    end = db.QuerySingleOrDefault<Funcionario>(sql, new { Documento = documento });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return end;
        }

        public bool InjetarFuncionario(Funcionario funcionario)
        {
            bool result = false;
            string sql = "INSERT INTO Pessoa ( Documento, CargoId, ValorComissao, Comissao, Nome, DataNascimento, Endereco, Telefone, Email, PessoaType) " +
                "VALUES (  @Documento, @CargoId, @ValorComissao, @Comissao, @Nome, @DataNascimento, @Endereco, @Telefone, @Email, @PessoaType);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new
                    {
                        Documento = funcionario.Documento,
                        CargoId = funcionario.Cargo.Id,
                        ValorComissao = funcionario.ValorComissao,
                        Comissao = funcionario.Comissao,
                        Nome = funcionario.Nome,
                        DataNascimento = funcionario.DataNascimento,
                        EnderecoId = funcionario.Endereco.Id,
                        Telefone = funcionario.Telefone,
                        Email = funcionario.Email,
                        PessoaType = "Funcionario"
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
