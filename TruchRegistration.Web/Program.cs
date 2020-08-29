using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TruckRegistration
{
    class Program
    {
        static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(configure => configure.UseStartup<Startup>());
    }
}
