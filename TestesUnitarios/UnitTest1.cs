using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using ProjAndreVeiculosV3_Carro.Controllers;
using ProjAndreVeiculosV3_Carro.Data;
using ProjAndreVeiculosV3_Cliente.Controllers;
using ProjAndreVeiculosV3_Cliente.Data;
using ProjAndreVeiculosV3_Servico.Controllers;
using ProjAndreVeiculosV3_Servico.Data;

namespace TestesUnitarios
{
    public class UnitTest1
    {

        private DbContextOptions<ProjAndreVeiculosV3_CarroContext> optionsCarro;
        private DbContextOptions<ProjAndreVeiculosV3_ServicoContext> optionsServico;
        private DbContextOptions<ProjAndreVeiculosV3_ClienteContext> optionsClient;

        private void InitializeDatabaseCarro()
        {
            optionsCarro = new DbContextOptionsBuilder<ProjAndreVeiculosV3_CarroContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            using (var context = new ProjAndreVeiculosV3_CarroContext(optionsCarro))
            {
                context.Carro.Add(new Carro { Placa = "ABC1234", Nome = "Fusca", AnoModelo = 1980, AnoFabricacao = 1979, Cor = "Azul", Vendido = false });
                context.Carro.Add(new Carro { Placa = "XYZ5678", Nome = "Gol", AnoModelo = 1995, AnoFabricacao = 1994, Cor = "Vermelho", Vendido = true });
                context.Carro.Add(new Carro { Placa = "JKL9876", Nome = "Civic", AnoModelo = 2010, AnoFabricacao = 2009, Cor = "Preto", Vendido = false });
                context.SaveChanges();
            }
        }

        private void InitializeDatabaseServico()
        {
            optionsServico = new DbContextOptionsBuilder<ProjAndreVeiculosV3_ServicoContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            using (var context = new ProjAndreVeiculosV3_ServicoContext(optionsServico))
            {
                context.Servico.Add(new Servico { Id = 1, Descricao = "Troca de óleo" });
                context.Servico.Add(new Servico { Id = 2, Descricao = "Revisão completa" });
                context.Servico.Add(new Servico { Id = 3, Descricao = "Alinhamento e balanceamento" });
                context.SaveChanges();
            }
        }

        private void InitializeDatabaseCliente()
        {
            optionsClient = new DbContextOptionsBuilder<ProjAndreVeiculosV3_ClienteContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            using (var context = new ProjAndreVeiculosV3_ClienteContext(optionsClient))
            {
                context.Cliente.Add(new Cliente
                {
                    Documento = "12345678901",
                    Nome = "João Silva",
                    DataNascimento = new DateTime(1980, 1, 1),
                    Endereco = new Endereco
                    {
                        Logradouro = "Rua A",
                        CEP = "12345-678",
                        Bairro = "Centro",
                        Complemento = "Apto 101",
                        Localidade = "Cidade X",
                        UF = "SP"
                    },
                    Telefone = "11987654321",
                    Email = "joao.silva@example.com",
                    Renda = 5000.00M
                });
                context.Cliente.Add(new Cliente
                {
                    Documento = "98765432100",
                    Nome = "Maria Oliveira",
                    DataNascimento = new DateTime(1990, 2, 2),
                    Endereco = new Endereco
                    {
                        Logradouro = "Rua B",
                        CEP = "23456-789",
                        Bairro = "Jardim",
                        Complemento = "Casa",
                        Localidade = "Cidade Y",
                        UF = "RJ"
                    },
                    Telefone = "21987654321",
                    Email = "maria.oliveira@example.com",
                    Renda = 6000.00M
                });
                context.Cliente.Add(new Cliente
                {
                    Documento = "19283746500",
                    Nome = "Carlos Pereira",
                    DataNascimento = new DateTime(1975, 3, 3),
                    Endereco = new Endereco
                    {
                        Logradouro = "Rua C",
                        CEP = "34567-890",
                        Bairro = "Industrial",
                        Complemento = "Galpão",
                        Localidade = "Cidade Z",
                        UF = "MG"
                    },
                    Telefone = "31987654321",
                    Email = "carlos.pereira@example.com",
                    Renda = 7000.00M
                });
                context.SaveChanges();
            }

        }

        [Fact]
        public void TestGetAllCarro()
        {
            InitializeDatabaseCarro();

            using (var context = new ProjAndreVeiculosV3_CarroContext(optionsCarro))
            {
                CarrosController carrosController = new CarrosController(context);
                IEnumerable<Carro> carros = carrosController.GetCarro().Result.Value;

                Assert.Equal(3, carros.Count());
            }
        }

        [Fact]
        public void CreateCarro()
        {
            InitializeDatabaseCarro();

            using (var context = new ProjAndreVeiculosV3_CarroContext(optionsCarro))
            {
                CarrosController controller = new CarrosController(context);
                Carro carro = new Carro { Placa = "MNO4321", Nome = "Fiesta", AnoModelo = 2015, AnoFabricacao = 2014, Cor = "Branco", Vendido = false };
                Carro createdCarro = controller.PostCarro(carro).Result.Value;
                Assert.Equal("MNO4321", createdCarro.Placa);
            }
        }
        [Fact]
        public void TestGetAllServico()
        {
            InitializeDatabaseServico();

            using (var context = new ProjAndreVeiculosV3_ServicoContext(optionsServico))
            {
                ServicosController servicosController = new ServicosController(context);
                IEnumerable<Servico> servicos = servicosController.GetServico().Result.Value;

                Assert.Equal(3, servicos.Count());
            }
        }

        [Fact]
        public void TestGetServicoById()
        {
            InitializeDatabaseServico();

            using (var context = new ProjAndreVeiculosV3_ServicoContext(optionsServico))
            {
                ServicosController servicosController = new ServicosController(context);
                Servico servico = servicosController.GetServico(2).Result.Value;
                Assert.Equal(2, servico.Id);
            }
        }

        [Fact]
        public void CreateServico()
        {
            InitializeDatabaseServico();

            using (var context = new ProjAndreVeiculosV3_ServicoContext(optionsServico))
            {
                ServicosController controller = new ServicosController(context);
                Servico servico = new Servico { Id = 4, Descricao = "Pintura" };
                Servico createdServico = controller.PostServico(servico).Result.Value;
                Assert.Equal("Pintura", createdServico.Descricao);
            }
        }

        [Fact]
        public void TestGetAllCliente()
        {
            InitializeDatabaseCliente();
            HttpClient client = new HttpClient();
            using (var context = new ProjAndreVeiculosV3_ClienteContext(optionsClient))
            {
                ClientesController clientesController = new ClientesController(context, client);
                IEnumerable<Cliente> clientes = clientesController.GetCliente().Result.Value;

                Assert.Equal(3, clientes.Count());
            }
        }

        [Fact]
        public void TestGetClienteById()
        {
            InitializeDatabaseCliente();
            HttpClient client = new HttpClient();

            using (var context = new ProjAndreVeiculosV3_ClienteContext(optionsClient))
            {
                ClientesController clientesController = new ClientesController(context, client);
                Cliente cliente = clientesController.GetCliente("98765432100").Result.Value;
                Assert.Equal("98765432100", cliente.Documento);
            }
        }

    } 
}