namespace Tests.Api.Host
{
    using System.Threading.Tasks;
    using Kitpymes.Core.Api;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args?.Length > 0)
            {
                // Host simple
                if (args[0] == "Simple")
                {
                    await CreateHost.RunSimpleAsync<Startup>(args);
                }

                // Host con logeo de errores
                if (args[0] == "Default")
                {
                    await CreateHost.RunAsync<Startup>(args);
                }

                // Host custom
                if (args[0] == "Custom")
                {
                    await CreateHost.Custom<Startup>(args)
                        .ConfigureLogging((context, logging) => logging.AddDebug().SetMinimumLevel(LogLevel.Trace))
                        .Build()
                        .RunAsync();
                }
            }
        }
    }
}
