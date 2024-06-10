using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;

namespace RepositoriesADO
{
    public class VendaRepositoryADO : IVendaRepositoryADO
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndresGaragem; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Venda GetVenda(int id)
        {
            throw new NotImplementedException();
        }

        public bool InserirVenda(Venda venda)
        {
            bool result = false;
            string sql = "INSERT INTO Venda (CarroPlaca, DataVenda, ValorVenda, ClienteDocumento, FuncionarioDocumento, PagamentoId)" +
                " VALUES (@CarroPlaca, @DataVenda, @ValorVenda, @ClienteDocumento, @FuncionarioDocumento, @PagamentoId);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new
                    {
                        CarroPlaca = venda.Carro.Placa,
                        DataVenda = venda.DataVenda,
                        ValorVenda = venda.ValorVenda,
                        ClienteDocumento = venda.Cliente.Documento,
                        FuncionarioDocumento = venda.Funcionario.Documento,
                        PagamentoId = venda.Pagamento.Id
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
