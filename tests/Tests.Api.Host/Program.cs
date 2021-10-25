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
                if (args[0] == "Run")
                {
                    await InitHost.RunAsync<Startup>(args);
                }

                // Host customizado
                if (args[0] == "Build")
                {
                    await InitHost.Build<Startup>(args).RunAsync();
                }

                // Host custom
                if (args[0] == "Custom")
                {
                    await InitHost.Custom<Startup>(args)
                        .ConfigureLogging((context, logging) => logging.AddDebug().SetMinimumLevel(LogLevel.Trace))
                        .Build()
                        .RunAsync();
                }
            }
        }
    }
}
