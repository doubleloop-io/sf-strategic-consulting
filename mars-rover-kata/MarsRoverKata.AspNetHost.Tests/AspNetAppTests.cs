using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Quibble.Xunit;
using Xunit;

namespace MarsRoverKata.AspNetHost.Tests
{
    public class AspNetAppTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly WebApplicationFactory<Startup> factory;

        public AspNetAppTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task SendMovementRequest()
        {
            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            var response = await client.PostAsJsonAsync("rover", new
            {
                Commands = "FFLB"
            });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            JsonAssert.Equal(@"{""result"": ""1,0:N""}", result);
        }
    }
}
