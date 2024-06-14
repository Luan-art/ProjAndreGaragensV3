using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjAndreVeiculosV3_Seguro.Repository
{
    public class SeguroRepository : ISeguro
    {
        private readonly string strConn = "Data Source=127.0.0.1;Initial Catalog=DBAndGarEntV3;User Id=sa;Password=SqlServer2019!;TrustServerCertificate=Yes;";

        public Seguro GetSeguro(int id)
        {
            Seguro seguro = new Seguro();
            string sql = "SELECT ClienteDocumento, Franquia, CarroPlaca, CondutorPrincipalDocumento FROM Seguro WHERE id = @Id";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    seguro = db.QuerySingleOrDefault<Seguro>(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching record: {ex.Message}");
            }

            return seguro;
        }

        public List<Seguro> GetSeguro()
        {
            List<Seguro> seguros = new List<Seguro>();
            string sql = "SELECT id, ClienteDocumento, Franquia, CarroPlaca, CondutorPrincipalDocumento FROM Seguro";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    seguros = db.Query<Seguro>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching records: {ex.Message}");
            }

            return seguros;
        }

        public Seguro InserirSeguro(Seguro seguro)
        {
            string sql = "INSERT INTO Seguro (ClienteDocumento, Franquia, CarroPlaca, CondutorPrincipalDocumento) " +
                         "VALUES (@ClienteDocumento, @Franquia, @CarroPlaca, @CondutorPrincipalDocumento);";

            try
            {
               
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    db.Execute(sql, new
                    {
                        ClienteDocumento = seguro.Cliente.Documento,
                        Franquia = seguro.Franquia,
                        CarroPlaca = seguro.Carro.Placa,
                        CondutorPrincipalDocumento = seguro.CondutorPrincipal.Documento
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting record: {ex.Message}");
                throw;
            }

            return seguro;
        }
    }
}
