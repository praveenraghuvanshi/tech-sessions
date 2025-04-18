using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;

Console.WriteLine("Starting MCP .Net BLR server...");

var builder = Host.CreateApplicationBuilder(args);
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();

Console.WriteLine("MCP .Net BLR server stopped.");


[McpServerToolType]
public class TimeTool
{
    [McpServerTool, Description("Get the current time")]
    public string GetCurrentTime()
    {
        return DateTime.UtcNow.ToString("o");
    }
}