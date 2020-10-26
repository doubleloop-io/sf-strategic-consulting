using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;

namespace MarsRoverKata.RabbitHost
{
    public class RequestDispatcher : IDisposable
    {
        const string QUEUE_NAME = "mv-results";

        readonly IConnection connection;
        readonly IModel channel;
        readonly IRoverService service;

        public RequestDispatcher(IConnection connection, IRoverService service)
        {
            this.connection = connection;
            this.service = service;

            channel = connection.CreateModel();
            channel.QueueDeclare(QUEUE_NAME, false, false, false, null);
        }

        public void OnNext(byte[] requestBody)
        {
            var request = Deserialize(requestBody);
            var result = service.Handle(request);
            var responseBody = Serialize(result);
            SendResponse(responseBody);
        }

        void SendResponse(byte[] responseBody)
        {
            channel.BasicPublish("", QUEUE_NAME, null, responseBody);
        }

        static MovementRequest Deserialize(byte[] requestBody)
        {
            var message = Encoding.UTF8.GetString(requestBody);
            return JsonConvert.DeserializeObject<MovementRequest>(message);
        }

        static byte[] Serialize(MovementResult result)
        {
            var message = JsonConvert.SerializeObject(
                result,
                Formatting.None,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            return Encoding.UTF8.GetBytes(message);
        }

        public void Dispose() =>
            channel.Close();
    }
}
