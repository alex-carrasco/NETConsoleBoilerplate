using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NETConsoleBoilerplate.Contracts;
using System.Threading.Tasks;

namespace NETConsoleBoilerplate.Services
{
    public class DataService : IDataService
    {
        ILogger<DataService> _log;
        IConfiguration _config;

        public DataService(ILogger<DataService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public async Task RunAsync()
        {
            var text = _config.GetValue<string>("Greeting");
            _log.LogInformation(text);
        }
    }
}
