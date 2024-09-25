using Microsoft.Extensions.Options;
using PolarisContacts.CreateService.Application.Interfaces.Messaging;
using RabbitMQ.Client;
using System.Text;

namespace PolarisContacts.CreateService.Infrastructure.Messaging
{
    public class RabbitMqProducer : IRabbitMqProducer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly PolarisContacts.Domain.Settings.RabbitMQ _rabbitMQSettings;

        public RabbitMqProducer(IOptions<PolarisContacts.Domain.Settings.RabbitMQ> rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;

            var factory = new ConnectionFactory()
            {
                HostName = _rabbitMQSettings.Host,
                UserName = _rabbitMQSettings.Username,
                Password = _rabbitMQSettings.Password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "contact_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: "contact_queue", basicProperties: null, body: body);
        }
    }

}
