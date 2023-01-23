using ContactManagement.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Persistence.Repositories
{
    public class JsonContactRepositoryFactory : IJsonContactsRepositoryFactory
    {
        public IContactRepository CreateRepository(ILogger<JsonContactsRepository> logger, string jsonFilePath)
        {
            return new JsonContactsRepository(logger, jsonFilePath);
        }

        public async Task InitializeRepositoryAsync(IContactRepository repository)
        {
            if (repository is JsonContactsRepository jsonContactRepository)
            {
                await jsonContactRepository.InitializeAsync();
            }
        }
    }
}
