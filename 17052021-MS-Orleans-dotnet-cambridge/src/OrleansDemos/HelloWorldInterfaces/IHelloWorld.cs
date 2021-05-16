using System.Threading.Tasks;
using Orleans;

namespace HelloWorldInterfaces
{
    public interface IHelloWorld : IGrainWithStringKey
    {
        Task<string> SayHello(string greeting);
    }
}
