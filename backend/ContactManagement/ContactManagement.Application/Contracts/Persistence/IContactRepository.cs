using ContactManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Application.Contracts.Persistence
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact? GetContactById(Guid contactId);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Guid contactId);
        Task<bool> SaveChanges();
    }
}
