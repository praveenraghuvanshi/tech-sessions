using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans;
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
            // Please note, the dashboard registers its services and grains using ConfigureApplicationParts which disables the automatic discovery of grains in Orleans. To enable automatic discovery of the grains of the original project, change the configuration to:
            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .ConfigureApplicationParts(parts => parts.AddFromApplicationBaseDirectory())
                .UseDashboard()
                .ConfigureLogging(logging => logging.AddConsole());

            var host = builder.Build();
            await host.StartAsync();
            return host;
        }
    }
}
