using ContactManagement.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Persistence.Repositories
{
    public interface IJsonContactsRepositoryFactory
    {
        IContactRepository CreateRepository(ILogger<JsonContactsRepository> logger, string jsonFilePath);
        Task InitializeRepositoryAsync(IContactRepository repository);
    }
}
