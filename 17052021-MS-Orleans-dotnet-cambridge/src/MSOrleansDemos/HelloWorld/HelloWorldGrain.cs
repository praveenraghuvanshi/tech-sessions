using System.Threading.Tasks;
using HelloWorld.Interfaces;
using Orleans;
using Orleans.Providers;

namespace HelloWorld
{
    public class HelloState
    {
        public string Message { get; set; }
    }

    [StorageProvider(ProviderName = "MongoDBStore")]
    public class HelloWorldGrain : Grain<HelloState>, IHelloWorld
    {
        public Task<string> SayHello(string message)
        {
            this.State.Message = message;
            this.WriteStateAsync();
            return Task.FromResult($"Received message: {message} from grain with Id: {this.GetPrimaryKeyString()}");
        }
    }
}
