using Kitpymes.Core.Api;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Tests.Api.AppSession
{
    public class Program
    {
        public static async Task Main(string[] args)
        => await InitHost.Build<Startup>(args).RunAsync();
    }
}
