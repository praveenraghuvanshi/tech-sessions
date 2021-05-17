using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Hosting;

namespace HelloWorld.Host
{
    class Program
    {
        static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            var hostBuilder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .ConfigureApplicationParts(parts => parts.AddFromApplicationBaseDirectory())
                .ConfigureLogging(logging => logging.AddConsole())
                .UseDashboard();
                

            var host = hostBuilder.Build();
            
            // Start server
            await host.StartAsync();

            Console.WriteLine("\n\nSilo host started successfully...");
            Console.WriteLine("Press any key to terminate...\n\n");
            Console.ReadKey();
            
            await host.StopAsync();

            return 0;
        }
    }
}
