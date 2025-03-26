namespace Ambev.DeveloperEvaluation.Common.Messaging;

public interface IMessageProducer
{
    Task SendMessageAsync<T>(T message, string routingKey);
}