using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MarsRoverKata.RabbitHost
{
    static class Program
    {
        static void Main(string[] args)
        {
            var roverService = new RoverService();

            var connectionString = "amqp://rabbitmq:rabbitmq@localhost:5672";
            var factory = new ConnectionFactory {Uri = new Uri(connectionString)};
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            using var dispatcher = new RequestDispatcher(connection, roverService);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) => dispatcher.OnNext(ea.Body.ToArray());

            channel.QueueDeclare(
                "mv-requests",
                false,
                false,
                false,
                null);
            channel.BasicConsume(
                "mv-requests",
                true,
                consumer);

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();

            channel.Close();
            connection.Close();
        }
    }
}
