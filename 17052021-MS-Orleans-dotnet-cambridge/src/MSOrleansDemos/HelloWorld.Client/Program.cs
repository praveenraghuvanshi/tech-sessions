using System;
using System.Threading.Tasks;
using HelloWorld.Interfaces;
using Microsoft.Extensions.Logging;
using Orleans;

namespace HelloWorld.Client
{
    class Program
    {
        static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            var hostBuilder = new ClientBuilder()
                .UseLocalhostClustering()
                .ConfigureLogging(logging => logging.AddConsole());

            var host = hostBuilder.Build();
            await host.Connect();

            var helloWorldGrain = host.GetGrain<IHelloWorld>("hello");

            Console.WriteLine("\n\nEnter message");
            var message = Console.ReadLine();

            var response = await helloWorldGrain.SayHello(message);

            Console.WriteLine($"Silo responded: {response} >> Grain Id: {helloWorldGrain.GetPrimaryKeyString()}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            await host.Close();
            return 0;
        }
    }
}
