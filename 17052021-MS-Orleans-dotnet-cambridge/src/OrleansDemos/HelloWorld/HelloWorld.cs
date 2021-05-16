using System.Threading.Tasks;
using HelloWorldInterfaces;
using Orleans;
using Orleans.Providers;

namespace HelloWorld
{
    [StorageProvider(ProviderName = "MongoDBStore")]
    public class HelloWorld : Grain<HelloState>, IHelloWorld
    {
        public async Task<string> SayHello(string greeting)
        {
            var counter = this.State.Counter++;
            await this.WriteStateAsync();
            return $"Hello World Grain says: {greeting}, times - {counter}!!!";
        }
    }

    public class HelloState
    {
        public int Counter { get; set; }
    }
}
