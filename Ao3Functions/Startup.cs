using Ao3Functions.Configurations;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Ao3Functions.Startup))]
namespace Ao3Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ApplicationConfigurator.Instantiate();
            builder.Services.ConfigureContainer(ApplicationConfigurator.Instance.Get());
        }
    }
}