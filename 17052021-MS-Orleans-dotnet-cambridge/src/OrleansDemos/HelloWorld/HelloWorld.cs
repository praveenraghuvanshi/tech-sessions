using System.Threading.Tasks;
using HelloWorldInterfaces;
using Orleans;

namespace HelloWorld
{
    public class HelloWorld : Grain, IHelloWorld
    {
        public Task<string> SayHello(string greeting)
        {
            return Task.FromResult($"Hello World Grain says: {greeting}!!!");
        }
    }
}
