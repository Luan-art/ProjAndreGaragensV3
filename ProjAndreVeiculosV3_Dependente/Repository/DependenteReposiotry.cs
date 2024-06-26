﻿using InterfaceRepositorys;
using Microsoft.Data.SqlClient;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesADO
{
    public class DependenteRepository : IDependente
    {
        private string strConn = "Data Source=127.0.0.1; Initial Catalog=DBAndGarEntV3; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public Dependente InserirDependente(Dependente dependente)
        {
            string sql = "INSERT INTO Dependente (Documento, Nome, DataNascimento, Endereco, Telefone, Email, ClienteID) " +
                                    "VALUES (@Documento, @Nome, @DataNascimento, @Endereco, @Telefone, @Email, @ClienteID);";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    using (var cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@Documento", dependente.Documento);
                        cmd.Parameters.AddWithValue("@Nome", dependente.Nome);
                        cmd.Parameters.AddWithValue("@DataNascimento", dependente.DataNascimento);
                        cmd.Parameters.AddWithValue("@Endereco", dependente.Endereco);
                        cmd.Parameters.AddWithValue("@Telefone", dependente.Telefone);
                        cmd.Parameters.AddWithValue("@Email", dependente.Email);
                        cmd.Parameters.AddWithValue("@ClienteID", dependente.Cliente);

                        return dependente;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public DependenteDTO GetDependente(string documento)
        {
            string sql = "SELECT Documento, Nome, DataNascimento, Endereco, Telefone, Email, Cliente FROM Cliente WHERE Documento = @Documento";

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    using (var cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@Documento", documento);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DependenteDTO dependente = new DependenteDTO
                                {
                                    Documento = reader.GetString(0),
                                    Nome = reader.GetString(1),
                                    DataNascimento = reader.GetDateTime(2),
                                    EnderecoId = reader.GetInt32(3),
                                    Telefone = reader.GetString(4),
                                    Email = reader.GetString(5),
                                    ClienteID = reader.GetString(6)
                                };

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

            return null;
        }

        public List<DependenteDTO> GetDependente()
        {
            string sql = "SELECT Documento, Nome, DataNascimento, Endereco, Telefone, Email, Cliente FROM Cliente";
            List<DependenteDTO> dependentes = new List<DependenteDTO>();

            try
            {
                using (var db = new SqlConnection(strConn))
                {
                    db.Open();

                    using (var cmd = new SqlCommand(sql, db))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DependenteDTO dependente = new DependenteDTO
                                {
                                    Documento = reader.GetString(0),
                                    Nome = reader.GetString(1),
                                    DataNascimento = reader.GetDateTime(2),
                                    EnderecoId = reader.GetInt32(3),
                                    Telefone = reader.GetString(4),
                                    Email = reader.GetString(5),
                                    ClienteID = reader.GetString(6)
                                };

                                dependentes.Add(dependente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return dependentes;
        }

    }
}