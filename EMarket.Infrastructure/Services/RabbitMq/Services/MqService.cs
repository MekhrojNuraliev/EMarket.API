using Emarket.Domain.RabbitMq.Models;
using EMarket.Application.Services.RabbitMq.Services;
using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.Services.RabbitMq.Services
{
    public class MqService : IMqService
    {
        public async Task<string> GetAsync(string hostName, string queue)
        {
            var factory = new ConnectionFactory { HostName = hostName };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            string response;
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                response = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {response}");
            };
            channel.BasicConsume(queue: queue,
                                 autoAck: true,
                                 consumer: consumer);
            return null;

        }

        public bool Send(MyRequestModel request)
        {
            ConnectionFactory factory = new ConnectionFactory { HostName = request.HostName };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue:request.Queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(request.Message);

            channel.BasicPublish(exchange: string.Empty,
                                routingKey: request.RoutingKey,
                                basicProperties: null,
                                body: messageBodyBytes);     
            return true;
        }
    }
}
