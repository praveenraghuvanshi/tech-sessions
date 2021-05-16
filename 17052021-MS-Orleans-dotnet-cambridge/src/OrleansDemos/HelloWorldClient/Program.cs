using System;
using System.Threading.Tasks;
using HelloWorldInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;

namespace HelloWorldClient
{
    class Program
    {
        private static string connectionString = "mongodb://localhost/OrleansTestApp";

        static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            var client = await ConnectClientAsync();
            await DoClientWork(client);

            Console.ReadKey();
            client.Dispose();

            return 0;
        }

        private static async Task<IClusterClient> ConnectClientAsync()
        {
            IClusterClient client = new ClientBuilder()
                .UseLocalhostClustering()
                .UseMongoDBClient(connectionString)
                .UseMongoDBClustering(options =>
                {
                    options.DatabaseName = "OrleansTestApp";
                })
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();

            await client.Connect();
            Console.WriteLine("Client successfully connected to silo host");
            return client;
        }

        private static async Task DoClientWork(IClusterClient client)
        {
            var friend = client.GetGrain<IHelloWorld>("temp-2");
            Console.WriteLine("Enter a message to be sent to grain");
            var message = Console.ReadLine();

            var response = await friend.SayHello(message);
            Console.WriteLine($"\n\n{response}\n\n");
        }
    }
}
