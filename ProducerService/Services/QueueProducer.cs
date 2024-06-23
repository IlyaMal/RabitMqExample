using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace ProducerService.Services;

public class QueueProducer<T>
{
    public static void SendMessage(T data)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "user_data",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var message = JsonSerializer.Serialize(data);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                routingKey: "user_data",
                basicProperties: null,
                body: body);

        }
    }
}