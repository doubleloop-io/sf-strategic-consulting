using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MarsRoverKata.HttpHost
{
    public class RequestDispatcher
    {
        readonly HttpListenerContext context;
        readonly IRoverService service;

        public RequestDispatcher(HttpListenerContext context, IRoverService service)
        {
            this.context = context;
            this.service = service;
        }

        public void OnNext()
        {
            var request = Deserialize();
            var result = service.Handle(request);
            var response = Serialize(result);
            SendResponse(response);
        }

        void SendResponse(byte[] body)
        {
            var response = context.Response;
            response.ContentLength64 = body.Length;
            using var output = response.OutputStream;
            output.Write(body, 0, body.Length);
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

        MovementRequest Deserialize()
        {
            var bodyRequest = context.Request;
            using var stream = bodyRequest.InputStream;
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<MovementRequest>(content);
        }
    }
}
