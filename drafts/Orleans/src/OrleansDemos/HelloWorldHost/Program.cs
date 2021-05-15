using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Hosting;

namespace HelloWorldHost
{
    class Program
    {
        static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            var host = await StartSiloAsync();
            Console.WriteLine("\n\n Silo Started Successfully, Press Enter to terminate...\n\n");
            Console.ReadLine();

            await host.StopAsync();

            return 0;
        }

        private static async Task<ISiloHost> StartSiloAsync()
        {
            // Define cluster configuration
            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .ConfigureLogging(logging => logging.AddConsole())
                .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback);

            var host = builder.Build();
            await host.StartAsync();
            return host;
        }
    }
}
