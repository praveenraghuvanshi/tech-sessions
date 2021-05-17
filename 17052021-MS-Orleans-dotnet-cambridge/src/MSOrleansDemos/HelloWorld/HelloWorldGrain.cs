using System.Threading.Tasks;
using HelloWorld.Interfaces;
using Orleans;

namespace HelloWorld
{
    public class HelloWorldGrain : Grain, IHelloWorld
    {
        public Task<string> SayHello(string message)
        {
            return Task.FromResult($"Received message: {message} from grain with Id: {this.GetPrimaryKeyString()}");
        }
    }
}
