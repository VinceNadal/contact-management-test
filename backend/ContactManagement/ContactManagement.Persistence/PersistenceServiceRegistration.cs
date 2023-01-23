using ContactManagement.Application.Contracts.Persistence;
using ContactManagement.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string jsonFilePath)
        {
            services.AddScoped<IJsonContactsRepositoryFactory, JsonContactRepositoryFactory>();
            services.AddScoped<IContactRepository>(serviceProvider =>
            {
                var repository = serviceProvider
                    .GetRequiredService<IJsonContactsRepositoryFactory>()
                    .CreateRepository(serviceProvider.GetRequiredService<ILogger<JsonContactsRepository>>(), jsonFilePath);

                serviceProvider.GetRequiredService<IJsonContactsRepositoryFactory>()
                    .InitializeRepositoryAsync(repository)
                    .GetAwaiter()
                    .GetResult();

                return repository;
            });
            
            return services;
        }
    }
}
