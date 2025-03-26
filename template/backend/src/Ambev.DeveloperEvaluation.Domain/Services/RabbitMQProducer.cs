using System.Text;
using Ambev.DeveloperEvaluation.Common.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public class RabbitMQProducer : IMessageProducer
{
    private readonly RabbitMqConfiguration _configuration;

    public RabbitMQProducer(RabbitMqConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMessageAsync<T>(T message, string routingKey)
    {
        var factory = new ConnectionFactory() 
        { 
            HostName = _configuration.HostName, 
            Port = _configuration.Port,
            UserName = _configuration.UserName, 
            Password = _configuration.Password
        };

        var connection = await factory.CreateConnectionAsync();

        using (var channel = await connection.CreateChannelAsync())
        {

            await channel.QueueDeclareAsync(queue: routingKey,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
                                    
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(exchange: "", routingKey: "", body: body, cancellationToken: default);
        }
    }
}