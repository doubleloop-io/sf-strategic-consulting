using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Quibble.Xunit;
using Xunit;

namespace MarsRoverKata.HttpHost.Tests
{
    public class RequestDispatcherTests : IRoverService
    {
        [Fact]
        public async Task SendMovementRequest()
        {
            var requestTask = Task.Run(RequestListener);

            Thread.Sleep(1000);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            var json = JObject.FromObject(
                new
                {
                    Commands = "FFLB"
                });
            var response = await client.PostAsync("http://localhost:6000/", new StringContent(json.ToString()));
            var result = await response.Content.ReadAsStringAsync();

            await requestTask;
            JsonAssert.Equal(@"{ ""result"": ""1,1:N:O"" }", result);
        }

        async Task RequestListener()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:6000/");
            listener.Start();
            var context = await listener.GetContextAsync();
            var dispatcher = new RequestDispatcher(context, this);
            dispatcher.OnNext();
            listener.Stop();
        }

        public MovementResult Handle(MovementRequest request) =>
            new MovementResult
            {
                Result = "1,1:N:O"
            };
    }
}
