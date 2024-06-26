﻿using Dapper;
using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Numerics;

namespace RepositoriesDapper
{
    public class CarroServicoRepositoryDapper : ICarroServicoRepository
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV2; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public CarroServico GetCarroServico(int id)
        {
            CarroServico carro = new CarroServico();
            string sql = "SELECT Carro, Servico, Status FROM CarroServico WHERE id = @Id";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();
                    carro = db.QuerySingleOrDefault<CarroServico>(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return carro;
        }

        public bool InserirCarroServico(CarroServico carroServico)
        {
            bool result = false;
            string sql = "INSERT INTO CarroServico (ServicoID, CarroPlaca) " +
                "VALUES (@ServicoID, @CarroPlaca);";
            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    db.Execute(sql, new { ServicoId = carroServico.Servico.Id, CarroPlaca = carroServico.Carro.Placa });

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
