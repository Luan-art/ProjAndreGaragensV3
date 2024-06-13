using Models;
using Newtonsoft.Json;
using ProjAndreVeiculosV3_Banco_Consumer.Service;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

const string QUEUE_NAME = "BancoQueue";
var factory = new ConnectionFactory() { HostName = "localhost" };

using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: QUEUE_NAME,
                      durable: false,
                      exclusive: false,
                      autoDelete: false,
                      arguments: null);

        while (true)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var returnMessage = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<Banco>(returnMessage);
                Banco banco = new BancoService().PostBanco(message).Result;
                Console.WriteLine("Message: " + banco.CNPJ);

            };

            channel.BasicConsume(queue: QUEUE_NAME,
                                 autoAck: true,
                                 consumer: consumer);

            Thread.Sleep(2000);
        }
    }
}