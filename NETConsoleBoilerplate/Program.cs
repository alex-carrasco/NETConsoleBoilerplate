using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETConsoleBoilerplate.Contracts;
using NETConsoleBoilerplate.Services;
using System.Threading.Tasks;

namespace NETConsoleBoilerplate
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // build the config
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            // builds your host/dependencies
            var host = CreateHostBuilder().Build();

            var service = ActivatorUtilities.GetServiceOrCreateInstance<IDataService>(host.Services);
            await service.RunAsync();
        }

        // declares where your appsettings are stored
        static void BuildConfig(IConfigurationBuilder builder) =>
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        // initialize dependency injection container
        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder() // initialises host
            .ConfigureServices((context, services) =>
            {
                // your services are added to the container here
                // use the appropriate implementation
                // https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
                services.AddTransient<IDataService, DataService>();
            });
    }
}
