using Ao3Api.Client;
using Ao3Api.Interfaces;
using Ao3Api.Mock.Client;
using Ao3Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ao3Api.Configurations
{
    public class ApplicationConfigurator
    {
        public static void ConfigureServices(IServiceCollection service)
        {
            service.AddMemoryCache();
            service.AddSingleton<IWorksService, WorksService>();
            service.AddSingleton<IHtmlWeb, Ao3HtmlWeb>();
            service.AddSingleton<IAo3Client, Ao3Client>();
            ConfigureMocks(service);
        }

        private static void ConfigureMocks(IServiceCollection service)
        {
            service.AddSingleton<IHtmlWeb, Ao3HtmlWebMock>();
        }
    }
}