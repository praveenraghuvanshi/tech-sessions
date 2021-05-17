using System.Threading.Tasks;
using Orleans;

namespace HelloWorld.Interfaces
{
    public interface IHelloWorld : IGrainWithStringKey
    {
        Task<string> SayHello(string message);
    }
}
