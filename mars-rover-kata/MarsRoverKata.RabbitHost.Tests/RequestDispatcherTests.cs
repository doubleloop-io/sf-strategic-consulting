using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Testcontainers.Containers.Builders;
using DotNet.Testcontainers.Containers.Configurations.MessageBrokers;
using DotNet.Testcontainers.Containers.Modules.MessageBrokers;
using Newtonsoft.Json.Linq;
using Quibble.Xunit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Xunit;
using Xunit.Abstractions;

namespace MarsRoverKata.RabbitHost.Tests
{
    public class RequestDispatcherTests : IAsyncDisposable, IRoverService
    {
        readonly RabbitMqTestcontainer testContainer;
        readonly IConnection connection;

        [Fact]
        public async Task SendMovementRequest()
        {
            var requestConsumer = Task.Run(RequestConsumer);
            var resultConsumer = Task.Run(ResultConsumer);
            Thread.Sleep(1000);

            using var channel = connection.CreateModel();
            channel.QueueDeclare(
                "mv-requests",
                false,
                false,
                false,
                null);

            var json = JObject.FromObject(
                new
                {
                    Commands = "FFLB"
                });
            var message = json.ToString();
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(
                "",
                "mv-requests",
                null,
                body);

            await requestConsumer;
            var result = await resultConsumer;

            JsonAssert.Equal(@"{ ""result"": ""1,1:N:O"" }", result);
        }

        async Task RequestConsumer()
        {
            var dispatcher = new RequestDispatcher(connection, this);
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                "mv-requests",
                false,
                false,
                false,
                null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) => { dispatcher.OnNext(ea.Body.ToArray()); };

            channel.BasicConsume(
                "mv-requests",
                true,
                consumer);

            Thread.Sleep(2000);
        }

        async Task<string> ResultConsumer()
        {
            var result = "";
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                "mv-results",
                false,
                false,
                false,
                null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                result = message;
            };

            channel.BasicConsume(
                "mv-results",
                true,
                consumer);

            Thread.Sleep(4000);
            return result;
        }

        public RequestDispatcherTests()
        {
            var testContainersBuilder = new TestcontainersBuilder<RabbitMqTestcontainer>()
                .WithMessageBroker(
                    new RabbitMqTestcontainerConfiguration
                    {
                        Username = "rabbitmq",
                        Password = "rabbitmq"
                    });

            testContainer = testContainersBuilder.Build();
            testContainer.StartAsync().Wait();

            var connectionString = testContainer.ConnectionString;
            var factory = new ConnectionFactory {Uri = new Uri(connectionString)};
            connection = factory.CreateConnection();
        }

        public async ValueTask DisposeAsync()
        {
            connection.Close();
            await testContainer.DisposeAsync();
        }

        public MovementResult Handle(MovementRequest request) =>
            new MovementResult
            {
                Result = "1,1:N:O"
            };
    }
}
