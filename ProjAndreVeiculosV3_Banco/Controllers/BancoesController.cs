using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using ProjAndreVeiculosV3_Banco.Service;
using RabbitMQ.Client;
using System.Net;
using System.Text;

namespace ProjAndreVeiculosV3_Banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private readonly BancoService _bancoService;
        private readonly IConnectionFactory _factory;
        private const string QUEUE_NAME = "BancoQueue";

        public BancosController(BancoService bancoService, IConnectionFactory factory)
        {
            _bancoService = bancoService;
            _factory = factory;
        }

        [HttpGet]
        public ActionResult<List<Banco>> Get()
        {
            return _bancoService.Get();
        }

        [HttpGet("{id:length(14)}", Name = "GetBanco")]
        public ActionResult<Banco> Get(string id) => _bancoService.Get(id);

        [HttpPost]
        public async Task<ActionResult<Banco>> Create([FromBody] Banco banco)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: QUEUE_NAME,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var stringfieldMessage = JsonConvert.SerializeObject(banco);
                    var bytesMessage = Encoding.UTF8.GetBytes(stringfieldMessage);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: QUEUE_NAME,
                        basicProperties: null,
                        body: bytesMessage
                    );
                }
            }

            _bancoService.Create(banco);
            return CreatedAtAction(nameof(Get), new { id = banco.CNPJ }, banco);
        }
    }
}
