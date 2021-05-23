namespace Tests.Api.Host
{
    public class Program
    {
        public static void Main(string[] args) => Kitpymes.Core.Api.CreateHost.Run<Startup>(args);
    }
}
