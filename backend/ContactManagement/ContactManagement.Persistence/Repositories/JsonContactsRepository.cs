using ContactManagement.Application.Contracts.Persistence;
using ContactManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactManagement.Persistence.Repositories
{
    public class JsonContactsRepository : IContactRepository
    {
        private readonly string jsonFilePath;
        private List<Contact> Contacts { get; set; }
        private readonly ILogger<JsonContactsRepository> logger;

        public JsonContactsRepository(ILogger<JsonContactsRepository> logger, string jsonFilePath)
        {
            this.logger = logger;
            this.jsonFilePath = jsonFilePath;
            Contacts = new List<Contact>();
        }


        public async Task InitializeAsync()
        {
            try
            {
                await using var file = File.Open(jsonFilePath, FileMode.Open, FileAccess.Read);
                Contacts = await JsonSerializer.DeserializeAsync<List<Contact>>(file);
            }
            catch (Exception)
            {
                logger.LogError("Error reading data from JSON");
            }
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void DeleteContact(Guid contactId)
        {
            var contact = GetContactById(contactId);
            Contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            var contacts = Contacts.ToList();
            return contacts;
        }

        public Contact? GetContactById(Guid contactId)
        {
            var contact = Contacts.FirstOrDefault(contact => contactId == contact.Id);
            return contact;
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                await using var fileStream = File.Open(jsonFilePath, FileMode.Truncate);
                await JsonSerializer.SerializeAsync(fileStream, Contacts);
                return true;
            }
            catch (Exception)
            {
                logger.LogError("Error saving contacts to file");
                return false;
            }
        }

        public void UpdateContact(Contact contact)
        {
            var contactToUpdate = Contacts.FirstOrDefault(contactData => contactData.Id == contact.Id);
            
            if (contactToUpdate == null)
            {
                return;
            }
            
            contactToUpdate.FirstName = contact.FirstName;
            contactToUpdate.LastName = contact.LastName;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.BillingAddress = contact.BillingAddress;
            contactToUpdate.DeliveryAddress = contact.DeliveryAddress;
        }
    }
}
