using Ao3Api.Client;
using Ao3Api.Mock.Client;
using Ao3Api.Services;
using Ao3Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ao3Api.Configurations
{
    public class ApplicationConfigurator
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IWebHostEnvironment _environment;
        public ApplicationConfigurator(IServiceCollection service, IWebHostEnvironment env)
        {
            _serviceCollection = service;
            _environment = env;
        }
        public ApplicationConfigurator ConfigureServices()
        {
            _serviceCollection.AddMemoryCache();
            _serviceCollection.AddSingleton<IWorksService, WorksService>();
            _serviceCollection.AddSingleton<IHtmlWeb, Ao3HtmlWeb>();
            _serviceCollection.AddSingleton<IAo3Client, Ao3Client>();
            return this;
        }

        public ApplicationConfigurator ConfigureMocks()
        {
            if (!_environment.IsDevelopment()) return this;
            _serviceCollection.AddSingleton<IHtmlWeb, Ao3HtmlWebMock>();
            return this;
        }
    }
}