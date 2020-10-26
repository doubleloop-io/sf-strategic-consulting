using System;
using System.Net;
using System.Threading.Tasks;

namespace MarsRoverKata.HttpHost
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var roverService = new RoverService();

            var baseAddress = "http://localhost:6000/"; // can take it from args
            var listener = new HttpListener();
            listener.Prefixes.Add(baseAddress);
            listener.Start();
            Console.WriteLine("Listening...");
            while (true)
            {
                var context = await listener.GetContextAsync();
                var dispatcher = new RequestDispatcher(context, roverService);
                dispatcher.OnNext();
            }
        }
    }
}
