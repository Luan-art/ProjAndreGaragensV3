using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;

namespace ProjAndreVeiculosV3_Financiamento.Repository
{
    public class FinanciamentoRepository : IFinanciamento
    {
        private readonly string strConn = "Data Source=127.0.0.1;Initial Catalog=DBAndGarEntV3;User Id=sa;Password=SqlServer2019!;TrustServerCertificate=Yes;";

        public List<Financiamento> GetFinanciamento()
        {
            List<Financiamento> financiamentos = new List<Financiamento>();
            string sql = "SELECT Id, vendaId, DataFinanciamento, BancoCNPJ FROM Financiamento";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    financiamentos = db.Query<Financiamento>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching records: {ex.Message}");
            }

            return financiamentos;
        }

        public Financiamento GetFinancimento(int id)
        {
            Financiamento fiananciamento = new Financiamento();
            string sql = "SELECT Id, vendaId, DataFinanciamento, BancoCNPJ FROM Financiamento WHERE id = @Id";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    fiananciamento = db.QuerySingleOrDefault<Financiamento>(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching record: {ex.Message}");
            }

            return fiananciamento;
        }

        public Financiamento InserirFinanciamento(Financiamento financiamento)
        {
            string sql = "INSERT INTO Financiamento (vendaId, DataFinanciamento, BancoCNPJ) " +
                                    "VALUES (@vendaId, @DataFinanciamento, @BancoCNPJ);";

            try
            {

                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    db.Execute(sql, new
                    {
                        vendaId = financiamento.venda.Id,
                        DataFinanciamento = financiamento.DataFinanciamento,
                        BancoCNPJ = financiamento.Banco.CNPJ,
                        
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting record: {ex.Message}");
                throw;
            }

            return financiamento;
        }
    }
}
