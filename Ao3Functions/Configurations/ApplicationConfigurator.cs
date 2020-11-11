using System;
using Ao3Api.Client;
using Ao3Api.Services;
using Ao3Api.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ao3Functions.Configurations
{
    public class ApplicationConfigurator
    {
        public static ApplicationConfigurator Instance { get; protected set; }
        protected internal ServiceProvider Container;

        public static void Instantiate()
        {
            if (Instance != null)
                return;
            Instance = new ApplicationConfigurator();
        }
        protected internal static void Initialize(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IWorksService, WorksService>();
            serviceCollection.AddSingleton<IHtmlWeb, Ao3HtmlWeb>();
            serviceCollection.AddSingleton<IAo3Client, Ao3Client>();
        }
        
        public  object GetService(Type tipo)
        {
            return Container.GetService(tipo);
        }
        public TType GetService<TType>()
        {
            return Container.GetService<TType>();
        }
    }
    
    public static class ApplicationConfiguratorExtension
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, ApplicationConfigurator configurator)
        {
            ApplicationConfigurator.Initialize(services);
            configurator.Container = services.BuildServiceProvider();
            return services;
        }

        public static ApplicationConfigurator Get(this ApplicationConfigurator applicationConfigurator)
        {
            return applicationConfigurator;
        }
    }
}