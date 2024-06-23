using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConsumerServicce;

[ApiController]
public class ConsumerController: BackgroundService
{
    protected override async Task<Task> ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "user_data",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            ShowData(message);
        };

        channel.BasicConsume(queue: "user_data",
            autoAck: true,
            consumer: consumer);

        return Task.CompletedTask;
    }
    private void ShowData(string data)
    {
        Console.WriteLine(data);
    }
}